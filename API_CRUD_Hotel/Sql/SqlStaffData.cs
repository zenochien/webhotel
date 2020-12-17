using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlStaffData : IStaff
    {
        private HotelsDbContext _hotelDbContext;
        public SqlStaffData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Staff AddStaff(Staff Staff)
        {
            Staff.StaffID = Guid.NewGuid();
            _hotelDbContext.staffs.Add(Staff);
            _hotelDbContext.SaveChanges();
            return Staff;
        }

        public void DeleteStaff(Staff Staff)
        {
            _hotelDbContext.staffs.Remove(Staff);
            _hotelDbContext.SaveChanges();
        }

        public Staff EditStaff(Staff Staff)
        {
            var existingStaff = _hotelDbContext.staffs.Find(Staff.StaffID);
            if(existingStaff != null)
            {
                _hotelDbContext.staffs.Update(Staff);
                _hotelDbContext.SaveChanges();
            }
            return Staff;
        }

        public List<Staff> GetStaff()
        {
            return _hotelDbContext.staffs.ToList();
        }

        public Staff GetStaff(Guid StaffID)
        {
            var staff = _hotelDbContext.staffs.Find(StaffID);
            return staff;
        }
    }
}
