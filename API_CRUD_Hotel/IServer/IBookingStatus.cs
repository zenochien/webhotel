using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
     public interface IBookingStatus
    {
        List<BookingStatus> GetBookingStatus();
        BookingStatus GetBookingStatus(Guid BookingStatusID);
        BookingStatus AddBookingStatus(BookingStatus bookingStatus);
        void DeleteBookingStatus(BookingStatus bookingStatus);
        BookingStatus EditBookingStatus(BookingStatus bookingStatus);
    }
}
