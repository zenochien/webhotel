using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IReservationAgents : Repositories.IRepository<ReservationAgents>
    {
        IEnumerable<ReservationAgents> GetReservationAgents();
        ReservationAgents GetReservationAgents(Guid ReservationAgentID);
        Task<ReservationAgents> AddReservationAgentsAsync(ReservationAgents reservationAgents, CancellationToken cencellationToken = default);
        Task<bool> DeleteReservationAgentsAsync(ReservationAgents reservationAgents, CancellationToken cencellationToken = default);
        Task<ReservationAgents> UpdateReservationAgentsAsync(ReservationAgents reservationAgents, CancellationToken cencellationToken = default);
    }
}
