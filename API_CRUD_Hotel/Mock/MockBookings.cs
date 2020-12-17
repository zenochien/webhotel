using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockBookings : IBookings
    {
        private List<Bookings> Booking = new List<Bookings>()
        {
            new Bookings()
            {
                BookingID=Guid.NewGuid(),
                HotelID=Guid.NewGuid(),
                GuestID=Guid.NewGuid(),
                ReservationAgentID=Guid.NewGuid(),
                DateFrom=new DateTime(2020,12,02),
                DateTo=new DateTime(2020,11,02),
                RoomCount="03",
                BookingStatusID=Guid.NewGuid()
            },
            new Bookings()
            {
                BookingID=Guid.NewGuid(),
                HotelID=Guid.NewGuid(),
                GuestID=Guid.NewGuid(),
                ReservationAgentID=Guid.NewGuid(),
                DateFrom=new DateTime(2020,02,02),
                DateTo=new DateTime(2020,03,02),
                RoomCount="23",
                BookingStatusID=Guid.NewGuid()
            }
        };
        public Bookings AddBookings(Bookings bookings)
        {
            bookings.BookingID = Guid.NewGuid();
            Booking.Add(bookings);
            return bookings;
        }

        public void DeleteBookings(Bookings bookings)
        {
            Booking.Remove(bookings);
        }

        public Bookings EditBookings(Bookings bookings)
        {
            var existingBooking = GetBookings(bookings.BookingID);
            existingBooking.BookingStatus = bookings.BookingStatus;
            return existingBooking;
        }

        public List<Bookings> GetBookings()
        {
            return Booking;
        }

        public Bookings GetBookings(Guid BookingID)
        {
            return Booking.SingleOrDefault(x => x.BookingID == BookingID);
        }
    }
}
