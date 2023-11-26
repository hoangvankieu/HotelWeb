using HotelWeb.Models;

namespace HotelWeb.Repositories
{
    public interface IRoomImageRepository
    {
        Task<List<RoomImage>> GetRoomImages();
        Task Insert(int id,string path);
        Task<bool> Delete(RoomImage img);
        Task<RoomImage?> GetByIdAsync(int id);
        Task<RoomImage?> GetByIdAndRoomIdAsync(int roomId, int id);
        Task<RoomImage?> GetByMainImg(int roomId,bool mainImg);
        Task<bool> Update(RoomImage img);
    }
}
