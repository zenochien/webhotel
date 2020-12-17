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
    internal class BookingRespository : BaseRepository<Booking>, IBooking
    {
        private HotelsDbContext _hotelDbContext;

        public BookingRespository(HotelsDbContext hotelsDbContext):base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Booking> AddBookingAsync(Booking bookings, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(bookings, cancellationToken);
        }

        public async Task<bool> DeleteBookingAsync(Booking booking, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(booking);
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

        public IEnumerable<Booking> GetAllBooking()
        {
            return this.GetAll();
        }

        public Booking GetBooking(Guid BookingID)
        {
            return base.GetById(BookingID);
        }

        internal void ToEntity(Booking bookingofDataBase, Booking model)
        {
            bookingofDataBase.BookingStatus = model.BookingStatus;
        }
    }
}