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
    public class SqlRoomsBooked : BaseRepository<RoomsBooked>, IRoomsBooked
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRoomsBooked(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<RoomsBooked> AddRoomsBookedAsync(RoomsBooked roomsBooked, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(roomsBooked ,cancellationToken);
        }

        public async Task<bool> DeleteRoomBookedsAsync(RoomsBooked roomsBooked, CancellationToken cancellationToken)
        {
            return await this.DeleteAsync(roomsBooked);
        }

        public RoomsBooked GetRoomsBooked(Guid RoomsBookedID)
        {
            return base.GetById(RoomsBookedID);
        }

        public IEnumerable<RoomsBooked> GetRoomsBookeds()
        {
            return this.GetAll();
        }

        public async Task<RoomsBooked> UpdateRoomBookeds(RoomsBooked roomsBooked, CancellationToken cancellationToken = default)
        {
            var existingRoomBooked = _hotelDbContext.roomsBookeds.FirstOrDefault(x => x.RoomBookedID == roomsBooked.RoomBookedID);
            if (existingRoomBooked != null)
            {
                _hotelDbContext.roomsBookeds.Update(existingRoomBooked);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingRoomBooked;
        }
    }
}
