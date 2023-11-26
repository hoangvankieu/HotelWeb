using HotelWeb.Models;

namespace HotelWeb.Services
{
    public interface IRoomImageService
    {
        Task<List<RoomImage>> GetRoomImages(int id);
        Task Insert(int id,List<IFormFile> files);
        Task<bool> Delete(int id);
        Task<bool> CheckedMainImage(int roomId,int id);
    }
}
