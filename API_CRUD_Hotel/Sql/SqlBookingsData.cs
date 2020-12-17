using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlBookingsData : IBookings
    {
        private HotelsDbContext _hotelDbContext;
        public SqlBookingsData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Bookings AddBookings(Bookings bookings)
        {
            bookings.BookingID = Guid.NewGuid();
            _hotelDbContext.bookings.Add(bookings);
            _hotelDbContext.SaveChanges();
            return bookings;
        }

        public void DeleteBookings(Bookings bookings)
        {
            _hotelDbContext.bookings.Remove(bookings);
            _hotelDbContext.SaveChanges();
        }

        public Bookings EditBookings(Bookings bookings)
        {
            var existingBookings = _hotelDbContext.bookings.Find(bookings.BookingID);
            if (existingBookings != null)
            {
                _hotelDbContext.bookings.Update(bookings);
                _hotelDbContext.SaveChanges();
            }
            return bookings;
        }

        public List<Bookings> GetBookings()
        {
            return _hotelDbContext.bookings.ToList();
        }

        public Bookings GetBookings(Guid BookingID)
        {
            var bookings = _hotelDbContext.bookings.Find(BookingID);
            return bookings;
        }
    }
}
