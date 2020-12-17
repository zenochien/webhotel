using API_CRUD_Hotel.IServer;
using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRAData : BaseRepository<ReservationAgents>, IReservationAgents
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRAData(HotelsDbContext hotelsDbContext) :  base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<ReservationAgents> AddReservationAgentsAsync(ReservationAgents reservationAgents, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(reservationAgents, cencellationToken);
        }

        public async Task<bool> DeleteReservationAgentsAsync(ReservationAgents reservationAgents, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(reservationAgents);
        }

        public IEnumerable<ReservationAgents> GetReservationAgents()
        {
            return this.GetAll();
        }

        public ReservationAgents GetReservationAgents(Guid ReservationAgentID)
        {
            return base.GetById(ReservationAgentID);
        }

        public async Task<ReservationAgents> UpdateReservationAgentsAsync(ReservationAgents reservationAgents, CancellationToken cencellationToken = default)
        {
            var existingRA = _hotelDbContext.reservationAgents.FirstOrDefault(x => x.ReservationAgentID == reservationAgents.ReservationAgentID);
            if (existingRA != null)
            {
                _hotelDbContext.reservationAgents.Update(existingRA);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingRA;
        }
    }
}
