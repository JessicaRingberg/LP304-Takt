using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Queue = LP304_Takt.Models.Queue;

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

        [HttpGet("{id}")]
        public async Task<Queue> GetOneQueue(int id)
        {
            return await _queueService.GetOneQueue(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _queueService.GetAllQueues();
        }

        [HttpPost]
        public async Task AddQueue(Queue queue)
        {
            await _queueService.AddQueue(queue);
        }

        [HttpDelete]
        public async Task RemoveQueue(Queue queue)
        {
            await _queueService.RemoveQueue(queue);
        }

        [HttpPut]
        public async Task UpdateQueue(Queue queue)
        {
            await _queueService.UpdateQueue(queue);
        }
    }
}
