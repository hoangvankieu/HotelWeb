using HotelWeb.Models;
using HotelWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers
{
    [ApiController]
    [Route("customers")]
    [Authorize(Roles = "Admin, Receptionist")]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("/customers")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAllAsync());
        }
        [HttpPost]
        [Route("/customers")]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            if (customer != null)
            {
                if (!await _customerService.Exist(customer))
                {
                    var cus= await _customerService.Insert(customer);
                    if (cus != null)
                    {
                        return Ok(new { isSuccess = true });
                    }
                }
            }
            return Ok(new { isSuccess = false });
        }
        [HttpPut]
        [Route("/customers")]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            if (customer != null)
            {
                if(await _customerService.Exist(customer))
                {
                    var result=await _customerService.Update(customer);
                    return Ok(new { isSuccess = result });
                }
            }
            return Ok(new { isSuccess = false });
        }
        [HttpPost]
        [Route("test")]
        public async Task<IActionResult> Get(string phone)
        {
            return Ok(await _customerService.GetByPhoneNumberAsync(phone));
        }
    }
}
