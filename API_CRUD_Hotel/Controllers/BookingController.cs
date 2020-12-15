using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookings _bookings;
        public BookingController(IBookings bookings)
        {
            _bookings = bookings;
        }

        [HttpGet]
        [Route("api/[controller]/{bookingid}")]
        public IActionResult GetBookings(Guid bookingid)
        {
            var bookings = _bookings.GetBookings(bookingid);
            if (bookings != null)
            {
                return Ok(bookings);
            }
            return NotFound($"Booking with id: {bookingid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetBookings(Bookings bookings)
        {
            _bookings.AddBookings(bookings);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + bookings.BookingID, bookings);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public IActionResult DeleteBookings(Guid bookingid)
        {
            var bookings = _bookings.GetBookings(bookingid);
            if (bookingid != null)
            {
                _bookings.DeleteBookings(bookings);
                return Ok();
            }
            return NotFound($"Guests with id: {bookingid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditGuests(Guid bookingid, Bookings bookings)
        {
            var exitingguests = _bookings.GetBookings(bookingid);
            if (exitingguests != null)
            {
                bookings.BookingID = exitingguests.BookingID;
                _bookings.EditBookings(bookings);
            }
            return Ok(bookings);
        }
    }
}
