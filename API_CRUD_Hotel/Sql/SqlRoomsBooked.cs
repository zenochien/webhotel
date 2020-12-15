using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRoomsBooked : IRoomsBooked
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRoomsBooked(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }
        public RoomsBooked AddRoomsBooked(RoomsBooked roomsBooked)
        {
            roomsBooked.RoomBookedID = Guid.NewGuid();
            _hotelDbContext.roomsBookeds.Add(roomsBooked);
            _hotelDbContext.SaveChanges();
            return roomsBooked;
        }

        public void DeleteRB(RoomsBooked roomsBooked)
        {
            _hotelDbContext.roomsBookeds.Remove(roomsBooked);
            _hotelDbContext.SaveChanges();
        }

        public RoomsBooked EditRB(RoomsBooked roomsBooked)
        {
            var existingRoomsBooked = _hotelDbContext.roomsBookeds.Find(roomsBooked.RoomBookedID);
            if (existingRoomsBooked != null)
            {
                _hotelDbContext.roomsBookeds.Update(roomsBooked);
                _hotelDbContext.SaveChanges();
            }
            return roomsBooked;
        }

        public RoomsBooked GetRoomsBooked(Guid RoomsBookedID)
        {
            var roomsBooked = _hotelDbContext.roomsBookeds.Find(RoomsBookedID);
            return roomsBooked;
        }

        public List<RoomsBooked> GetRoomsBookeds()
        {
            return _hotelDbContext.roomsBookeds.ToList();
        }
    }
}
