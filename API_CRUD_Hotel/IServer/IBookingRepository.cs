using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetBooking();

        Booking GetBooking(Guid BookingID);

        Task<Booking> AddBookingAsync(Booking booking, CancellationToken cancellationToken = default);

        Task<bool> DeleteBookingAsync(Booking booking, CancellationToken cancellationToken = default);

        Task<Booking> UpdateBookingAsync(Booking bookings, CancellationToken cancellationToken = default);
    }
}