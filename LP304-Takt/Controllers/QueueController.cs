using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<QueueDto>> GetOneQueue(int id)

        {
            var queue = await _queueService.GetOneQueue(id);

            if (queue is null)
            {
                return NotFound($"Queue with id {id} was not found.");
            }

            return Ok(queue.AsDto());
        }

        [HttpPut("{queueId}")]
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
