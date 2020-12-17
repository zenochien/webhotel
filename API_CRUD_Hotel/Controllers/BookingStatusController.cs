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
    public class BookingStatusController : ControllerBase
    {
        private readonly IBookingStatus _bookingStatus;
        public BookingStatusController(IBookingStatus bookingStatus)
        {
            _bookingStatus = bookingStatus;
        }

        [HttpGet]
        [Route("api/[controller]/{bookingstatusid}")]
        public IActionResult GetBookingStatus(Guid bookingstatusid)
        {
            var bookingstatus = _bookingStatus.GetBookingStatus(bookingstatusid);
            if (bookingstatus != null)
            {
                return Ok(bookingstatus);
            }
            return NotFound($"Booking Status with id: {bookingstatusid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetBookingStatus(BookingStatus bookingStatus)
        {
            _bookingStatus.AddBookingStatus(bookingStatus);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + bookingStatus.BookingStatusID, bookingStatus);
        }

        [HttpDelete]
        [Route("api/[controller]/{bookingstatusid}")]
        public IActionResult DeleteBookingStatus(Guid bookingstatusid)
        {
            var bookingstatus = _bookingStatus.GetBookingStatus(bookingstatusid);
            if (bookingstatusid != null)
            {
                _bookingStatus.DeleteBookingStatus(bookingstatus);
                return Ok();
            }
            return NotFound($"Guests with id: {bookingstatusid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{bookingstatusid}")]
        public IActionResult EditBookingStatus(Guid bookingstatusid, BookingStatus bookingstatus)
        {
            var existBS = _bookingStatus.GetBookingStatus(bookingstatusid);
            if (existBS != null)
            {
                bookingstatus.BookingStatusID = existBS.BookingStatusID;
                _bookingStatus.EditBookingStatus(bookingstatus);
            }
            return Ok(bookingstatus);
        }
    }
}
