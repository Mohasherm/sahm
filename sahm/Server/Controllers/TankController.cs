using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TankController : ControllerBase
    {
        private readonly ITankService tankService;

        public TankController(ITankService tankService)
        {
            this.tankService = tankService;
        }

        [HttpGet("GetTankForCenter/{Center_Id:int}")]

        public async Task<ActionResult<List<TankDTO>?>> GetTankForCenter(int Center_Id)
        {
            var c = await tankService.GetById(Center_Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }


        [HttpPost]
        [Route("PostTankOperation")]
        public async Task<ActionResult> PostTankOperation([FromBody] TankOperationDTO tankOperationDTO)
        {
            var data = await tankService.Insert(tankOperationDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("PutTankQTY/{Id}")]
        public async Task<ActionResult> PutTankQTY([FromBody] TankQTYUpdateDTO tankQTYUpdateDTO, int Id)
        {
            var data = await tankService.UpdateTankQTY(tankQTYUpdateDTO, Id);
            if (data)
                return Ok();
            else
                return BadRequest();
        }
    }
}
