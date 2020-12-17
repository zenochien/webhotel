using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRoomsBooked
    {
        List<RoomsBooked> GetRoomsBookeds();
        RoomsBooked GetRoomsBooked(Guid RoomsBookedID);
        RoomsBooked AddRoomsBooked(RoomsBooked roomsBooked);
        void DeleteRB(RoomsBooked roomsBooked);
        RoomsBooked EditRB(RoomsBooked roomsBooked);
    }
}
