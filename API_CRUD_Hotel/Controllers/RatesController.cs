using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetRates(Rates rates)
        {
            var result = await _rates.AddRatesAsync(rates);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.RateID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> DeleteRates(Guid rateid)
        {
            var rates = _rates.GetRates(rateid);
            if (rateid != null)
            {

                return Ok(await _rates.DeleteRatesAsync(rates));
            }
            return NotFound($"Rates with id: {rateid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditGuests(Guid ratesid, Rates rates)
        {
            rates.RateID = ratesid;
            return Ok(await _rates.UpdateRatesAsync(rates));

        }
    }
}
