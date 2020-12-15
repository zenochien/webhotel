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
    public class RoomStatusController : ControllerBase
    {
        private readonly IRoomStatus _roomStatus;
        public RoomStatusController(IRoomStatus roomStatus)
        {
            _roomStatus = roomStatus;
        }

        [HttpGet]
        [Route("api/[controller]/{roomstatusid}")]
        public IActionResult GetRoomStatus(Guid roomstatusid)
        {
            var roomstatus = _roomStatus.GetRoomStatus(roomstatusid);
            if (roomstatus != null)
            {
                return Ok(roomstatus);
            }
            return NotFound($"Room Status with id: {roomstatusid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetRoomStatus(RoomStatus roomStatus)
        {
            _roomStatus.AddRoomStatus(roomStatus);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + roomStatus.RoomStatusID, roomStatus);
        }

        [HttpDelete]
        [Route("api/[controller]/{roomstatusid}")]
        public IActionResult DeleteRoomTypes(Guid roomtypeid)
        {
            var roomStatus = _roomStatus.GetRoomStatus(roomtypeid);
            if (roomtypeid != null)
            {
                _roomStatus.DeleteRoomStatus(roomStatus);
                return Ok();
            }
            return NotFound($"Room Status with id: {roomStatus} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{roomstatusid}")]
        public IActionResult EditRoomStatus(Guid roomstatusid, RoomStatus roomStatus)
        {
            var existingRoomStatus = _roomStatus.GetRoomStatus(roomstatusid);
            if (existingRoomStatus != null)
            {
                roomStatus.RoomStatusID = existingRoomStatus.RoomStatusID;
                _roomStatus.EditRoomStatus(roomStatus);
            }
            return Ok(roomStatus);
        }
    }
}
