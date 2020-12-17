using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockRoomStatus : IRoomStatus
    {
        private List<RoomStatus> roomStatuses = new List<RoomStatus>()
        {
            new RoomStatus()
            {
                RoomStatusID=Guid.NewGuid(),
                RoomsStatus="vip",
                Description="sss",
                SortOrder="123",
                Active="có"
            },
            new RoomStatus()
            {
                RoomStatusID=Guid.NewGuid(),
                RoomsStatus="vip",
                Description="sss",
                SortOrder="123",
                Active="có"
            }
        };

        public RoomStatus AddRoomStatus(RoomStatus roomStatus)
        {
            roomStatus.RoomStatusID = Guid.NewGuid();
            roomStatuses.Add(roomStatus);
            return roomStatus;
        }

        public void DeleteRoomStatus(RoomStatus roomStatus)
        {
            roomStatuses.Remove(roomStatus);
        }

        public RoomStatus EditRoomStatus(RoomStatus roomStatus)
        {
            var existingRoomStatus = GetRoomStatus(roomStatus.RoomStatusID);
            existingRoomStatus.RoomStatusID = roomStatus.RoomStatusID;
            return existingRoomStatus;
        }

        public List<RoomStatus> GetRoomStatus()
        {
            return roomStatuses;
        }

        public RoomStatus GetRoomStatus(Guid RoomStatusID)
        {
            return roomStatuses.SingleOrDefault(x => x.RoomStatusID == RoomStatusID);
        }
    }
}
