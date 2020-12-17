using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
   public interface IRoomTypes: IRepository<RoomTypes>
    {
        IEnumerable<RoomTypes> GetRoomTypes();
        RoomTypes GetRoomTypes(Guid RoomTypesID);
        Task<RoomTypes> AddRoomTypesAsync(RoomTypes roomTypes, CancellationToken cancellationToken=default);
        Task<bool> DeleteRoomTypesAsync(RoomTypes roomTypes, CancellationToken cancellationToken=default);
        Task<RoomTypes> UpdateRoomTypesAsync(RoomTypes roomTypes, CancellationToken cancellationToken = default);
    }
}
