using HotelWeb.Models;

namespace HotelWeb.Services
{
    public interface ICustomerService
    {
        Task<Customer?> FindByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> Insert(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Exist(Customer customer);
        Task<Customer?> GetByPhoneNumberAsync(string phoneNumber);
    }
}
