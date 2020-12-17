using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{

    [ApiController]
    public class RoomsBookedController : ControllerBase
    {
        private readonly IRoomsBooked _RoomsBooked;
        public RoomsBookedController(IRoomsBooked roomsBooked)
        {
            _RoomsBooked = roomsBooked;
        }

        [HttpGet]
        [Route("api/[controller]/{roombookedid}")]
        public IActionResult GetRoomsBooked(Guid roomsbookedid)
        {
            var roombookedid = _RoomsBooked.GetRoomsBooked(roomsbookedid);
            if (roomsbookedid != null)
            {
                return Ok(roombookedid);
            }
            return NotFound($"RoomsBooked with id: {roombookedid}");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetRoomsBooked(RoomsBooked roomBooked)
        {
            var result = await _RoomsBooked.AddRoomsBookedAsync(roomBooked);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.RoomBookedID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{roombookedid}")]
        public async Task<IActionResult> DeleteBookings(Guid roombookedid)
        {
            var bookings = _RoomsBooked.GetRoomsBooked(roombookedid);
            if (roombookedid != null)
            {
                return Ok(await _RoomsBooked.DeleteRoomBookedsAsync(bookings));
            }
            return NotFound($"Guests with id: {roombookedid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{roombookedid}")]
        public async Task<IActionResult> EditRB(Guid roombookedid, RoomsBooked roomsBooked)
        {
            roomsBooked.BookingID = roombookedid;
            return Ok(await _RoomsBooked.UpdateRoomBookeds(roomsBooked));

        }
    }
}
