using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderEventController : ControllerBase
    {
        private readonly IOrderEventService _orderEventService;

        public OrderEventController(IOrderEventService orderEventService)
        {
            _orderEventService = orderEventService;
        }

        [HttpGet("{id}")]
        public async Task<OrderEvent> GetOrderEvent(int id)
        {
            return await _orderEventService.GetOrderEvent(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _orderEventService.GetAllOrderEvents();
        }

        [HttpPost]
        public async Task AddOrderEvent(OrderEvent orderEvent)
        {
            await _orderEventService.AddOrderEvent(orderEvent);
        }

        [HttpDelete]
        public async Task RemoveOrderEvent(OrderEvent orderEvent)
        {
            await _orderEventService.RemoveOrderEvent(orderEvent);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrderEventById(int id)
        {
            await _orderEventService.DeleteById(id);


        }

        [HttpPut]
        public async Task UpdateOrderEvent(OrderEvent orderEvent)
        {
            await _orderEventService.UpdateOrderEvent(orderEvent);
        }
    }
}
