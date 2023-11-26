using HotelWeb.Models;
using HotelWeb.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace HotelWeb.Repositories
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> Login(LoginViewModel account);
        Task<bool> Register(RegisterViewModel account);
        Task<IdentityUser?> GetByPhoneNumber(string phoneNumber);
    }
}
