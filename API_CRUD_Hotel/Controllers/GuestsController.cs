using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var guest = _guests.GetGuests(guestid);
            if (guest != null)
            {
                return Ok(guest);
            }
            return NotFound($"Guests with id: {guestid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetGuests(Guests guests)
        {
            var result = await _guests.AddGuestsAsync(guests);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.GuestID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> DeleteGuests(Guid guestid)
        {
            var guests = _guests.GetGuests(guestid);
            if (guestid != null)
            {

                return Ok(await _guests.DeleteGuestsAsync(guests));
            }
            return NotFound($"Guests with id: {guestid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditGuests(Guid GuestID, Guests guests)
        {

            guests.GuestID = GuestID;
            return Ok(await _guests.UpdateGuests(guests));

        }
    }
}
