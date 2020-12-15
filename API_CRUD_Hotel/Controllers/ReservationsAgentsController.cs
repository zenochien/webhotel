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
        public IActionResult GetReservationAgents(ReservationAgents reservationAgents)
        {
            _reservationAgents.AddReservationAgents(reservationAgents);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + reservationAgents.ReservationAgentID, reservationAgents);
        }
    }
}
