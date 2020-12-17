using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
   public interface IRoomTypes
    {
        List<RoomTypes> GetRoomTypes();
        RoomTypes GetRoomTypes(Guid RoomTypesID);
        RoomTypes AddRoomTypes(RoomTypes roomTypes);
        void DeleteRoomTypes(RoomTypes roomTypes);
        RoomTypes EditRoomTypes(RoomTypes roomTypes);
    }
}
