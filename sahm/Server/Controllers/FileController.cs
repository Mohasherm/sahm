using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Shared.Model;
using System.Net;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public FileController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<UploadFileDto>> PostUploadFile(List<IFormFile> files)
        {

            UploadFileDto uploadFileDto = new();
            foreach (var file in files)
            {
                string TrustedFileNameForFileStorage;
                var unTrustedFileName = file.Name;
                uploadFileDto.FileName = unTrustedFileName;
                TrustedFileNameForFileStorage = Path.GetRandomFileName();
                var path = Path.Combine(env.ContentRootPath, "pics", TrustedFileNameForFileStorage);

                await using FileStream fs = new(path, FileMode.Create);
                await file.CopyToAsync(fs);
                uploadFileDto.StoredFileName = TrustedFileNameForFileStorage;
            }
            return Ok(uploadFileDto);
        }

    }
}
