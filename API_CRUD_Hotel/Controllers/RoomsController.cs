using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult GetRooms(Rooms rooms)
        {
            _rooms.AddRooms(rooms);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + rooms.RoomsID, rooms);
        }

        [HttpDelete]
        [Route("api/[controller]/{roomsid}")]
        public IActionResult DeleteRooms(Guid roomsid)
        {
            var rooms = _rooms.GetRooms(roomsid);
            if (roomsid != null)
            {
                _rooms.DeleteRooms(rooms);
                return Ok();
            }
            return NotFound($"Rooms with id: {roomsid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditRooms(Guid roomsid, Rooms rooms)
        {
            var existrooms = _rooms.GetRooms(roomsid);
            if (existrooms != null)
            {
                rooms.RoomsID = rooms.RoomsID;
                _rooms.EditRooms(rooms);
            }
            return Ok(rooms);
        }
    }
}
