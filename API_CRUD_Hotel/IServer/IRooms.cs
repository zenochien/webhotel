using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRooms : IRepository<Rooms>
    {
        IEnumerable<Rooms> GetRooms();
        Rooms GetRooms(Guid RoomsID);
        Task<Rooms> AddRoomsAsync(Rooms Rooms, CancellationToken cencellationToken=default);
        Task<bool> DeleteRoomsAsync(Rooms Rooms, CancellationToken cencellationToken = default);
        Task<Rooms> UpdateRoomsAsync(Rooms Rooms, CancellationToken cencellationToken = default);
    }
}
