using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> AddOrder([FromBody] OrderCreateDto order, [FromQuery] int areaId)
        {           
            var response = await _orderService.Add(order.AsEntity(), areaId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrders()
        {
            return Ok((await _orderService.GetEntities()).Select(order => order.AsDto()));
        }

        [Authorize]
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


        [Authorize(Roles = nameof(Role.Admin))]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var response = await _orderService.DeleteEntity(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [Authorize(Roles = nameof(Role.Admin))]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdateDto order, [FromQuery] int orderId)
        {
            var response = await _orderService.UpdateEntity(order.AsUpdated(), orderId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
