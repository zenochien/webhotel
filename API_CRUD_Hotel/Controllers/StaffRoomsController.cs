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
    public class StaffRoomsController : ControllerBase
    {
        private readonly IStaffRooms _staffRooms;
        public StaffRoomsController(IStaffRooms staffRooms)
        {
            _staffRooms = staffRooms;
        }

        [HttpGet]
        [Route("api/[controller]/{staffroomid}")]
        public IActionResult GetStaffRooms(Guid staffroomid)
        {
            var staffRooms = _staffRooms.GetStaffRooms(staffroomid);
            if (staffRooms != null)
            {
                return Ok(staffRooms);
            }
            return NotFound($"Staff Rooms with id: {staffroomid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetStaffRooms(StaffRooms staffRooms)
        {
            _staffRooms.AddStaffRooms(staffRooms);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + staffRooms.StaffRoomID, staffRooms);
        }

        [HttpDelete]
        [Route("api/[controller]/{staffroomid}")]
        public IActionResult DeleteStaffRooms(Guid staffroomid)
        {
            var staffrooms = _staffRooms.GetStaffRooms(staffroomid);
            if (staffroomid != null)
            {
                _staffRooms.DeleteStaffRooms(staffrooms);
                return Ok();
            }
            return NotFound($"Staff Rooms with id: {staffroomid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditGuests(Guid staffroomid, StaffRooms staffRooms)
        {
            var existingStaffRooms = _staffRooms.GetStaffRooms(staffroomid);
            if (existingStaffRooms != null)
            {
                staffRooms.StaffRoomID = existingStaffRooms.StaffRoomID;
                _staffRooms.EditStaffRooms(staffRooms);
            }
            return Ok(staffRooms);
        }

    }
}
