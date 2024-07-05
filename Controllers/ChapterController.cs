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
    [Route("api/chapters")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterRepo _chapterRepo;
        public ChapterController(IChapterRepo chapterRepo)
        {
            _chapterRepo = chapterRepo;
        }

        [Authorize(Roles = "Creator, Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllChapterById([FromRoute] int id)
        {
            var chapter = await _chapterRepo.GetAllChapterByIdAsync(id);
            return Ok(chapter);
        }


        [Authorize(Roles = "Creator, Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateChapterById([FromBody] CreateChapterDto createChatperDto)
        {
            var result = createChatperDto.FromCreateChapter();
            if (result.HasValue)
            {
                var (chapter, images) = result.Value;
                var chapterId = await _chapterRepo.CreateChapterAsync(chapter);
                if (chapterId == null)
                {
                    return BadRequest("Error to Update Chapter!");
                }
                var imagesMessage = await _chapterRepo.CreateImageAsync(images, chapterId ?? -1);
                if (imagesMessage == null)
                {
                    return BadRequest("Error to Add Image!");
                }
            }
            else
            {
                return BadRequest("Invalid");
            }
            return Ok("Created!!");
        }

        [HttpGet("/images/{id}")]
        public async Task<IActionResult> GetImageById([FromRoute] int id)
        {
            var image = await _chapterRepo.GetAllImagesAsync(id);
            return Ok(image);
        }
        
        [HttpPost("update")]
        [Authorize(Roles = "Admin, Creator")]
        public async Task<IActionResult> UpdateChapter([FromBody] CreateChapterDto chapterDto)
        {
            var result = chapterDto.FromCreateChapter();
            if (result.HasValue)
            {
                var (chapter, images) = result.Value;
                var chapterId = await _chapterRepo.EditChapterAsync(chapter);
                if (chapterId == null)
                {
                    return BadRequest("Error to Add New Chapter!");
                }
                else if (chapterId == -1)
                {
                    return BadRequest("Chapter is existing!");
                }
                var imagesMessage = await _chapterRepo.UpdateImageAsync(images, chapterId ?? -1);
                if (imagesMessage == null)
                {
                    return BadRequest("Error to Update Image!");
                }
            }
            else
            {
                return BadRequest("Invalid");
            }
            return Ok("Updated successfully!");
        }
    }

}