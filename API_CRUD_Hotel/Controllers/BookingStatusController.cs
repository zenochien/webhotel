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
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/{bookingstatusid}")]
        public IActionResult GetBookingStatus(Guid bookingstatusid)
        {
            var bookingStatus = _bookingStatus.GetBookingStatusWithId(bookingstatusid);
            if (bookingStatus != null)
            {
                return Ok(bookingStatus);
            }
            return NotFound($"Booking Status with id: {bookingstatusid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetBookingStatus(BookingStatus bookingStatus)
        {
            var result = await _bookingStatus.AddBookingAsync(bookingStatus);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.BookingStatusID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{bookingstatusid}")]
        public async Task<IActionResult> DeleteBookingStatus(Guid bookingstatusid)
        {
            var bookingstatus = _bookingStatus.GetBookingStatusWithId(bookingstatusid);
            if (bookingstatusid != null)
            {
                return Ok(await _bookingStatus.DeleteBookingStatusAsync(bookingstatus));
               
            }
            return NotFound($"Guests with id: {bookingstatusid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{bookingstatusid}")]
        public async Task<IActionResult> EditBookingStatus(Guid bookingstatusid, BookingStatus bookingstatus)
        {
            bookingstatus.BookingStatusID = bookingstatusid;
               return Ok( await _bookingStatus.UpdateBookingStatusAsync(bookingstatus));
        }
    }
}
