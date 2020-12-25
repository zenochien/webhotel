using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRoomStatus : IRepository<RoomStatus>
    {
        IEnumerable<RoomStatus> GetAllRoomStatus();
        RoomStatus GetRoomStatus(Guid RoomStatusID);
        Task<RoomStatus> AddRoomStatusAsync(RoomStatus roomStatus, CancellationToken cancellationToken = default);
        Task<bool> DeleteRoomStatusAsync(RoomStatus roomStatus, CancellationToken cancellationToken = default);
        Task<RoomStatus> UpdateRoomStatusAsync(RoomStatus roomStatus, CancellationToken cancellationToken = default);
    }
}
