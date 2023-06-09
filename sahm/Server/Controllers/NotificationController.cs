using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sahm.Server.Repository.IRepository;
using sahm.Shared.Model;

namespace sahm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<NotificationDTO>>> GetAll()
        {
            var c = await notificationService.GetAll();
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpGet("GetById/{Id:Guid}")]

        public async Task<ActionResult<List<NotificationDTO>>> GetUserNotification(Guid Id)
        {
            var c = await notificationService.GetById(Id);
            if (c == null)
            {
                return NoContent();
            }

            return Ok(c);
        }

        [HttpPost]
        [Route("PostNotification")]
        public async Task<ActionResult> PostNotification([FromBody] NotificationDTO notificationDTO)
        {
            var data = await notificationService.Insert(notificationDTO);
            if (data)
                return Ok();
            else
                return BadRequest();
        }

        

        [HttpDelete("DeleteNotification/{Id}")]

        public async Task<ActionResult<bool>> DeleteNotification(int Id)
        {
            var result = await notificationService.Delete(Id);
            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
