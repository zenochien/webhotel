using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CRUD_Hotel.Sql
{
    public class SqlStaffRooms : IStaffRooms
    {
        private HotelsDbContext _hotelDbContext;
        public SqlStaffRooms(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public StaffRooms AddStaffRooms(StaffRooms StaffRooms)
        {
            StaffRooms.StaffRoomID = Guid.NewGuid();
            _hotelDbContext.staffRooms.Add(StaffRooms);
            _hotelDbContext.SaveChanges();
            return StaffRooms;
        }

        public void DeleteStaffRooms(StaffRooms StaffRooms)
        {
            _hotelDbContext.staffRooms.Remove(StaffRooms);
            _hotelDbContext.SaveChanges();
        }

        public StaffRooms EditStaffRooms(StaffRooms StaffRooms)
        {
            var existingStaffRooms = _hotelDbContext.staffRooms.Find(StaffRooms.StaffRoomID);
            if (existingStaffRooms != null)
            {
                _hotelDbContext.staffRooms.Update(StaffRooms);
                _hotelDbContext.SaveChanges();
            }
            return StaffRooms;
        }

        public List<StaffRooms> GetStaffRooms()
        {
            return _hotelDbContext.staffRooms.ToList();
        }

        public StaffRooms GetStaffRooms(Guid StaffRoomID)
        {
            var staffRooms = _hotelDbContext.staffRooms.Find(StaffRoomID);
            return staffRooms;
        }
    }
}
