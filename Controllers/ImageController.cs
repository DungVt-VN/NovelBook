using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImgurUploader.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImgurSettings _imgurSettings;

        public ImageController(IOptions<ImgurSettings> imgurSettings)
        {
            _imgurSettings = imgurSettings.Value ?? throw new ArgumentNullException(nameof(imgurSettings));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var imageData = memoryStream.ToArray();
            var base64Image = Convert.ToBase64String(imageData);

            var client = new RestClient("https://api.imgur.com/3/image");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Authorization", $"Client-ID {_imgurSettings.ClientId}");
            request.AddParameter("image", base64Image);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                if (response.Content != null)
                {
                    // Extract the URL of the uploaded image from the response
                    var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
                    if (jsonResponse?.data?.link != null)
                    {
                        string imageUrl = jsonResponse.data.link;
                        return Ok(new { Url = imageUrl });
                    }
                }
                
                return StatusCode(500, "Failed to extract image URL from response.");
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.Content);
            }
        }
    }
}
