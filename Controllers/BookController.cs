using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Book;
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

        public BookController(IBookItemRepo bookItemRepo, IAuthorRepo authorRepo, ICommentRepo commentRepo, ICategoryRepo categoryRepo)
        {
            _bookItemRepo = bookItemRepo;
            _authorRepo = authorRepo;
            _commentRepo = commentRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var books = await _bookItemRepo.GetAllAsync();
            var booksWithAuthors = new List<AllBookDto>();

            // Use foreach to process each book
            foreach (var book in books)
            {
                var author = await _authorRepo.GetAuthorByIdAsync(book.AuthorId);
                var bookWithAuthor = new AllBookDto();
                if (author != null) {
                    bookWithAuthor = book.ToViewAllBookAddAuthor(author);
                }
                else {
                    bookWithAuthor = book.ToViewAllBookAddAuthor();
                }
                var commentCount = await _commentRepo.GetCountCommentOfBook(book.BookId);
                var bookWithComment = bookWithAuthor.ToViewAllBookAddCommited(commentCount);
                var categoryId = await _categoryRepo.GetCategoryIdAsync(book.BookId);
                var categories = await _categoryRepo.GetCategoriesAsync(categoryId);
                var bookWithCategory = bookWithComment.ToViewAllBookAddCategories(categories);
                booksWithAuthors.Add(bookWithCategory);
            }

            return Ok(booksWithAuthors);
        }
    }
}
