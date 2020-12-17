using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRooms _rooms;
        public RoomsController(IRooms rooms)
        {
            _rooms = rooms;
        }

        [HttpGet]
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/{roomsid}")]
        public IActionResult GetRooms(Guid roomsid)
        {
            var rooms = _rooms.GetRooms(roomsid);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            return NotFound($"Rooms with id: {roomsid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetRooms(Rooms rooms)
        {
            var result = await _rooms.AddRoomsAsync(rooms);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.RoomsID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{roomsid}")]
        public async Task<IActionResult> DeleteRooms(Guid roomsid)
        {
            var rooms = _rooms.GetRooms(roomsid);
            if (roomsid != null)
            {

                return Ok(await _rooms.DeleteRoomsAsync(rooms));
            }
            return NotFound($"Rooms with id: {roomsid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditRooms(Guid roomsid, Rooms rooms)
        {
            rooms.RoomsID = roomsid;
            return Ok(await _rooms.UpdateRoomsAsync(rooms));
        }
    }
}
