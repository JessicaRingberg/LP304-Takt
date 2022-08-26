using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("{id}")]
        public async Task<Order> GetOrder(int id)
        {
            return await _orderService.GetOrder(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _orderService.GetAllOrders();
        }

        [HttpPost]
        public async Task AddOrder(Order order)
        {
            await _orderService.AddOrder(order);
        }

        [HttpDelete]
        public async Task RemoveOrder(Order order)
        {
            await _orderService.RemoveOrder(order);
        }

        [HttpPut]
        public async Task UpdateOrder(Order order)
        {
            await _orderService.UpdateOrder(order);
        }
    }
}
