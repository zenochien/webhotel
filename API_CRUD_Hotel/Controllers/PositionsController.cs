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
        public IActionResult GetBookings(Positions positions)
        {
            _positions.AddPositions(positions);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + positions.PositionID, positions);
        }

        [HttpDelete]
        [Route("api/[controller]/{positionid}")]
        public IActionResult DeletePosition(Guid positionid)
        {
            var positions = _positions.GetPositions(positionid);
            if (positionid != null)
            {
                _positions.DeletePositions(positions);
                return Ok();
            }
            return NotFound($"Positions with id: {positionid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{positionid}")]
        public IActionResult EditGuests(Guid positionid, Positions positions)
        {
            var existingPosition = _positions.GetPositions(positionid);
            if (existingPosition != null)
            {
                positions.PositionID = existingPosition.PositionID;
                _positions.EditPositions(positions);
            }
            return Ok(positions);
        }
    }
}
