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
    public class RateTypesController : ControllerBase
    {
        private readonly IRateTypes _rateTypes;
        public RateTypesController(IRateTypes rateTypes)
        {
            _rateTypes = rateTypes;
        }

        [HttpGet]
        [Route("api/[controller]/{bookingid}")]
        public IActionResult GetBookings(Guid ratetypeid)
        {
            var rateTypes = _rateTypes.GetRateTypes(ratetypeid);
            if (rateTypes != null)
            {
                return Ok(rateTypes);
            }
            return NotFound($"Rate Types with id: {ratetypeid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetRateTypes(RateTypes rateTypes)
        {
            _rateTypes.AddRateTypes(rateTypes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + rateTypes.RateTypeID, rateTypes);
        }

        [HttpDelete]
        [Route("api/[controller]/{ratetypeid}")]
        public IActionResult DeleteRateTypes(Guid ratetypeid)
        {
            var rateTypes = _rateTypes.GetRateTypes(ratetypeid);
            if (ratetypeid != null)
            {
                _rateTypes.DeleteRateTypes(rateTypes);
                return Ok();
            }
            return NotFound($"Rate Types with id: {ratetypeid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditRateTypes(Guid ratetypeid, RateTypes rateTypes)
        {
            var existingRateTypes = _rateTypes.GetRateTypes(ratetypeid);
            if (existingRateTypes != null)
            {
                rateTypes.RateTypeID = existingRateTypes.RateTypeID;
                _rateTypes.EditRateTypes(rateTypes);
            }
            return Ok(rateTypes);
        }
    }
}
