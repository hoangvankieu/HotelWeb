using HotelWeb.Models;

namespace HotelWeb.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> FindByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> Insert(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Exist(Customer customer);
        Task<Customer?> GetByPhoneNumberAsync(string phoneNumber);
    }
}
