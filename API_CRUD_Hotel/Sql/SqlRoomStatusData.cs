using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRoomStatusData : IRoomStatus
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRoomStatusData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public RoomStatus AddRoomStatus(RoomStatus roomStatus)
        {
            roomStatus.RoomStatusID = Guid.NewGuid();
            _hotelDbContext.roomStatuses.Add(roomStatus);
            _hotelDbContext.SaveChanges();
            return roomStatus;
        }

        public void DeleteRoomStatus(RoomStatus roomStatus)
        {
            _hotelDbContext.roomStatuses.Remove(roomStatus);
            _hotelDbContext.SaveChanges();
        }

        public RoomStatus EditRoomStatus(RoomStatus roomStatus)
        {
            var existingRoomStatus = _hotelDbContext.roomStatuses.Find(roomStatus.RoomStatusID);
            if (existingRoomStatus != null)
            {
                _hotelDbContext.roomStatuses.Update(roomStatus);
                _hotelDbContext.SaveChanges();
            }
            return roomStatus;
        }

        public List<RoomStatus> GetRoomStatus()
        {
            return _hotelDbContext.roomStatuses.ToList();
        }

        public RoomStatus GetRoomStatus(Guid RoomStatusID)
        {
            var roomStatus = _hotelDbContext.roomStatuses.Find(RoomStatusID);
            return roomStatus;
        }
    }
}
