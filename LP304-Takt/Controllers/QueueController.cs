using LP304_Takt.DTO.ReadDto;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<QueueDto>>> GetAllQueues()

        {
            return Ok((await _queueService.GetAllQueues()).Select(q => q.AsDto()));
        }

        [HttpGet("{queueId}")]
        public async Task<ActionResult<QueueDto>> GetOneQueue(int queueId)

        {
            var queue = await _queueService.GetOneQueue(queueId);

            if (queue is null)
            {
                return NotFound($"Queue with id {queueId} was not found.");
            }

            return Ok(queue.AsDto());
        }
        [HttpGet("area/{areaId}")]
        public async Task<ActionResult<QueueDto>> GetQueueFromArea(int areaId)

        {
            var queue = await _queueService.GetOneQueue(areaId);

            if (queue is null)
            {
                return NotFound($"Queue with id {areaId} was not found.");
            }

            return Ok(queue.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> DeleteOrderFromQueue(int queueId, [FromQuery] int orderId)
        {
            var response = await _queueService.DeleteOrderFromQueue(queueId, orderId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
