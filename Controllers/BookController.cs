using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
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
            // Tạm thời trả về một danh sách rỗng để kiểm tra kết nối API
            return Ok("Books retrieved successfully!");
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult GetByIdAsyn(int id)
        {
            return Ok("Books retrieveuserrrrrrrrrrrrrrr");
        }

    }
}