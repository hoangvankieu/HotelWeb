using HotelWeb.Data;
using HotelWeb.Models;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Repositories
{
    public class RoomImageRepository : IRoomImageRepository
    {
        private readonly HotelWebDbcontext _dbcontext;
        public RoomImageRepository(HotelWebDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Delete(RoomImage img)
        {
            
            if (img != null)
            {
                try
                {
                    _dbcontext.RoomImages.Remove(img);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }

        }

        public async Task<RoomImage?> GetByIdAndRoomIdAsync(int roomId, int id)
        {
            return await _dbcontext.RoomImages.FirstOrDefaultAsync(img=>img.Id==id && roomId==img.RoomId);
        }

        public async Task<RoomImage?> GetByIdAsync(int id)
        {
            return await _dbcontext.RoomImages.FindAsync(id);
        }

        public async Task<RoomImage?> GetByMainImg(int roomId, bool mainImg)
        {
            return await _dbcontext.RoomImages.FirstOrDefaultAsync(img=>img.MainImg == mainImg && img.RoomId==roomId);
        }

        public async Task<List<RoomImage>> GetRoomImages()
        {
            return await _dbcontext.RoomImages.ToListAsync();
        }

        public async Task Insert(int id, string path)
        {

            RoomImage img = new RoomImage()
            {
                Path = path,
                RoomId = id,
            };
            try
            {
                await _dbcontext.RoomImages.AddAsync(img);
                await _dbcontext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Update(RoomImage img)
        {
            var entity = await _dbcontext.RoomImages.FindAsync(img.Id);
            if (entity == null)
            {
                return false;
            }
            try
            {
                _dbcontext.Entry(entity).CurrentValues.SetValues(img);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
