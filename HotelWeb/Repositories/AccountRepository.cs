using HotelWeb.Data;
using HotelWeb.Models;
using HotelWeb.Services;
using HotelWeb.ViewModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly HotelWebDbcontext _context;
        private readonly ICustomerService _customerService;
        private readonly IAdministatorService _administatorService;
        public AccountRepository(UserManager<IdentityUser> userManager,
            HotelWebDbcontext context,
            RoleManager<IdentityRole> roleManager,
            ICustomerService customerService,
            IAdministatorService administatorService)
        {
            this._userManager = userManager;
            this._context = context;
            this._roleManager = roleManager;
            this._customerService= customerService;
            this._administatorService=administatorService;
        }

        public async Task<IdentityUser?> GetByPhoneNumber(string phoneNumber)
        {
           
            return await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
            
        }

        public async Task<ApplicationUser> Login(LoginViewModel account)
        {
            var user=await _userManager.FindByNameAsync(account.UserName);
            if (user != null)
            {
                if (await _userManager.CheckPasswordAsync(user,account.Password))
                {
                    var userRole= (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                    if (userRole == "Customer")
                    {
                        var customer =await _customerService.GetByPhoneNumberAsync(user.PhoneNumber??"");
                        if (customer != null)
                        {
                            customer.Role = userRole;
                            return customer;
                        }
                    }
                    else
                    {
                        var admin = await _administatorService.GetByPhoneNumberAsync(user.PhoneNumber ?? "");
                        if (admin != null)
                        {
                            admin.Role = userRole;
                            return admin;
                        }
                    }
                }
            }
            throw new NotImplementedException();
        }

        public async Task<bool> Register(RegisterViewModel account)
        {
            if(account == null) throw new ArgumentNullException(nameof(account));
            try
            {
                if (account.Role != "Customer" && account.Role!="")
                {
                    var AdminAccount = new Administration()
                    {
                        PhoneNumber = account.UserName,
                        
                    };
                    await _administatorService.Insert(AdminAccount);
                }
                else
                {
                    var customer = new Customer()
                    {
                        PhoneNumber = account.UserName,
                        
                    };
                    await _customerService.Insert(customer);
                }
                var user = new IdentityUser()
                {
                    UserName = account.UserName,
                    PhoneNumber = account.UserName

                };
                var result = await _userManager.CreateAsync(user, account.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(account.Role))
                    {
                       await _roleManager.CreateAsync(new IdentityRole() { Name = account.Role });
                    }
                    var currentUser = await _userManager.FindByIdAsync(user.Id);
                    if (currentUser != null)
                    {
                        await _userManager.AddToRoleAsync(currentUser, account.Role);
                        
                        return true;
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
            return false;
        }
    }
}
