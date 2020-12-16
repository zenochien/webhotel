using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRoomsBooked : Repositories.IRepository<RoomsBooked>
    {
        IEnumerable<RoomsBooked> GetRoomsBookeds();
        RoomsBooked GetRoomsBooked(Guid RoomsBookedID);
        Task<RoomsBooked> AddRoomsBookedAsync(RoomsBooked roomsBooked, CancellationToken cancellationToken = default);
        Task<bool> DeleteRoomBookedsAsync(RoomsBooked roomsBooked, CancellationToken cancellationToken = default);
        Task<RoomsBooked> UpdateRoomBookeds(RoomsBooked roomsBooked, CancellationToken cancellationToken = default);
    }
}
