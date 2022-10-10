using LP304_Takt.DTO;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderDetails([FromBody] OrderDetailsCreateDto orderDetails, [FromQuery] int orderId, [FromQuery] int articleId)
        {
            var response = await _orderDetailsService.Add(orderDetails.AsEntity(), orderId, articleId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<OrderDetailsDto>>> GetOrderDetails()

        {
            return Ok((await _orderDetailsService.GetEntities()).Select(orderDetails => orderDetails.AsDto()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetail(int id)
        {
            var orderDetail = await _orderDetailsService.GetEntity(id);
            if (orderDetail is null)
            {
                return NotFound($"OrderDetail with id: {id} was not found");
            }
            return Ok(orderDetail.AsDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _orderDetailsService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetails([FromBody] OrderDetailsUpdateDto orderDetails, [FromQuery] int orderDetailsId)
        {
            await _orderDetailsService.UpdateEntity(orderDetails.AsUpdated(), orderDetailsId);

            return Ok();
        }
    }
}
