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
    internal class SqlBookingsRepository : BaseRepository<Booking>, IBookingRepository
    {
        private HotelsDbContext _hotelDbContext;

        //  private readonly IMapper _mapper;
        public SqlBookingsRepository(HotelsDbContext hotelsDbContext):base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
            // _mapper = mapper;
        }

        public async Task<Booking> AddBookingAsync(Booking bookings, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(bookings, cancellationToken);
        }

        public async Task<bool> DeleteBookingAsync(Booking bookings, CancellationToken cancellationToken = default)
        {
            _hotelDbContext.bookings.Remove(bookings);
            return await _hotelDbContext.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<Booking> UpdateBookingAsync(Booking bookings, CancellationToken cancellationToken = default)
        {
            var existingBookings = _hotelDbContext.bookings.FirstOrDefault(x => x.BookingID == bookings.BookingID);
            if (existingBookings != null)
            {
                ToEntity(existingBookings, bookings);
                _hotelDbContext.bookings.Update(existingBookings);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingBookings;
        }

        public IEnumerable<Booking> GetBooking()
        {
            return _hotelDbContext.bookings.AsEnumerable();
        }

        public Booking GetBooking(Guid BookingID)
        {
            return _hotelDbContext.bookings.FirstOrDefault(x => x.BookingID == BookingID);
        }

        internal void ToEntity(Booking bookingofDataBase, Booking model)
        {
            bookingofDataBase.BookingStatus = model.BookingStatus;

            /// nhung field muon update
        }
    }
}