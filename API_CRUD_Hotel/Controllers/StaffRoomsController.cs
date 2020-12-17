using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok();
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
        public async Task<IActionResult> GetStaffRooms(StaffRooms staffRooms)
        {
            var result = await _staffRooms.AddStaffRoomsAsync(staffRooms);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.StaffRoomID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{staffroomid}")]
        public async Task<IActionResult> DeleteStaffRooms(Guid staffroomid)
        {
            var staffrooms = _staffRooms.GetStaffRooms(staffroomid);
            if (staffroomid != null)
            {

                return Ok(await _staffRooms.DeleteStaffRoomsAsync(staffrooms));
            }
            return NotFound($"Staff Rooms with id: {staffroomid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditGuests(Guid staffroomid, StaffRooms staffRooms)
        {
            staffRooms.StaffRoomID = staffroomid;
            return Ok(await _staffRooms.UpdateStaffRoomsAsync(staffRooms));
        }
    }
}
