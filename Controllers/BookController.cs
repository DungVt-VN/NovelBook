using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // Get all books from the database
            var books = await _bookItemRepo.GetAllAsync();

            // Add Author of the book to the list
            var booksAuthor = books.Select(au => {
                var author = _authorRepo.GetAuthorAsync(4).ToString();
                if (author != null)
                    return au.ToViewAllBookAddAuthor(author);
                return au.ToViewAllBookAddAuthor();
            });
            return Ok(booksAuthor);
        }

        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public IActionResult GetByIdAsync(int id)
        {
            return Ok("Books retrieved successfully!");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("You are a USER");
        }

        [Authorize(Roles = "Guest")]
        [HttpGet("guest")]
        public IActionResult Guest()
        {
            return Ok("You are a GUEST");
        }
    }
}
