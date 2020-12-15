using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRoomStatus
    {
        List<RoomStatus> GetRoomStatus();
        RoomStatus GetRoomStatus(Guid RoomStatusID);
        RoomStatus AddRoomStatus(RoomStatus roomStatus);
        void DeleteRoomStatus(RoomStatus roomStatus);
        RoomStatus EditRoomStatus(RoomStatus roomStatus);
    }
}
