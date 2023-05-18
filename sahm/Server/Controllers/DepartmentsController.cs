using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository;
using sahm.Shared.Models;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartment idepartment;

        public DepartmentsController(IDepartment department)
        {
            this.idepartment = department;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<DepartmentDto>>> GetAll()
        { 
            var c =  await idepartment.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return  Ok(c);
        }

        [HttpGet("GetById/{Id}")]

        public async Task<ActionResult<DepartmentDto>> GetDepartmentByID(int Id)
        {
            var c = await idepartment.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostDepartment")]
        public async Task<ActionResult> PostDepartment([FromBody]DepartmentDto departmentDto)
        {
            var data = await idepartment.Insert(departmentDto);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("PutDepartment/{Id}")]
        public async Task<ActionResult> PutDepartment([FromBody] DepartmentDto departmentDto ,  int Id)
        {
            var data = await idepartment.Update(departmentDto,Id);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("DeleteDepartment/{Id}")]

        public async Task<ActionResult<bool>> DeleteDepartment(int Id)
        {
            var result = await idepartment.Delete(Id);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
