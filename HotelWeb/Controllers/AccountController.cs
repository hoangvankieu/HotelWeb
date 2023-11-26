using HotelWeb.Services;
using HotelWeb.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HotelWeb.Controllers
{
    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAdministatorService _administatorService;
        public AccountController(IAccountService accountService, IAdministatorService administatorService)
        {
            this._accountService = accountService;
            this._administatorService = administatorService;
        }
       
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginView)
        {     
            var tokenResult = await _accountService.Login(loginView);
            if(tokenResult != null)
            {
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(tokenResult),
                    expiration = tokenResult?.ValidTo
                }) ;
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Admin, Customer")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel User)
        {
            if (User != null)
            {
                if(await _accountService.Exist(User.UserName))
                {
                    return BadRequest();
                }
                if(await _accountService.Register(User))
                {
                    return Ok(true);
                };
                
            }
            return BadRequest();
        }
    }
}
