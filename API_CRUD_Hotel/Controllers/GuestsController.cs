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
    public class GuestsController : ControllerBase
    {
        private readonly IGuests _guests;
        public GuestsController(IGuests guests)
        {
            _guests = guests;
        }

        [HttpGet]
        [Route("api/[controller]/{guestid}")]
        public IActionResult GetGuests(Guid guestid)
        {
            var guests = _guests.GetGuests(guestid);
            if (guests != null)
            {
                return Ok(guests);
            }
            return NotFound($"Guests with id: {guestid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetGuests(Guests guests)
        {
            _guests.AddGuests(guests);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + guests.GuestID, guests);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public IActionResult DeleteGuests(Guid guestid)
        {
            var guests = _guests.GetGuests(guestid);
            if (guestid!=null)
            {
                _guests.DeleteGuests(guests);
                return Ok();
            }
            return NotFound($"Guests with id: {guestid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditGuests(Guid GuestID, Guests guests)
        {
            var  exitingguests = _guests.GetGuests(GuestID);
            if (exitingguests != null)
            {
                guests.GuestID = exitingguests.GuestID;
                _guests.EditGuests(guests);
            }
            return Ok(guests);
        }
    }
}
