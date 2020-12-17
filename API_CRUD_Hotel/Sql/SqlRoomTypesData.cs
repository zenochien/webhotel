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
    internal class SqlRoomTypesData : BaseRepository<RoomTypes>, IRoomTypes
    {
        private HotelsDbContext _hotelDbContext;
        public  SqlRoomTypesData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async  Task<RoomTypes> AddRoomTypesAsync(RoomTypes roomTypes, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(roomTypes, cancellationToken);
        }

        public async Task<bool> DeleteRoomTypesAsync(RoomTypes roomTypes, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(roomTypes);
        }

        public  IEnumerable<RoomTypes> GetRoomTypes()
        {
            return this.GetAll();
        }

        public RoomTypes GetRoomTypes(Guid RoomTypesID)
        {
            return base.GetById(RoomTypesID);
        }

        public async Task<RoomTypes> UpdateRoomTypesAsync(RoomTypes roomTypes, CancellationToken cancellationToken)
        {
            var existingRoomTypes = _hotelDbContext.roomTypes.FirstOrDefault(x => x.RoomTypeID == roomTypes.RoomTypeID);
            if(existingRoomTypes!=null)
            {
                ToEntity(existingRoomTypes, roomTypes);
                _hotelDbContext.roomTypes.Update(existingRoomTypes);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingRoomTypes;
        }

        internal void ToEntity(RoomTypes database, RoomTypes model)
        {
            database.RoomType = model.RoomType;
        }
    }
}
