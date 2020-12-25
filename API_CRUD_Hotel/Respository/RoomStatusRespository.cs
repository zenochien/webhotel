using API_CRUD_Hotel.IServer;
using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class RoomStatusRespository : BaseRepository<RoomStatus>, IRoomStatus
    {
        private HotelsDbContext _hotelDbContext;
        public RoomStatusRespository(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<RoomStatus> AddRoomStatusAsync(RoomStatus roomStatus, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(roomStatus, cancellationToken);
        }

        public async Task<bool> DeleteRoomStatusAsync(RoomStatus roomStatus, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(roomStatus);
        }

        public IEnumerable<RoomStatus> GetAllRoomStatus()
        {
            return this.GetAll();
        }

        public RoomStatus GetRoomStatus(Guid RoomStatusID)
        {
            return base.GetById(RoomStatusID);
        }

        public async Task<RoomStatus> UpdateRoomStatusAsync(RoomStatus roomStatus, CancellationToken cancellationToken = default)
        {
            var existingRoomStatus = _hotelDbContext.roomStatuses.FirstOrDefault(x => x.RoomStatusID == roomStatus.RoomStatusID);
            if (existingRoomStatus != null)
            {
                ToEntity(existingRoomStatus, roomStatus);
                _hotelDbContext.roomStatuses.Update(existingRoomStatus);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingRoomStatus;

        }

        internal void ToEntity(RoomStatus data, RoomStatus model)
        {
            data.RoomsStatus = model.RoomsStatus;
        }
    }
}
