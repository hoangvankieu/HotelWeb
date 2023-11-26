using HotelWeb.Models;
using HotelWeb.Repositories;

namespace HotelWeb.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Exist(Customer customer)
        {
            return await _customerRepository.Exist(customer); 
        }

        public async Task<Customer?> FindByIdAsync(int id)
        {
            return await _customerRepository.FindByIdAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _customerRepository.GetByPhoneNumberAsync(phoneNumber);
        }

        public async Task<Customer?> Insert(Customer customer)
        {
            return await _customerRepository.Insert(customer);
        }

        public async Task<bool> Update(Customer customer)
        {
            return await _customerRepository.Update(customer);
        }
    }
}
