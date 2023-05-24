using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService ICenterService;

        public CenterController(ICenterService ICenterService)
        {
            this.ICenterService = ICenterService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<CenterDTO>>> GetAll()
        {
            var c = await ICenterService.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet]
        [Route("GetStation")]
        public async Task<ActionResult<List<CenterDTO>>> GetStation()
        {
            var c = await ICenterService.GetStation();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult<CenterDTO>> GetCenterByID(int Id)
        {
            var c = await ICenterService.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostCenter")]
        public async Task<ActionResult> PostCenter([FromBody] CenterDTO centerDTO)
        {
            var data = await ICenterService.Insert(centerDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("PutCenter/{Id}")]
        public async Task<ActionResult> PutCenter([FromBody] CenterDTO centerDTO, int Id)
        {
            var data = await ICenterService.Update(centerDTO, Id);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("DeleteCenter/{Id}")]

        public async Task<ActionResult<bool>> DeleteCenter(int Id)
        {
            var result = await ICenterService.Delete(Id);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
