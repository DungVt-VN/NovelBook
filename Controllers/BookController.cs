using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookItemRepo _bookItemRepo;
        private readonly IAuthorRepo _authorRepo;
        private readonly ICommentRepo _commentRepo;
        private readonly ICategoryRepo _categoryRepo;
        private readonly IAnotherNameRepo _anotherNameRepo;
        private readonly ITagRepo _tagRepo;

        public BookController(IBookItemRepo bookItemRepo,
            IAuthorRepo authorRepo,
            ICommentRepo commentRepo,
            ICategoryRepo categoryRepo,
            IAnotherNameRepo anotherNameRepo,
            ITagRepo tagRepo)
        {
            _bookItemRepo = bookItemRepo;
            _authorRepo = authorRepo;
            _commentRepo = commentRepo;
            _categoryRepo = categoryRepo;
            _anotherNameRepo = anotherNameRepo;
            _tagRepo = tagRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookAsync()
        {
            var books = await _bookItemRepo.GetAllAsync();
            var allBook = new List<AllBookDto>();

            foreach (var book in books)
            {
                var author = await _authorRepo.GetAuthorByIdAsync(book.AuthorId);
                var pseudonym = author ?? "Unknown Author"; // Sử dụng "Unknown Author" nếu author là null

                var commentCount = await _commentRepo.GetCountCommentOfBook(book.BookId);

                var categories = await _categoryRepo.GetCategoryByIdAsync(book.BookId);
                var tags = await _tagRepo.GetTagByIdAsync(book.BookId);
                var anotherNames = await _anotherNameRepo.GetAnotherNameByIdAsync(book.BookId);

                var bookWithAuthor = book.ToViewAllBook(pseudonym, commentCount, categories, tags, anotherNames);
                allBook.Add(bookWithAuthor);
            }

            return Ok(allBook);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBookAsync([FromRoute] string id)
        {
            var book = await _bookItemRepo.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound("Book not found!");
            }
            var author = await _authorRepo.GetAuthorByIdAsync(book.AuthorId);
            var pseudonym = author ?? "Unknown Author"; // Sử dụng "Unknown Author" nếu author là null

            var commentCount = await _commentRepo.GetCountCommentOfBook(book.BookId);
            var categories = await _categoryRepo.GetCategoryByIdAsync(book.BookId);
            var tags = await _tagRepo.GetTagByIdAsync(book.BookId);
            var anotherNames = await _anotherNameRepo.GetAnotherNameByIdAsync(book.BookId);

            var bookWithAuthor = book.ToViewDetailBook(pseudonym, commentCount, categories, tags, anotherNames);
            return Ok(bookWithAuthor);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> PostEditBookAsync([FromBody] EditBookDto editBookDto)
        {
            var result = editBookDto.ToEditBook();
            if (result.HasValue)
            {
                var (editBook, categories, tags, author) = result.Value;
                // Sử dụng editBook, categories, tags, và author
                var authorId = await _authorRepo.GetAuthorByNameAsync(author ?? "unknown");
                if (authorId == null)
                {
                    authorId = await _authorRepo.UpdateNewAuthorAsync(author ?? "unknown");
                    if (authorId == null)
                    {
                        return BadRequest("Tên tác giả không hợp lệ.");
                    }
                }
                editBook.AuthorId = (int)authorId;
                var (messageBook, idNewBook) = await _bookItemRepo.UpdateBookAsync(editBook);
                var messageCategory = await _categoryRepo.UpdateCategoryAsync(categories, idNewBook);
                var messageTag = await _tagRepo.UpdateTagAsync(tags, idNewBook);
                var messageAnotherName = await _anotherNameRepo.UpdateAnotherNameAsync(editBookDto.AnotherNames, idNewBook);
                if (messageCategory == null || messageTag == null || messageBook == null)
                {
                    return BadRequest(messageBook + messageCategory + messageTag);
                }
            }
            else
            {
                return BadRequest("Dữ liệu không hợp lệ.");
            }
            return Ok("Update Success!!!");
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var categories = await _categoryRepo.GetAllCategoryAsync();
            return Ok(categories);
        }
        [HttpGet("tags")]
        public async Task<IActionResult> GetAllTagsAsync()
        {
            var tags = await _tagRepo.GetAllTagsAsync();
            return Ok(tags);
        }
    }
}
