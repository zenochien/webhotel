using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlBSData : IBookingStatus
    {
        private HotelsDbContext _hotelDbContext;
        public SqlBSData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public BookingStatus AddBookingStatus(BookingStatus bookingStatus)
        {
            bookingStatus.BookingStatusID = Guid.NewGuid();
            _hotelDbContext.bookingStatuses.Add(bookingStatus);
            _hotelDbContext.SaveChanges();
            return bookingStatus;
        }

        public void DeleteBookingStatus(BookingStatus bookingStatus)
        {
            _hotelDbContext.bookingStatuses.Remove(bookingStatus);
            _hotelDbContext.SaveChanges();
        }

        public BookingStatus EditBookingStatus(BookingStatus bookingStatus)
        {
            var existingBS = _hotelDbContext.bookingStatuses.Find(bookingStatus.BookingStatusID);
            if (existingBS != null)
            {
                _hotelDbContext.bookingStatuses.Update(bookingStatus);
                _hotelDbContext.SaveChanges();
            }
            return bookingStatus;
        }

        public List<BookingStatus> GetBookingStatus()
        {
            return _hotelDbContext.bookingStatuses.ToList();
        }

        public BookingStatus GetBookingStatus(Guid BookingStatusID)
        {
            var bookingStatus = _hotelDbContext.bookingStatuses.Find(BookingStatusID);
            return bookingStatus;
        }
    }
}
