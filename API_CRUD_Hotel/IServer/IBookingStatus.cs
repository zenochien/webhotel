using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IBookingStatus : IRepository<BookingStatus>
    {
        IEnumerable<BookingStatus> GetAllBookingStatus();
        BookingStatus GetBookingStatusWithId(Guid BookingStatusID);
        Task<BookingStatus> AddBookingAsync(BookingStatus bookingStatus, CancellationToken cancellationToken = default);
        Task<bool> DeleteBookingStatusAsync(BookingStatus bookingStatus, CancellationToken cancellationToken = default);
        Task<BookingStatus> UpdateBookingStatusAsync(BookingStatus bookingStatus, CancellationToken cancellationToken = default);
    }
}
