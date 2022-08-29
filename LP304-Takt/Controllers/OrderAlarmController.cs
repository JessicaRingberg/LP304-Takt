using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderAlarmController : ControllerBase
    {
        private readonly IOrderAlarmService _orderAlarmService;

        public OrderAlarmController(IOrderAlarmService orderAlarmService)
        {
            _orderAlarmService = orderAlarmService;
        }
        [HttpGet("{id}")]
        public async Task<OrderAlarm> GetOrderAlarm(int id)
        {
            return await _orderAlarmService.GetOrderAlarm(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _orderAlarmService.GetAllOrderAlarms();
        }

        [HttpPost]
        public async Task AddOrderEvent(OrderAlarm orderAlarm)
        {
            await _orderAlarmService.AddOrderAlarm(orderAlarm);
        }

        [HttpDelete]
        public async Task RemoveOrderAlarm(OrderAlarm orderAlarm)
        {
            await _orderAlarmService.RemoveOrderAlarm(orderAlarm);
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrderAlarmById(int id)
        {
            await _orderAlarmService.DeleteById(id);


        }

        [HttpPut]
        public async Task UpdateOrderAlarm(OrderAlarm orderAlarm)
        {
            await _orderAlarmService.UpdateOrderAlarm(orderAlarm);
        }
    }
}
