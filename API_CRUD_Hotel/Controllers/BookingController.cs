using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _repository;

        public BookingController(IBookingRepository bookings)
        {
            _repository = bookings;
        }

        [HttpGet]
        [Route("api/[controller]/{bookingid}")]
        public IActionResult GetBookings(Guid bookingid)
        {
            var bookings = _repository.GetBooking(bookingid);
            if (bookings != null)
            {
                return Ok(bookings);
            }
            return NotFound($"Booking with id: {bookingid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetBookings(Booking bookings)
        {
            var result = await _repository.AddBookingAsync(bookings);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.BookingID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> DeleteBookings(Guid bookingid)
        {
            var bookings = _repository.GetBooking(bookingid);
            if (bookingid != null)
            {
                return Ok(await _repository.DeleteBookingAsync(bookings));
            }
            return NotFound($"Guests with id: {bookingid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditGuests(Guid bookingid, Booking bookings)
        {
            bookings.BookingID = bookingid;
            return Ok(await _repository.UpdateBookingAsync(bookings)); // lay ham dau
        }
    }
}