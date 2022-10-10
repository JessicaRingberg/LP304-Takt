using LP304_Takt.DTO;
using LP304_Takt.Interfaces.Services;
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
        public async Task<ActionResult<ICollection<Queue>>> GetQueue()

        {
            return Ok(await _queueService.GetEntities());
        }
    }
}
