using HotelWeb.Data;
using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Repositories
{
    public class AdministratorRepository : IAdministatorRepository
    {
        private readonly HotelWebDbcontext _context;
        public AdministratorRepository(HotelWebDbcontext context)
        {
            _context = context;
        }
        public Task<bool> Exist(Administration administration)
        {
            throw new NotImplementedException();
        }

        public Task<Administration?> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Administration>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Administration?> GetByPhoneNumberAsync(string phoneNumber) => await _context.Administrations.FirstOrDefaultAsync(adm => adm.PhoneNumber == phoneNumber);
       

        public async Task<Administration?> Insert(Administration administration)
        {
            try
            {
                await _context.Administrations.AddAsync(administration);
                await _context.SaveChangesAsync();
                _context.Administrations.Entry(administration).GetDatabaseValues();
                return administration;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> Update(Administration administration)
        {
            throw new NotImplementedException();
        }
    }
}
