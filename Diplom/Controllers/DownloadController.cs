using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {
        private readonly IWebHostEnvironment environment;
        public DownloadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost("upload/multiple")]
        public async Task<IActionResult> Multiple(IFormFile[] files)
        {
            try
            {
                var dirInfo = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/files/{User.Identity.Name}/");
                if (!dirInfo.Exists)
                    dirInfo.Create();

                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = $"{User.Identity.Name}_{i}_{files[i].FileName}";
                    string path = $"{dirInfo.FullName}/{fileName}";

                    using var fileStream = new FileStream(path, FileMode.Create);
                    await files[i].CopyToAsync(fileStream);
                }

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
