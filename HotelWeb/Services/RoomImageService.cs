using Azure.Core;
using HotelWeb.Models;
using HotelWeb.Repositories;
using System.Web;
namespace HotelWeb.Services
{
    public class RoomImageService : IRoomImageService
    {
        private readonly IRoomImageRepository _roomImageRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RoomImageService(IRoomImageRepository roomImageRepository, IHttpContextAccessor httpContextAccessor)
        {
            _roomImageRepository = roomImageRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CheckedMainImage(int roomId, int id)
        {
            var mainImage = await _roomImageRepository.GetByMainImg(roomId,true);
            if (mainImage != null)
            {
                mainImage.MainImg = false;
                await _roomImageRepository.Update(mainImage);
            }
            var CheckedImg = await _roomImageRepository.GetByIdAndRoomIdAsync(roomId,id);
            if (CheckedImg != null)
            {
                CheckedImg.MainImg = true;
                await _roomImageRepository.Update(CheckedImg);
                return true;
            }
           
            throw new Exception();
        }

        public async Task<bool> Delete(int id)
        {
            var img=await _roomImageRepository.GetByIdAsync(id);
            if (img != null)
            {
                const string folderPath = @"Images/RoomImages/";
                string imageName = Path.GetFileName(img.Path??"");
                string imagePath= Path.Combine(folderPath, imageName);
                if(File.Exists(imagePath))
                {
                    using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                    {
                       
                        fileStream.Close();
                    }

                    
                    File.Delete(imagePath);
                }
                return await _roomImageRepository.Delete(img);
            }
            return false;
        }

        public async Task<List<RoomImage>> GetRoomImages(int roomId)
        {
            var imgs = await _roomImageRepository.GetRoomImages();
            var roomImages = imgs.FindAll(img => img.RoomId == roomId);
            return roomImages;
        }

        public async Task Insert(int id, List<IFormFile> files)
        {
            const string folderpath= "Images/RoomImages/";
            string rootPath = Path.Combine(Directory.GetCurrentDirectory(), folderpath);
            if(!Directory.Exists(rootPath))
            {
                try
                {
                    Directory.CreateDirectory(rootPath);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            string host = _httpContextAccessor.HttpContext.Request.Host.Host;
            int port = _httpContextAccessor.HttpContext.Request.Host.Port??443;
            string url = $"https://{host}:{port}";
            foreach (var file in files)
            {
                string randomFileName = Path.GetRandomFileName();
                string newFileName = Path.ChangeExtension(randomFileName, ".jpg");
                string pathLocal = Path.Combine(rootPath, newFileName);
                string pathServer= Path.Combine(url,folderpath, newFileName);
                if (file.Length > 0)
                {
                    using(var stream= System.IO.File.Create(pathLocal))
                    {
                        await file.CopyToAsync(stream);
                        
                    }
                    await _roomImageRepository.Insert(id, pathServer);
                }

            }

           
        }
    }
}
