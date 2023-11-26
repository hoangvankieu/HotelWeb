using HotelWeb.Data;
using HotelWeb.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HotelWeb.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelWebDbcontext _context;
        public RoomRepository(HotelWebDbcontext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteRoom(Room room)
        {
            var _room = _context.Rooms.Find(room.Id);
            if (_room != null)
            {
                _context.Rooms.Remove(_room);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ExistRoom(int id)
        {
            var result = await _context.Rooms.AnyAsync(r => r.Id == id);
            return result;
        }

        public Task<Room?> GetRoom(Room room)
        {
            return _context.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id);
        }

        public Task<Room?> GetRoomById(int id)
        {
            return _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);

        }

        public async Task<Room?> GetRoomByName(string name)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> Insert(Room room)
        {

            try
            {
                await _context.Rooms.AddAsync(room);
                await _context.SaveChangesAsync();
                _context.Entry(room).GetDatabaseValues();
                return room;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Update(Room room)
        {
            try
            {
                var _room = await _context.Rooms.FindAsync(room.Id);
                if (_room != null)
                {

                    try
                    {
                        _room.Id = room.Id;
                        _room.Name = room.Name;
                        _room.Price = room.Price;
                        _room.Description = room.Description;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    catch (Exception)
                    {

                        throw new Exception();
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
