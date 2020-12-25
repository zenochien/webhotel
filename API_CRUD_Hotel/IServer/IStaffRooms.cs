using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
   public interface IStaffRooms: IRepository<StaffRooms>
    {
        IEnumerable<StaffRooms> GetAllStaffRooms();
        StaffRooms GetStaffRooms(Guid StaffRoomID);
        Task<StaffRooms> AddStaffRoomsAsync(StaffRooms StaffRooms, CancellationToken cancellationToken=default);
        Task<bool> DeleteStaffRoomsAsync(StaffRooms StaffRooms, CancellationToken cancellationToken = default);
        Task<StaffRooms> UpdateStaffRoomsAsync(StaffRooms StaffRooms, CancellationToken cancellationToken = default);
    }
}
