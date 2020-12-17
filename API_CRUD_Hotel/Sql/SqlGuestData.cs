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
    public class SqlGuestData : BaseRepository<Guests>, IGuests
    {
        private HotelsDbContext _hotelDbContext;
        public SqlGuestData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Guests> AddGuestsAsync(Guests guests, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(guests, cencellationToken);
        }

        public async Task<bool> DeleteGuestsAsync(Guests guests, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(guests);
        }

        public IEnumerable<Guests> GetGuests()
        {
            return this.GetAll();
        }

        public Guests GetGuests(Guid GuestID)
        {
            return base.GetById(GuestID);
        }

        public async Task<Guests> UpdateGuests(Guests guests, CancellationToken cencellationToken = default)
        {
            var existingGuest = _hotelDbContext.guests.FirstOrDefault(x => x.GuestID == guests.GuestID);
            if (existingGuest != null)
            {
                _hotelDbContext.guests.Update(guests);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingGuest;
        }
    }
}
