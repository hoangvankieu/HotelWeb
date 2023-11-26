using HotelWeb.Models;

namespace HotelWeb.Repositories
{
    public interface IAdministatorRepository
    {
        Task<Administration?> FindByIdAsync(int id);
        Task<List<Administration>> GetAllAsync();
        Task<Administration?> Insert(Administration administration);
        Task<bool> Update(Administration administration);
        Task<bool> Exist(Administration administration);
        Task<Administration?> GetByPhoneNumberAsync(string phoneNumber);
    }
}
