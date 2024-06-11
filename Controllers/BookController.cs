using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
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

        public BookController(IBookItemRepo bookItemRepo)
        {
            _bookItemRepo = bookItemRepo;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookDtos = await _bookItemRepo.GetAllAsync();
            

            return Ok(bookDtos);
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