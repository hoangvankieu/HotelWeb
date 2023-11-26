using HotelWeb.Data;
using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HotelWebDbcontext _context;
        public CustomerRepository(HotelWebDbcontext context)
        {
            _context = context;
        }

        public async Task<bool> Exist(Customer customer)
        {
            return await _context.Customers.AnyAsync(cus=> cus.Email==customer.Email||
            cus.PhoneNumber==customer.PhoneNumber);
        }

        public async Task<Customer?> FindByIdAsync(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(cus=>cus.Id == id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                var x = await _context.Customers.ToListAsync();
                return x;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
        public async Task<Customer?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Customers.FirstOrDefaultAsync(cus => cus.PhoneNumber == phoneNumber);
        }
        public async Task<Customer?> Insert(Customer customer)
        {
            try
            {
                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();
             //   _context.Customers.Entry(customer).GetDatabaseValues();
                return customer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Customer customer)
        {
            try
            {
                var _cus = await _context.Customers.FindAsync(customer.Id);
                if (_cus != null)
                {

                    try
                    {
                        _cus.Name= customer.Name;
                        _cus.PhoneNumber= customer.PhoneNumber;
                        _cus.Email= customer.Email;
                        _cus.OrderNumber= customer.OrderNumber;
                        _cus.Image= customer.Image;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                return false;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
