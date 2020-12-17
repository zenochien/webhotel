using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRoomTypesData : IRoomTypes
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRoomTypesData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public RoomTypes AddRoomTypes(RoomTypes roomTypes)
        {
            roomTypes.RoomTypeID = Guid.NewGuid();
            _hotelDbContext.roomTypes.Add(roomTypes);
            _hotelDbContext.SaveChanges();
            return roomTypes;
        }

        public void DeleteRoomTypes(RoomTypes roomTypes)
        {
            _hotelDbContext.roomTypes.Remove(roomTypes);
            _hotelDbContext.SaveChanges();
        }

        public RoomTypes EditRoomTypes(RoomTypes roomTypes)
        {
            var existingRoomTypes = _hotelDbContext.roomTypes.Find(roomTypes.RoomTypeID);
            if(existingRoomTypes!=null)
            {
                _hotelDbContext.roomTypes.Update(roomTypes);
                _hotelDbContext.SaveChanges();
            }
            return roomTypes;
        }

        public List<RoomTypes> GetRoomTypes()
        {
            return _hotelDbContext.roomTypes.ToList();
        }

        public RoomTypes GetRoomTypes(Guid RoomTypesID)
        {
            var roomTypes = _hotelDbContext.roomTypes.Find(RoomTypesID);
            return roomTypes;
        }
    }
}
