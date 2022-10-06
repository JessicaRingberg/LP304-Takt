using LP304_Takt.DTO;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Models;
using LP304_Takt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            await _orderDetailsService.Add(orderDetails.AsEntity(), orderId, articleId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetailsDto>>> GetOrderDetails()
        {
            return Ok(await _orderDetailsService.GetEntities());
        }
    }
}
