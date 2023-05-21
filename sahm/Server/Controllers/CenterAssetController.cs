using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterAssetController : ControllerBase
    {
        private readonly ICenterAssetService centerAssetService;

        public CenterAssetController(ICenterAssetService centerAssetService)
        {
            this.centerAssetService = centerAssetService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<CenterAssetDTO>>> GetAll()
        {
            var c = await centerAssetService.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult<CenterAssetDTO>> GetCenterByID(int Id)
        {
            var c = await centerAssetService.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostCenterAsset")]
        public async Task<ActionResult> PostCenterAsset([FromBody] CenterAssetDTO centerAssetDTO)
        {
            var data = await centerAssetService.Insert(centerAssetDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("PutCenterAsset/{Id}")]
        public async Task<ActionResult> PutCenterAsset([FromBody] CenterAssetDTO centerAssetDTO, int Id)
        {
            var data = await centerAssetService.Update(centerAssetDTO, Id);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("DeleteCenterAsset/{Id}")]

        public async Task<ActionResult<bool>> DeleteCenterAsset(int Id)
        {
            var result = await centerAssetService.Delete(Id);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
