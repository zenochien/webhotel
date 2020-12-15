using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
   public interface IStaffRooms
    {
        List<StaffRooms> GetStaffRooms();
        StaffRooms GetStaffRooms(Guid StaffRoomID);
        StaffRooms AddStaffRooms(StaffRooms StaffRooms);
        void DeleteStaffRooms(StaffRooms StaffRooms);
        StaffRooms EditStaffRooms(StaffRooms StaffRooms);
    }
}
