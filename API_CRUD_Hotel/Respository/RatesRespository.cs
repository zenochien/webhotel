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
    public class RatesRespository : BaseRepository<Rates>, IRates
    {
        private HotelsDbContext _hotelDbContext;
        public RatesRespository(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Rates> AddRatesAsync(Rates rates, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(rates, cencellationToken);
        }

        public async Task<bool> DeleteRatesAsync(Rates rates, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(rates);
        }

        public IEnumerable<Rates> GetAllRates()
        {
            return this.GetAll();
        }

        public Rates GetRates(Guid RateID)
        {
            return this.GetById(RateID);
        }

        public async Task<Rates> UpdateRatesAsync(Rates rates, CancellationToken cencellationToken = default)
        {
            var existingRate = _hotelDbContext.rates.FirstOrDefault(x => x.RateID == rates.RateID);
            if (existingRate != null)
            {
                _hotelDbContext.rates.Update(existingRate);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingRate;
        }
    }
}
