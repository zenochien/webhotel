using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Controllers
{
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositions _positions;
        public PositionsController(IPositions positions)
        {
            _positions = positions;
        }

        [HttpGet]
        [Route("api/[controller]/{positionid}")]
        public IActionResult GetBookings(Guid positionid)
        {
            var positions = _positions.GetPositions(positionid);
            if (positions != null)
            {
                return Ok(positions);
            }
            return NotFound($"Position with id: {positionid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetBookings(Positions positions)
        {
            var resul = await _positions.AddPositionsAsync(positions);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + resul.PositionID, resul);
        }

        [HttpDelete]
        [Route("api/[controller]/{positionid}")]
        public async Task<IActionResult> DeletePosition(Guid positionid)
        {
            var positions = _positions.GetPositions(positionid);
            if (positionid != null)
            {

                return Ok(await _positions.DeletePositionsAsync(positions));
            }
            return NotFound($"Positions with id: {positionid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{positionid}")]
        public async Task<IActionResult> EditGuests(Guid positionid, Positions positions)
        {

            positions.PositionID = positionid;
            return Ok(await _positions.UpdatePositions(positions));

        }
    }
}
