    

using HotelWeb.Models;
using HotelWeb.Repositories;

namespace HotelWeb.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }
        public async Task<bool> DeleteRoom(Room room)
        {
            return await _roomRepository.DeleteRoom(room);
        }

        public async Task<bool> ExistRoom(int id)
        {
            return await _roomRepository.ExistRoom(id);
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _roomRepository.GetRooms();
        }

        public async Task<Room?> GetRoom(Room room)
        {
            return await _roomRepository.GetRoom(room);
        }

        public async Task<Room?> GetRoomById(int id)
        {
            return await _roomRepository.GetRoomById(id);
        }

        public async Task<Room?> GetRoomByName(string name)
        {
            return await _roomRepository.GetRoomByName(name);
        }

        public async Task<Room?> Insert(Room room)
        {
            return await _roomRepository.Insert(room);
        }

        public async Task<bool> Update(Room room)
        {
           return await _roomRepository.Update(room);
        }

       
    }
}
