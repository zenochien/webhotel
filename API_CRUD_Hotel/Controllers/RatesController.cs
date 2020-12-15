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
    public class RatesController : ControllerBase
    {
        private readonly IRates _rates;
        public RatesController(IRates rates)
        {
            _rates = rates;
        }

        [HttpGet]
        [Route("api/[controller]/{rateid}")]
        public IActionResult GetRates(Guid rateid)
        {
            var rates = _rates.GetRates(rateid);
            if (rates != null)
            {
                return Ok(rates);
            }
            return NotFound($"Rates with id: {rateid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetRates(Rates rates)
        {
            _rates.AddRates(rates);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + rates.RateID, rates);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public IActionResult DeleteRates(Guid rateid)
        {
            var rates = _rates.GetRates(rateid);
            if (rateid != null)
            {
                _rates.DeleteRates(rates);
                return Ok();
            }
            return NotFound($"Rates with id: {rateid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public IActionResult EditGuests(Guid ratesid, Rates rates)
        {
            var existingRates = _rates.GetRates(ratesid);
            if (existingRates != null)
            {
                rates.RateID = existingRates.RateID;
                _rates.EditRates(rates);
            }
            return Ok(ratesid);
        }
    }  
}
