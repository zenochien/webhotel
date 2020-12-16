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
    public class SqlStaffData : BaseRepository<Rates> ,IStaff
    {
        private HotelsDbContext _hotelDbContext;
        public SqlStaffData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Rates> AddStaffAsync(Rates staff, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(staff, cancellationToken);
        }

        public async Task<bool> DeleteStaffAsync(Rates staff, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(staff);
        }

        public IEnumerable<Rates> GetStaffs()
        {
            return this.GetAll();
        }

        public Rates GetStaffs(Guid StaffID)
        {
            return base.GetById(StaffID);
        }

        public async Task<Rates> UpdateStaffAsync(Rates staff, CancellationToken cancellationToken = default)
        {
            var existingStaff = _hotelDbContext.staffs.FirstOrDefault(x => x.StaffID == staff.StaffID);
            if (existingStaff != null)
            {
                ToEntity(existingStaff, staff);
                _hotelDbContext.staffs.Update(existingStaff);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingStaff;
        }

        internal void ToEntity(Rates database, Rates model)
        {
            database.LastName = model.LastName;
            database.FirstName = model.FirstName;
        }
    }
}
