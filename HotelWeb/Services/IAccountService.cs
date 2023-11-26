using HotelWeb.Models;
using HotelWeb.ViewModel;
using System.IdentityModel.Tokens.Jwt;

namespace HotelWeb.Services
{
    public interface IAccountService
    {
        Task<JwtSecurityToken?> Login(LoginViewModel account);
        Task<bool> Register(RegisterViewModel account);
        Task<bool> Exist(string username);
    }
}
