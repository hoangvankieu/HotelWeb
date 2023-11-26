using HotelWeb.Models;
using HotelWeb.Repositories;
using HotelWeb.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelWeb.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IConfiguration _configuration;
        public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
        {
            _accountRepository = accountRepository;
            _configuration = configuration;
        }

        public async Task<bool> Exist(string username)
        {
            return await _accountRepository.GetByPhoneNumber(username) != null;
        }

        public async Task<JwtSecurityToken?> Login(LoginViewModel account)
        {
            var user = await _accountRepository.Login(account);
            if (user != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.PhoneNumber??""),
                    new Claim(ClaimTypes.Role, user.Role??""),
                    new Claim(ClaimTypes.Email,user.Email??""),
                    new Claim("FullName", user.Name??""),
                    new Claim("ImagePath",user.Image??""),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]??""));
                var token = new JwtSecurityToken(
                                issuer: _configuration["Jwt:Issuer"],
                                audience: _configuration["Jwt:Audience"],
                                expires: DateTime.Now.AddHours(3),
                                claims: authClaims,
                                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return (token);
            }
            return null;
        }

        public async Task<bool> Register(RegisterViewModel account)
        {
            return await _accountRepository.Register(account);
        }
    }
}
