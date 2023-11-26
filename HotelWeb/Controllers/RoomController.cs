using HotelWeb.Models;
using HotelWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers
{
    [ApiController]
    [Route("rooms")]
    [Authorize(Roles = "Admin, RoomManagement")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IRoomImageService _roomImageService;
        public RoomController(IRoomService roomService, IRoomImageService roomImageService)
        {
            _roomService = roomService;
            _roomImageService = roomImageService;
        }

        [HttpGet]
        [Route("/rooms")]
        public async Task<IActionResult>  getRooms()
        {
            return Ok(await _roomService.GetAllRooms());
        }
        [HttpPost]
        [Route("/rooms")]
        public async Task<IActionResult> Create([FromBody] Room room)
        {
            if(room != null)
            {
                if (!await _roomService.ExistRoom(room.Id))
                {
                    var _room = _roomService.Insert(room);
                    if (_room != null)
                    {
                        return Ok(new {isSuccess= true});
                    }
                }
            }
            return Ok(new { isSuccess = false });
        }
        [HttpPut]
        [Route("/rooms")]
        public async Task<IActionResult> Update([FromBody] Room room)
        {
            if (room != null)
            {
                var result = await _roomService.Update(room);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("/rooms/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var _room = await _roomService.GetRoomById(id);
            if(_room!=null)
            {
                try
                {
                    var result = await _roomService.DeleteRoom(_room);
                    return Ok(true);
                }
                catch (Exception ex)
                {
                    return Conflict(ex.Message);
                }
             
            }
            return NotFound();
            
        }
        [HttpGet]
        [Route("/rooms/{id}/image")]
        public async Task<IActionResult> GetRoomImages([FromRoute]int id)
        {
            return Ok(await _roomImageService.GetRoomImages(id));
        }

        [HttpPost]
        [Route("/rooms/{id}/image")]
        public async Task<IActionResult> Create([FromRoute] int id,[FromForm] List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                if (await _roomService.ExistRoom(id))
                {
                    await _roomImageService.Insert(id, files);
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("/rooms/image/{id}")]
        public async Task<IActionResult> DeleteImage([FromRoute] int id)
        {

            if(await _roomImageService.Delete(id))
            {
                return Ok(true);
            }
            return Unauthorized();
        }
        [HttpPut]
        [Route("/rooms/{roomId}/image/{id}/main-image")]
        public async Task<IActionResult> CheckedMainImage([FromRoute] int roomId,[FromRoute] int id)
        {
            if (await _roomImageService.CheckedMainImage(roomId,id))
            {
                return Ok(true);
            }
            return Unauthorized();
        }
    }
}
