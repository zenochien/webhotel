using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IStaff : IRepository<Staff>
    {
        IEnumerable<Staff> GetAllStaffs();
        Staff GetStaffs(Guid StaffID);
        Task<Staff> AddStaffAsync(Staff staff, CancellationToken cancellationToken = default);
        Task<bool> DeleteStaffAsync(Staff staff, CancellationToken cancellationToken = default);
        Task<Staff> UpdateStaffAsync(Staff staff, CancellationToken cancellationToken = default);
    }
}
