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
    public class SqlBSData : BaseRepository<BookingStatus>, IBookingStatus
    {
        private HotelsDbContext _hotelDbContext;
        public SqlBSData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<BookingStatus> AddBookingAsync(BookingStatus bookingStatus, CancellationToken cancellationToken = default)
        {
            return await CreateAsync(bookingStatus, cancellationToken);
        }

        public async Task<bool> DeleteBookingStatusAsync(BookingStatus bookingStatus, CancellationToken cancellationToken = default)
        {
            return await this.DeleteAsync(bookingStatus);
        }

        public BookingStatus GetBookingStatus(Guid BookingStatusID)
        {
            return base.GetById(BookingStatusID);
        }

        public IEnumerable<BookingStatus> GetBookingStatuses()
        {
            return this.GetAll();
        }

        public async Task<BookingStatus> UpdateBookingStatusAsync(BookingStatus bookingStatus, CancellationToken cancellationToken = default)
        {
            var existingBookingStatus = _hotelDbContext.bookingStatuses.FirstOrDefault(x => x.BookingStatusID == bookingStatus.BookingStatusID);
            if (existingBookingStatus != null)
            {
                _hotelDbContext.bookingStatuses.Update(bookingStatus);
                await _hotelDbContext.SaveChangesAsync(cancellationToken);
            }
            return existingBookingStatus;
        }
    }
}
