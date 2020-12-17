using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IReservationAgents
    {
        List<ReservationAgents> GetReservationAgents();
        ReservationAgents GetReservationAgents(Guid ReservationAgentID);
        ReservationAgents AddReservationAgents(ReservationAgents reservationAgents);
        void DeleteReservationAgents(ReservationAgents reservationAgents);
        ReservationAgents EditReservationAgents(ReservationAgents reservationAgents);
    }
}
