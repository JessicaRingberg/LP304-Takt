using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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

        [HttpGet("{orderDetailId}")]
        public async Task<ActionResult<OrderDetailsDto>> GetOrderDetail(int orderDetailId)
        {
            var orderDetail = await _orderDetailsService.GetEntity(orderDetailId);
            if (orderDetail is null)
            {
                return NotFound($"OrderDetail with id: {orderDetailId} was not found");
            }
            return Ok(orderDetail.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{orderDetailId}")]
        public async Task<IActionResult> DeleteArticle(int orderDetailId)
        {
            var response = await _orderDetailsService.DeleteEntity(orderDetailId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetails([FromBody] OrderDetailsUpdateDto orderDetails, [FromQuery] int orderDetailsId)
        {
            var response = await _orderDetailsService.UpdateEntity(orderDetails.AsUpdated(), orderDetailsId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
