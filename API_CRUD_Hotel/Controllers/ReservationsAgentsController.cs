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
    public class ReservationsAgentsController : ControllerBase
    {
        private readonly IReservationAgents _reservationAgents;
        public ReservationsAgentsController(IReservationAgents reservationAgents)
        {
            _reservationAgents = reservationAgents;
        }
        [HttpGet]
        [Route("api/[controller]/{reservationAgentid}")]
        public IActionResult GetReservationAgents(Guid reservationAgentid)
        {
            var reservationAgents = _reservationAgents.GetReservationAgents(reservationAgentid);
            if (reservationAgents != null)
            {
                return Ok(reservationAgents);
            }
            return NotFound($"Reservation agent with id: {reservationAgentid} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetReservationAgents(ReservationAgents reservationAgents)
        {
           var result = await _reservationAgents.AddReservationAgentsAsync(reservationAgents);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + result.ReservationAgentID, result);
        }

        [HttpDelete]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> DeleteReservationAgents(Guid aeservationagentsid)
        {
            var reservationAgents = _reservationAgents.GetReservationAgents(aeservationagentsid);
            if (aeservationagentsid != null)
            {
                return Ok(await _reservationAgents.DeleteReservationAgentsAsync(reservationAgents));
            }
            return NotFound($"Guests with id: {aeservationagentsid} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{guestid}")]
        public async Task<IActionResult> EditReservationAgents(Guid aeservationagentsid, ReservationAgents reservationAgents)
        {
            reservationAgents.ReservationAgentID = aeservationagentsid;
            return Ok(await _reservationAgents.UpdateReservationAgentsAsync(reservationAgents));
        }
    }
}
