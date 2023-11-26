using HotelWeb.Models;
using HotelWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers
{
    [ApiController]
    [Route("orders")]
    [Authorize(Roles = "Admin, Receptionist")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("/:date_number")]
        public async Task<IActionResult>  Get([FromRoute] int ?date_number)
        {
            var orders = await _orderService.GetOrders(date_number);

            return Ok(orders);
        }
        [HttpPost]
        [Route("/")]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (order != null)
            {
                var result = await _orderService.Insert(order);
                return Ok(result);
            }
            return Ok(false);
            
        }
        [HttpPut]
        [Route("/")]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            if(await _orderService.Exist(order))
            {
                var result= await _orderService.Update(order);
                return Ok(result);
            }
            return Ok(false);
        }
    }
}