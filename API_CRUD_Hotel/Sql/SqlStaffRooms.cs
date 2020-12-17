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
    internal class SqlStaffRooms : BaseRepository<StaffRooms> ,IStaffRooms
    {
        private HotelsDbContext _hotelDbContext;
        public SqlStaffRooms(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<StaffRooms> AddStaffRoomsAsync(StaffRooms StaffRooms, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(StaffRooms, cancellationToken);
        }

        public async Task<bool> DeleteStaffRoomsAsync(StaffRooms StaffRooms, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(StaffRooms);
        }

        public IEnumerable<StaffRooms> GetStaffRooms()
        {
            return this.GetAll();
        }

        public StaffRooms GetStaffRooms(Guid StaffRoomID)
        {
            return base.GetById(StaffRoomID);
        }

        public async Task<StaffRooms> UpdateStaffRoomsAsync(StaffRooms StaffRooms, CancellationToken cancellationToken = default)
        {
            var existingStafRooms = _hotelDbContext.staffRooms.FirstOrDefault(x => x.StaffRoomID == StaffRooms.StaffRoomID);
            if (existingStafRooms!=null)
            {
                ToEntity(existingStafRooms, StaffRooms);
                _hotelDbContext.staffRooms.Update(existingStafRooms);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingStafRooms;
        }

        private void ToEntity(StaffRooms existingStafRooms, StaffRooms staffRooms)
        {
            throw new NotImplementedException();
        }
    }
}
