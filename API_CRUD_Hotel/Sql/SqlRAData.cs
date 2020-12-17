using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRAData : IReservationAgents
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRAData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public ReservationAgents AddReservationAgents(ReservationAgents reservationAgents)
        {
            reservationAgents.ReservationAgentID = Guid.NewGuid();
            _hotelDbContext.reservationAgents.Add(reservationAgents);
            _hotelDbContext.SaveChanges();
            return reservationAgents;
        }

        public void DeleteReservationAgents(ReservationAgents reservationAgents)
        {
            _hotelDbContext.reservationAgents.Remove(reservationAgents);
            _hotelDbContext.SaveChanges();
        }

        public ReservationAgents EditReservationAgents(ReservationAgents reservationAgents)
        {
            var existRA = _hotelDbContext.reservationAgents.Find(reservationAgents.ReservationAgentID);
            if(existRA!=null)
            {
                _hotelDbContext.reservationAgents.Update(existRA);
                _hotelDbContext.SaveChanges();
            }
            return reservationAgents;
        }

        public List<ReservationAgents> GetReservationAgents()
        {
            return _hotelDbContext.reservationAgents.ToList();
        }

        public ReservationAgents GetReservationAgents(Guid ReservationAgentID)
        {
            var reservationAgents = _hotelDbContext.reservationAgents.Find(ReservationAgentID);
            return reservationAgents;
        }
    }
}
