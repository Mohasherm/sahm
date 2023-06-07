using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintController : ControllerBase
    {
        private readonly IComplaintService complaintService;

        public ComplaintController(IComplaintService complaintService)
        {
            this.complaintService = complaintService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<ComplaintDTO>>> GetAll()
        {
            var c = await complaintService.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult<ComplaintDTO>> GetComplaintByID(int Id)
        {
            var c = await complaintService.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostComplaint")]
        public async Task<ActionResult> PostComplaint([FromBody] ComplaintDTO complaintDTO)
        {
            var data = await complaintService.Insert(complaintDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }


    }
}
