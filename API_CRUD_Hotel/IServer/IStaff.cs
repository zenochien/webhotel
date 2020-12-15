using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;

namespace API_CRUD_Hotel.IServer
{
    public interface IStaff
    {
        List<Staff> GetStaff();
        Staff GetStaff(Guid StaffID);
        Staff AddStaff(Staff Staff);
        void DeleteStaff(Staff Staff);
        Staff EditStaff(Staff Staff);
    }
}
