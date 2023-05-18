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
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleService IJobTitleService;

        public JobTitleController(IJobTitleService IJobTitleService)
        {
            this.IJobTitleService = IJobTitleService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<JobTitleDTO>>> GetAll()
        {
            var c = await IJobTitleService.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult<JobTitleDTO>> GetDepartmentByID(int Id)
        {
            var c = await IJobTitleService.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostJobTitle")]
        public async Task<ActionResult> PostJobTitle([FromBody] JobTitleDTO  jobTitleDTO)
        {
            var data = await IJobTitleService.Insert(jobTitleDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("PutJobTitle/{Id}")]
        public async Task<ActionResult> PutJobTitle([FromBody] JobTitleDTO  jobTitleDTO, int Id)
        {
            var data = await IJobTitleService.Update(jobTitleDTO, Id);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("DeleteJobTitle/{Id}")]

        public async Task<ActionResult<bool>> DeleteJobTitle(int Id)
        {
            var result = await IJobTitleService.Delete(Id);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}

