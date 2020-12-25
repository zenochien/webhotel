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
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok();
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
        public async Task<IActionResult> GetRoomStatus(RoomStatus roomStatus)
        {
           var result = await _roomStatus.AddRoomStatusAsync(roomStatus);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.RoomStatusID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{roomstatusid}")]
        public async Task<IActionResult> DeleteRoomTypes(Guid roomtypeid)
        {
            var roomStatus = _roomStatus.GetRoomStatus(roomtypeid);
            if (roomtypeid != null)
            {               
                return Ok(await _roomStatus.DeleteRoomStatusAsync(roomStatus));
            }
            return NotFound($"Room Status with id: {roomStatus} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{roomstatusid}")]
        public async Task<IActionResult> EditRoomStatus(Guid roomstatusid, RoomStatus roomStatus)
        {

            roomStatus.RoomStatusID = roomstatusid;
            return Ok(await _roomStatus.UpdateRoomStatusAsync(roomStatus));
        }
    }
}
