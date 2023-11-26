using HotelWeb.Models;
using HotelWeb.Repositories;

namespace HotelWeb.Services
{
    public class AdministratorService : IAdministatorService
    {
        private readonly IAdministatorRepository _administratorRepository;
        public AdministratorService(IAdministatorRepository administatorRepository)
        {
            _administratorRepository = administatorRepository;
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

        public async Task<Administration?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _administratorRepository.GetByPhoneNumberAsync(phoneNumber);
        }

        public async Task<Administration?> Insert(Administration administration)
        {
            return await _administratorRepository.Insert(administration);
        }

        public Task<bool> Update(Administration administration)
        {
            throw new NotImplementedException();
        }
    }
}
