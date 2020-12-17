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
    public class RoomsRespository : BaseRepository<Rooms>, IRooms
    {
        private HotelsDbContext _hotelDbContext;
        public RoomsRespository(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Rooms> AddRoomsAsync(Rooms Rooms, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(Rooms, cencellationToken);
        }

        public async Task<bool> DeleteRoomsAsync(Rooms Rooms, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(Rooms);
        }

        public IEnumerable<Rooms> GetAllRooms()
        {
            return this.GetAll();
        }

        public Rooms GetRooms(Guid RoomsID)
        {
            return base.GetById(RoomsID);
        }

        public async Task<Rooms> UpdateRoomsAsync(Rooms Rooms, CancellationToken cencellationToken = default)
        {
            var existingRooms = _hotelDbContext.rooms.FirstOrDefault(x => x.RoomsID == Rooms.RoomsID);
            if (existingRooms != null)
            {
                ToEntity(existingRooms, Rooms);
                _hotelDbContext.rooms.Update(existingRooms);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingRooms;
        }

        private void ToEntity(Rooms existingRooms, Rooms rooms)
        {
            throw new NotImplementedException();
        }
    }
}
