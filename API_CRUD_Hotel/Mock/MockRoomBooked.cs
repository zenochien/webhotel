using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockRoomBooked : IRoomsBooked
    {
        private List<RoomsBooked> rooms = new List<RoomsBooked>()
         {
             new RoomsBooked()
             {
                 RoomBookedID=Guid.NewGuid(),
                 BookingID=Guid.NewGuid(),
                 RoomID=Guid.NewGuid(),
                 Rate=10
             },
              new RoomsBooked()
             {
                 RoomBookedID=Guid.NewGuid(),
                 BookingID=Guid.NewGuid(),
                 RoomID=Guid.NewGuid(),
                 Rate=5
             }
         }; 
        public List<RoomsBooked> GetRoomsBookeds()
        {
            return rooms;
        }

        public RoomsBooked GetRoomsBooked(Guid RoomsBookedID)
        {
            return rooms.SingleOrDefault(x => x.RoomBookedID == RoomsBookedID);
        }

        public RoomsBooked AddRoomsBooked(RoomsBooked roomsBooked)
        {
            roomsBooked.RoomBookedID = Guid.NewGuid();
            rooms.Add(roomsBooked);
            return roomsBooked;
        }

        public void DeleteRB(RoomsBooked roomsBooked)
        {
            rooms.Remove(roomsBooked);
        }

        public RoomsBooked EditRB(RoomsBooked roomsBooked)
        {
            var existingRB = GetRoomsBooked(roomsBooked.RoomBookedID);
            existingRB.Rooms = roomsBooked.Rooms;
            return existingRB;
        }

    }
}
