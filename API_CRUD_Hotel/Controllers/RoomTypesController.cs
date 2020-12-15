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
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypes _roomTypes;
        public RoomTypesController(IRoomTypes roomTypes)
        {
            _roomTypes = roomTypes;
        }

        [HttpGet]
        [Route("api/[controller]/{roomtypeid}")]
        public IActionResult GetRoomTypes(Guid roomtypeid)
        {
            var rommTypes = _roomTypes.GetRoomTypes(roomtypeid);
            if (rommTypes != null)
            {
                return Ok(rommTypes);
            }
            return NotFound($"Room Types with id: {roomtypeid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetRoomTypes(RoomTypes roomTypes)
        {
            _roomTypes.AddRoomTypes(roomTypes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + roomTypes.RoomTypeID, roomTypes);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public IActionResult DeleteRoomTypes(Guid roomtypeid)
        {
            var roomTypes = _roomTypes.GetRoomTypes(roomtypeid);
            if (roomtypeid != null)
            {
                _roomTypes.DeleteRoomTypes(roomTypes);
                return Ok();
            }
            return NotFound($"Room Types with id: {roomTypes} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{roomtypeid}")]
        public IActionResult EditRoomTypes(Guid roomTypesid, RoomTypes roomTypes)
        {
            var existingRoomTypes = _roomTypes.GetRoomTypes(roomTypesid);
            if (existingRoomTypes != null)
            {
                roomTypes.RoomTypeID = existingRoomTypes.RoomTypeID;
                _roomTypes.EditRoomTypes(roomTypes);
            }
            return Ok(roomTypes);
        }

    }
}
