using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IBookings
    {
        List<Bookings> GetBookings();
        Bookings GetBookings(Guid BookingID);
        Bookings AddBookings(Bookings bookings);
        void DeleteBookings(Bookings bookings);
        Bookings EditBookings(Bookings bookings);
    }
}
