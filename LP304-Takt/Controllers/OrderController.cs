using LP304_Takt.DTO;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost, Authorize]
        public async Task<IActionResult> AddOrder([FromBody] OrderCreateDto order, [FromQuery] int areaId)
        {
            await _orderService.Add(order.AsEntity(), areaId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            return Ok((await _orderService.GetEntities()).Select(order => order.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderService.GetEntity(id);

            if (order is null)
            {
                return NotFound("Order with id " + id + " was not found.");
            }

            return Ok(order.AsDto());
        }


        [HttpDelete("{id}"), Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateDto order, [FromQuery] int orderId)
        {
            await _orderService.UpdateEntity(order.AsUpdated(), orderId);

            return Ok();
        }
    }
}
