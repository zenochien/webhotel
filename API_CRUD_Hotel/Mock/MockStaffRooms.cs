using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CRUD_Hotel.Mock
{
    public class MockStaffRooms : IStaffRooms
    {
        private List<StaffRooms> staffRooms = new List<StaffRooms>()
        {
            new StaffRooms()
            {
                StaffID=Guid.NewGuid(),
                RoomID=Guid.NewGuid(),
                StaffRoomID=Guid.NewGuid()
            },
            new StaffRooms()
            {
                StaffID=Guid.NewGuid(),
                RoomID=Guid.NewGuid(),
                StaffRoomID=Guid.NewGuid()
            }
        };
        public StaffRooms AddStaffRooms(StaffRooms StaffRooms)
        {
            StaffRooms.StaffRoomID = Guid.NewGuid();
            staffRooms.Add(StaffRooms);
            return StaffRooms;
        }

        public void DeleteStaffRooms(StaffRooms StaffRooms)
        {
            staffRooms.Remove(StaffRooms);
        }

        public StaffRooms EditStaffRooms(StaffRooms StaffRooms)
        {
            var existingStaffRooms = GetStaffRooms(StaffRooms.StaffRoomID);
            existingStaffRooms.StaffRoomID = StaffRooms.StaffRoomID;
            return StaffRooms;
        }

        public List<StaffRooms> GetStaffRooms()
        {
            return staffRooms;
        }

        public StaffRooms GetStaffRooms(Guid StaffRoomID)
        {
            return staffRooms.SingleOrDefault(x => x.StaffRoomID == StaffRoomID);
        }
    }
}
