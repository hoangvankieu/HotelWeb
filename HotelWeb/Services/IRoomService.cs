using HotelWeb.Models;

namespace HotelWeb.Services
{
    public interface IRoomService
    {
        Task<Room?> Insert(Room room);
        Task<Room?> GetRoom(Room room);
        Task<bool> DeleteRoom(Room room);
        Task<Room?> GetRoomById(int id);
        Task<Room?> GetRoomByName(string name);
        Task<bool> ExistRoom(int id);
        Task<List<Room>> GetAllRooms();
        Task<bool> Update(Room room);
    }
}
