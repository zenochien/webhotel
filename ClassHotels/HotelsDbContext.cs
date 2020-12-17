using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesignDatabaseHotel.Model
{
    public class HotelsDbContext : IdentityDbContext
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

            builder.Entity<BookingStatus>(e =>
           {
               e.HasData(new BookingStatus
               {
                   BookingStatusID = Guid.NewGuid(),
                   Status = "Tốt",
                   Description = "Đẹp và sạch sẽ",
                   SortOrder = "1",
                   Active = "Có",
               }, new BookingStatus()
               {
                   BookingStatusID = Guid.NewGuid(),
                   Status = "Tốt",
                   Description = "Đẹp và sạch sẽ",
                   SortOrder = "1",
                   Active = "Có",
               });
           });

            builder.Entity<Guests>(e =>
            {
                e.HasData(new Guests()
                {
                    GuestID = Guid.NewGuid(),
                    FirstName = "Anh",
                    LastName = "Nguyễn Văn",
                    Address = "20 Thông Nhất",
                    Address2 = "43 Nguyễn Thị Sáu",
                    City = "Hồ Chí Minh",
                    State = "?",
                    ZipCOde = "007",
                    Country = "VietNam",
                    HomePhoneNumber = "0123456789",
                    CellularNumber = "0123456789",
                    eMailAddress = "nguyenvananh@mail.com",
                    Gender = "Vietnam"
                },
            new Guests()
            {
                GuestID = Guid.NewGuid(),
                FirstName = "Mạnh",
                LastName = "Nguyễn Văn",
                Address = "21 Thông Nhất",
                Address2 = "33 Nguyễn Minh Khai",
                City = "Hồ Chí Minh",
                State = "?",
                ZipCOde = "007",
                Country = "VietNam",
                HomePhoneNumber = "0123456789",
                CellularNumber = "0123456789",
                eMailAddress = "nguyenvanmanh@mail.com",
                Gender = "Vietnam"
            });
            });

            builder.Entity<Hotels>(e =>
            {
                e.HasData(new Hotels()
                {
                    HotelID = Guid.NewGuid(),
                    HotelCode = "1234",
                    Name = "Spa Biển Đep5",
                    Motto = "SSS",
                    Address = "43 Nguyễn Thị Sáu",
                    Address2 = "",
                    City = "Hồ Chí Minh",
                    State = "?",
                    ZipCOde = "007",
                    MainPhoneNumber = "123456789",
                    FaxNumber = "0123456789",
                    TooIIFreeNumber = "0123456789",
                    CompanyeMailAddress = "nguyenvananh@mail.com",
                    WebsiteAddress = "Vietnam",
                    Main = "AAAA",
                    ImagePath = "AAAAA",
                },
              new Hotels()
              {
                  HotelID = Guid.NewGuid(),
                  HotelCode = "1234",
                  Name = "Spa Biển Đep5",
                  Motto = "SSS",
                  Address = "43 Nguyễn Thị Sáu",
                  Address2 = "",
                  City = "Hồ Chí Minh",
                  State = "?",
                  ZipCOde = "007",
                  MainPhoneNumber = "123456789",
                  FaxNumber = "0123456789",
                  TooIIFreeNumber = "0123456789",
                  CompanyeMailAddress = "nguyenvananh@mail.com",
                  WebsiteAddress = "Vietnam",
                  Main = "AAAA",
                  ImagePath = "AAAAA",
              });
            });

            builder.Entity<Payments>(e =>
            {
                e.HasData(new Payments()
                {
                    PaymentID = Guid.NewGuid(),
                    RoomID = Guid.NewGuid(),
                    Date = new DateTime(2020, 12, 03),
                    Payment = "3025",
                    PaymentStatsID = Guid.NewGuid(),
                    PaymentTypeID = Guid.NewGuid()
                },
             new Payments()
             {
                 PaymentID = Guid.NewGuid(),
                 RoomID = Guid.NewGuid(),
                 Date = new DateTime(2020, 01, 03),
                 Payment = "2450",
                 PaymentStatsID = Guid.NewGuid(),
                 PaymentTypeID = Guid.NewGuid()
             });
            });

            builder.Entity<PaymentStatus>(e =>
            {
                e.HasData(new PaymentStatus()
                {
                    PaymentStatusID = Guid.NewGuid(),
                    Status = "123",
                    Description = "12334",
                    SortOrder = "2312",
                    Active = "123123"
                },
            new PaymentStatus()
            {
                PaymentStatusID = Guid.NewGuid(),
                Status = "123",
                Description = "12334",
                SortOrder = "2312",
                Active = "123123"
            });
           });

            builder.Entity<PaymentTypes>(e =>
            {
                e.HasData(new PaymentTypes()
                {
                    PaymentTypeID = Guid.NewGuid(),
                    PaymentType = "vip",
                    SortOrder = "123",
                    Active = "có"
                },
            new PaymentTypes()
            {
                PaymentTypeID = Guid.NewGuid(),
                PaymentType = "vip",
                SortOrder = "123",
                Active = "có"
            });
           });

            builder.Entity<Positions>(e =>
            {
                e.HasData(new Positions()
                {
                    PositionID = Guid.NewGuid(),
                    Position = "asdf",
                    SortOrder = "123",
                    Active = "có"
                },
            new Positions()
            {
                PositionID = Guid.NewGuid(),
                Position = "asdf",
                SortOrder = "123",
                Active = "có"
            });
            });

            builder.Entity<Rates>(e =>
            {
                e.HasData(new Rates()
                {
                    RateID = Guid.NewGuid(),
                    RoomID = Guid.NewGuid(),
                    FromDate = new DateTime(2020, 01, 02),
                    ToDate = new DateTime(2020, 05, 30),
                    RateTypeID = Guid.NewGuid()
                },
            new Rates()
            {
                RateID = Guid.NewGuid(),
                RoomID = Guid.NewGuid(),
                FromDate = new DateTime(2020, 01, 02),
                ToDate = new DateTime(2020, 05, 30),
                RateTypeID = Guid.NewGuid()
            });
            });

            builder.Entity<RateTypes>(e =>
            {
                e.HasData(new RateTypes()
                {
                    RateTypeID = Guid.NewGuid(),
                    RateType = "vip",
                    Description = "sss",
                    SortOrder = "123",
                    Active = "có"
                },
            new RateTypes()
            {
                RateTypeID = Guid.NewGuid(),
                RateType = "thường",
                Description = "aaa",
                SortOrder = "aaa",
                Active = "có"
            });
            });

            builder.Entity<ReservationAgents>(e =>
            {
                e.HasData(new ReservationAgents()
                {
                    ReservationAgentID = Guid.NewGuid(),
                    FirstName = "Hùng",
                    LastName = "Phạm Mạnh",
                    Address = "32 Thị Yến",
                    Address2 = "21 Nguyễn Thị Sáu",
                    City = "Hồ Chí Minh",
                    State = "?",
                    ZipCOde = "333",
                    Country = "VietNam",
                    HomePhoneNumber = "0123456789",
                    CellularNumber = "0123456789",
                    eMailAddress = "phammanhhung@mail.com",
                    Gender = "Vietnam"
                },
            new ReservationAgents()
            {
                ReservationAgentID = Guid.NewGuid(),
                FirstName = "Thìa",
                LastName = "Hương Văn",
                Address = "21 Thông Mông",
                Address2 = "33 Nguyễn Minh Mạnh",
                City = "Hồ Chí Minh",
                State = "?",
                ZipCOde = "443",
                Country = "VietNam",
                HomePhoneNumber = "0123456789",
                CellularNumber = "0123456789",
                eMailAddress = "huongvanthia@mail.com",
                Gender = "Vietnam"
            });
            });

            builder.Entity<RoomsBooked>(e =>
            {
                e.HasData(new RoomsBooked()
                {
                    RoomBookedID = Guid.NewGuid(),
                    BookingID = Guid.NewGuid(),
                    RoomID = Guid.NewGuid(),
                    Rate = 10
                },
              new RoomsBooked()
              {
                  RoomBookedID = Guid.NewGuid(),
                  BookingID = Guid.NewGuid(),
                  RoomID = Guid.NewGuid(),
                  Rate = 5
              });
            });

            builder.Entity<Rooms>(e =>
            {
                e.HasData(new Rooms()
                {
                    RoomsID = Guid.NewGuid(),
                    HotelID = Guid.NewGuid(),
                    Floor = "5",
                    RoomTypeID = Guid.NewGuid(),
                    RoomNumber = "123",
                    Desription = "abc",
                    RoomStatusID = Guid.NewGuid()
                },
            new Rooms()
            {
                RoomsID = Guid.NewGuid(),
                HotelID = Guid.NewGuid(),
                Floor = "3",
                RoomTypeID = Guid.NewGuid(),
                RoomNumber = "123",
                Desription = "abc",
                RoomStatusID = Guid.NewGuid()
            });
            });

            builder.Entity<RoomStatus>(e =>
            {
                e.HasData(new RoomStatus()
                {
                    RoomStatusID = Guid.NewGuid(),
                    RoomsStatus = "vip",
                    Description = "sss",
                    SortOrder = "123",
                    Active = "có"
                },
            new RoomStatus()
            {
                RoomStatusID = Guid.NewGuid(),
                RoomsStatus = "vip",
                Description = "sss",
                SortOrder = "123",
                Active = "có"
            });
            });

            builder.Entity<RoomTypes>(e =>
            {
                e.HasData(new RoomTypes()
                {
                    RoomTypeID = Guid.NewGuid(),
                    RoomType = "vip",
                    Description = "sss",
                    SortOrder = "123",
                    Active = "có"
                },
            new RoomTypes()
            {
                RoomTypeID = Guid.NewGuid(),
                RoomType = "thường",
                Description = "aaa",
                SortOrder = "aaa",
                Active = "có"
            });
            });

            builder.Entity<Staff>(e =>
            {
                e.HasData(new Staff()
                {
                    StaffID = Guid.NewGuid(),
                    FirstName = "Anh",
                    LastName = "Nguyễn Văn",
                    Address = "20 Thông Nhất",
                    Address2 = "43 Nguyễn Thị Sáu",
                    City = "Hồ Chí Minh",
                    State = "?",
                    ZipCOde = "007",
                    Country = "VietNam",
                    HomePhoneNumber = "0123456789",
                    CellularNumber = "0123456789",
                    eMailAddress = "nguyenvananh@mail.com",
                    Gender = "Vietnam"
                },
            new Staff()
            {
                StaffID = Guid.NewGuid(),
                FirstName = "Anh",
                LastName = "Nguyễn Văn",
                Address = "20 Thông Nhất",
                Address2 = "43 Nguyễn Thị Sáu",
                City = "Hồ Chí Minh",
                State = "?",
                ZipCOde = "007",
                Country = "VietNam",
                HomePhoneNumber = "0123456789",
                CellularNumber = "0123456789",
                eMailAddress = "nguyenvananh@mail.com",
                Gender = "Vietnam"
            });
            });

            builder.Entity<StaffRooms>(e =>
            {
                e.HasData(new StaffRooms()
                {
                    StaffID = Guid.NewGuid(),
                    RoomID = Guid.NewGuid(),
                    StaffRoomID = Guid.NewGuid()
                },
            new StaffRooms()
            {
                StaffID = Guid.NewGuid(),
                RoomID = Guid.NewGuid(),
                StaffRoomID = Guid.NewGuid()
            });
            });
        }
    }
}