using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockBookingStatus : IBookingStatus
    {
        private List<BookingStatus> bookingStatuses = new List<BookingStatus>()
        {
            new BookingStatus()
            {
                BookingStatusID=Guid.NewGuid(),
                Status="Tốt",
                Description="Đẹp và sạch sẽ",
                SortOrder="1",
                Active="Có",
            },
            new BookingStatus()
            {
                BookingStatusID=Guid.NewGuid(),
                Status="Tốt",
                Description="Đẹp và sạch sẽ",
                SortOrder="1",
                Active="Có",
            },
        };

        public BookingStatus AddBookingStatus(BookingStatus bookingStatus)
        {
            bookingStatus.BookingStatusID = Guid.NewGuid();
            bookingStatuses.Add(bookingStatus);
            return bookingStatus;
        }

        public void DeleteBookingStatus(BookingStatus bookingStatus)
        {
            bookingStatuses.Remove(bookingStatus);
        }

        public BookingStatus EditBookingStatus(BookingStatus bookingStatus)
        {
            var existingBS = GetBookingStatus(bookingStatus.BookingStatusID);
            existingBS.Active = bookingStatus.Active;
            return existingBS;
        }

        public List<BookingStatus> GetBookingStatus()
        {
            return bookingStatuses;
        }

        public BookingStatus GetBookingStatus(Guid BookingStatusID)
        {
            return bookingStatuses.SingleOrDefault(x => x.BookingStatusID == BookingStatusID);
        }
    }
}
