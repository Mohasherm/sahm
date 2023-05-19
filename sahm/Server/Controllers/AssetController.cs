using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;
using sahm.Shared.Models;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService IAssetService;

        public AssetController(IAssetService IAssetService)
        {
            this.IAssetService = IAssetService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<AssetDTO>>> GetAll()
        {
            var c = await IAssetService.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult<AssetDTO>> GetAssetByID(int Id)
        {
            var c = await IAssetService.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostAsset")]
        public async Task<ActionResult> PostAsset([FromBody] AssetDTO assetDTO)
        {
            var data = await IAssetService.Insert(assetDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("PutAsset/{Id}")]
        public async Task<ActionResult> PutAsset([FromBody] AssetDTO assetDTO, int Id)
        {
            var data = await IAssetService.Update(assetDTO, Id);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("DeleteAsset/{Id}")]

        public async Task<ActionResult<bool>> DeleteAsset(int Id)
        {
            var result = await IAssetService.Delete(Id);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
