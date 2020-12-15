using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRooms
    {
        List<Rooms> GetRooms();
        Rooms GetRooms(Guid RoomsID);
        Rooms AddRooms(Rooms Rooms);
        void DeleteRooms(Rooms Rooms);
        Rooms EditRooms(Rooms Rooms);
    }
}
