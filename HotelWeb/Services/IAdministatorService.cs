using HotelWeb.Models;

namespace HotelWeb.Services
{
    public interface IAdministatorService
    {
        Task<Administration?> FindByIdAsync(int id);
        Task<List<Administration>> GetAllAsync();
        Task<Administration?> Insert(Administration administration);
        Task<bool> Update(Administration administration);
        Task<bool> Exist(Administration administration);
        Task<Administration?> GetByPhoneNumberAsync(string phoneNumber);
    }
}
