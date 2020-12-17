using Microsoft.EntityFrameworkCore;
using System;

namespace DesignDatabaseHotel.Model
{
    public class HotelsDbContext : DbContext
    {
        public HotelsDbContext(DbContextOptions<HotelsDbContext> options) : base(options)
        {
        }

        public DbSet<Booking> bookings { get; set; }
        public DbSet<BookingStatus> bookingStatuses { get; set; }
        public DbSet<Guests> guests { get; set; }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Payments> payments { get; set; }
        public DbSet<PaymentStatus> paymentStatuses { get; set; }
        public DbSet<PaymentTypes> paymentTypes { get; set; }
        public DbSet<Positions> positions { get; set; }
        public DbSet<Rates> rates { get; set; }
        public DbSet<RateTypes> rateTypes { get; set; }
        public DbSet<ReservationAgents> reservationAgents { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<RoomsBooked> roomsBookeds { get; set; }
        public DbSet<RoomStatus> roomStatuses { get; set; }
        public DbSet<RoomTypes> roomTypes { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<StaffRooms> staffRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Booking>(e =>
            {
                e.HasData(new Booking
                {
                    BookingID = Guid.NewGuid(),
                    HotelID = Guid.NewGuid(),
                    GuestID = Guid.NewGuid(),
                    ReservationAgentID = Guid.NewGuid(),
                    DateFrom = new DateTime(2020, 12, 02),
                    DateTo = new DateTime(2020, 11, 02),
                    RoomCount = "03",
                    BookingStatusID = Guid.NewGuid()
                }, new Booking
                {
                    BookingID = Guid.NewGuid(),
                    HotelID = Guid.NewGuid(),
                    GuestID = Guid.NewGuid(),
                    ReservationAgentID = Guid.NewGuid(),
                    DateFrom = new DateTime(2020, 02, 02),
                    DateTo = new DateTime(2020, 03, 02),
                    RoomCount = "23",
                    BookingStatusID = Guid.NewGuid()
                });
            });
        }

    }
}