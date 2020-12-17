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
            if(roomsbookedid!=null)
            {
                return Ok(roombookedid);
            }
            return NotFound($"RoomsBooked with id: {roombookedid}");
        }
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetRoomsBooked(RoomsBooked roomBooked)
        {
            _RoomsBooked.AddRoomsBooked(roomBooked);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + roomBooked.RoomBookedID, roomBooked);
        }

        [HttpDelete]
        [Route("api/[controller]/{roombookedid}")]
        public IActionResult DeleteBookings(Guid roombookedid)
        {
            var bookings = _RoomsBooked.GetRoomsBooked(roombookedid);
            if (roombookedid != null)
            {
                _RoomsBooked.DeleteRB(bookings);
                return Ok();
            }
            return NotFound($"Guests with id: {roombookedid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{roombookedid}")]
        public IActionResult EditRB(Guid roombookedid, RoomsBooked roomsBooked)
        {
            var existRB = _RoomsBooked.GetRoomsBooked(roombookedid);
            if (existRB != null)
            {
                roomsBooked.BookingID = existRB.RoomBookedID;
                _RoomsBooked.EditRB(roomsBooked);
            }
            return Ok(roomsBooked);
        }
    }
}
