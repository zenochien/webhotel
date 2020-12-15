using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockStaff : IStaff
    {
        private List<Staff> staffs = new List<Staff>()
        {
            new Staff()
            {
            StaffID = Guid.NewGuid(),
            FirstName = "Anh",
            LastName = "Nguyễn Văn",
            Address = "20 Thông Nhất",
            Address2 = "43 Nguyễn Thị Sáu",
            City = "Hồ Chí Minh",
            State = "?",
            ZipCOde = "007",
            Country = "VietNam",
            HomePhoneNumber = "0123456789",
            CellularNumber = "0123456789",
            eMailAddress = "nguyenvananh@mail.com",
            Gender = "Vietnam"
            },
            new Staff()
            {
            StaffID = Guid.NewGuid(),
            FirstName = "Anh",
            LastName = "Nguyễn Văn",
            Address = "20 Thông Nhất",
            Address2 = "43 Nguyễn Thị Sáu",
            City = "Hồ Chí Minh",
            State = "?",
            ZipCOde = "007",
            Country = "VietNam",
            HomePhoneNumber = "0123456789",
            CellularNumber = "0123456789",
            eMailAddress = "nguyenvananh@mail.com",
            Gender = "Vietnam"
            }
        };

        public Staff AddStaff(Staff Staff)
        {
            Staff.StaffID = Guid.NewGuid();
            staffs.Add(Staff);
            return Staff;
        }

        public void DeleteStaff(Staff Staff)
        {
            staffs.Remove(Staff);
        }

        public Staff EditStaff(Staff Staff)
        {
            var existingStaff = GetStaff(Staff.StaffID);
            existingStaff.FirstName = Staff.FirstName;
            return existingStaff;
        }

        public List<Staff> GetStaff()
        {
            return staffs;
        }

        public Staff GetStaff(Guid StaffID)
        {
            return staffs.SingleOrDefault(x => x.StaffID == StaffID);
        }
    }
}
