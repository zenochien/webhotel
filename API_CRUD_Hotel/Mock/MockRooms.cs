using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockRooms : IRooms
    {
        private List<Rooms> Room = new List<Rooms>()
        {
            new Rooms()
            {
                RoomsID=Guid.NewGuid(),
                HotelID=Guid.NewGuid(),
                Floor="5",
                RoomTypeID=Guid.NewGuid(),
                RoomNumber="123",
                Desription="abc",
                RoomStatusID=Guid.NewGuid()
            },
            new Rooms()
            {
                RoomsID=Guid.NewGuid(),
                HotelID=Guid.NewGuid(),
                Floor="3",
                RoomTypeID=Guid.NewGuid(),
                RoomNumber="123",
                Desription="abc",
                RoomStatusID=Guid.NewGuid()
            }
        };
        
        public Rooms AddRooms(Rooms Rooms)
        {
            Rooms.RoomsID = Guid.NewGuid();
            Room.Add(Rooms);
            return Rooms;
        }

        public void DeleteRooms(Rooms Rooms)
        {
            Room.Remove(Rooms);
        }

        public Rooms EditRooms(Rooms Rooms)
        {
            var existingRooms = GetRooms(Rooms.RoomsID);
            existingRooms.RoomNumber = Rooms.RoomNumber;
            return existingRooms;
        }

        public List<Rooms> GetRooms()
        {
            return Room;
        }

        public Rooms GetRooms(Guid RoomsID)
        {
            return Room.SingleOrDefault(x => x.RoomsID == RoomsID);
        }
    }
}
