using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            return Ok("Books retrieved successfully!");
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