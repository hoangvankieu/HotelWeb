using Microsoft.AspNetCore.Identity;

namespace HotelWeb.ViewModel
{
    public class RegisterViewModel
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "Customer";
    }
}
