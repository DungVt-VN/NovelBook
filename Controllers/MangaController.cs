using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/manga")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllAsync() 
        {
            // Tạm thời trả về một danh sách rỗng để kiểm tra kết nối API
            return Ok("Manga retrieved successfully!");
        }
    }
}
