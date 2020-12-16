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
    public class SqlHotelData : BaseRepository<Hotels>, IHotels
    {
        private HotelsDbContext _hotelDbContext;
        public SqlHotelData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Hotels> AddHotels(Hotels hotels, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(hotels, cencellationToken);
        }

        public async Task<bool> DeleteHotelsAsync(Hotels hotels, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(hotels);
        }

        public IEnumerator<Hotels> GetHotels()
        {
            return this.GetAll();
        }

        public Hotels GetHotels(Guid HotelID)
        {
            return base.GetById(HotelID);
        }

        public async Task<Hotels> UpdateHotelsAsync(Hotels hotels, CancellationToken cencellationToken = default)
        {
            var existingHotels = _hotelDbContext.hotels.FirstOrDefault(x => x.HotelID == hotels.HotelID);
            if (existingHotels != null)
            {
                _hotelDbContext.hotels.Update(hotels);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingHotels;
        }
    }
}

