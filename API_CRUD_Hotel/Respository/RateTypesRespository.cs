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
    public class RateTypesRespository : BaseRepository<RateTypes>, IRateTypes
    {
        private HotelsDbContext _hotelDbContext;
        public RateTypesRespository(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<RateTypes> AddRateTypesAsync(RateTypes RateTypes, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(RateTypes, cencellationToken);
        }

        public async Task<bool> DeleteRateTypesAsync(RateTypes RateTypes, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(RateTypes);
        }

        public IEnumerable<RateTypes> GetAllRateTypes()
        {
            return this.GetAll();
        }

        public RateTypes GetRateTypes(Guid RateTypesID)
        {
            return this.GetById(RateTypesID);
        }

        public async Task<RateTypes> UpdateRateTypesAsync(RateTypes RateTypes, CancellationToken cencellationToken = default)
        {
            var existingReteTypes = _hotelDbContext.rateTypes.FirstOrDefault(x => x.RateTypeID == RateTypes.RateTypeID);
            if (existingReteTypes != null)
            {
                _hotelDbContext.rateTypes.Update(existingReteTypes);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingReteTypes;
        }
    }
}
