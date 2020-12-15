using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRoomsData : IRooms
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRoomsData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Rooms AddRooms(Rooms Rooms)
        {
            Rooms.RoomsID = Guid.NewGuid();
            _hotelDbContext.rooms.Add(Rooms);
            _hotelDbContext.SaveChanges();
            return Rooms;
        }

        public void DeleteRooms(Rooms Rooms)
        {
            _hotelDbContext.rooms.Remove(Rooms);
            _hotelDbContext.SaveChanges();
        }

        public Rooms EditRooms(Rooms Rooms)
        {
            var existingRooms = _hotelDbContext.rooms.Find(Rooms.RoomsID);
            if (existingRooms != null)
            {
                _hotelDbContext.rooms.Update(Rooms);
                _hotelDbContext.SaveChanges();
            }
            return Rooms;
        }

        public List<Rooms> GetRooms()
        {
            return _hotelDbContext.rooms.ToList();
        }

        public Rooms GetRooms(Guid RoomsID)
        {
            var rooms = _hotelDbContext.rooms.Find(RoomsID);
            return rooms;
        }
    }
}
