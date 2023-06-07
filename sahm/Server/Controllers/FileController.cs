using Microsoft.AspNetCore.Mvc;
using sahm.Shared.Model;

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
        public async Task<ActionResult<string?>> Post([FromBody] ImageFileDTO file)
        {
            var buf = Convert.FromBase64String(file.base64data);
            var url = Path.Combine(env.ContentRootPath, "pics", Guid.NewGuid().ToString("N") + "-" + file.fileName);
            await System.IO.File.WriteAllBytesAsync(url, buf);
            return Ok(url);    
        }
    }
}
