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
    public class HotelsController : ControllerBase
    {
        private readonly IHotels _hotels;
        public HotelsController(IHotels hotels)
        {
            _hotels = hotels;
        }

        [HttpGet]
        [Route("api/[controller]/{hotelid}")]
        public IActionResult GetHotels(Guid HotelID)
        {
            var hotels = _hotels.GetHotels(HotelID);
            if (hotels != null)
            {
                return Ok(hotels);
            }
            return NotFound($"Hotels with id: {HotelID} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetHotels(Hotels hotels)
        {
            _hotels.AddHotels(hotels);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + hotels.HotelID, hotels);
        }

        [HttpDelete]
        [Route("api/[controller]/{hotelid}")]
        public IActionResult DeleteHotels(Guid hotelid)
        {
            var hotels = _hotels.GetHotels(hotelid);
            if (hotelid != null)
            {
                _hotels.DeleteHotelsAsync(hotels);
                return Ok();
            }
            return NotFound($"Hotels with id: {hotelid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{hotelid}")]
        public IActionResult EditHotels(Guid hotelid, Hotels hotels)
        {
            var existingHotels = _hotels.GetHotels(hotelid);
            if (existingHotels != null)
            {
                hotels.HotelID = existingHotels.HotelID;
                _hotels.UpdateHotelsAsync(hotels);
            }
            return Ok(hotels);
        }
    }
}
