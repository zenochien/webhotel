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
        public async Task<IActionResult> GetRateTypes(RateTypes rateTypes)
        {
           var result = await _rateTypes.AddRateTypesAsync(rateTypes);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.RateTypeID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{ratetypeid}")]
        public IActionResult DeleteRateTypes(Guid ratetypeid)
        {
            var rateTypes = _rateTypes.GetRateTypes(ratetypeid);
            if (ratetypeid != null)
            {                
                return Ok(_rateTypes.DeleteRateTypesAsync(rateTypes));
            }
            return NotFound($"Rate Types with id: {ratetypeid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditRateTypes(Guid ratetypeid, RateTypes rateTypes)
        {
          
                rateTypes.RateTypeID = ratetypeid;
               return Ok(await _rateTypes.UpdateRateTypesAsync(rateTypes));
           
        }
    }
}
