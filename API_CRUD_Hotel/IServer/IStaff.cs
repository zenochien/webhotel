using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IStaff : Repositories.IRepository<Rates>
    {
        IEnumerable<Rates> GetStaffs();
        Rates GetStaffs(Guid StaffID);
        Task<Rates> AddStaffAsync(Rates staff, CancellationToken cancellationToken = default);
        Task<bool> DeleteStaffAsync(Rates staff, CancellationToken cancellationToken = default);
        Task<Rates> UpdateStaffAsync(Rates staff, CancellationToken cancellationToken = default);
    }
}
