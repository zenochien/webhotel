using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_CRUD_Hotel.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookingStatuses",
                columns: table => new
                {
                    BookingStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingStatuses", x => x.BookingStatusID);
                });

            migrationBuilder.CreateTable(
                name: "guests",
                columns: table => new
                {
                    GuestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCOde = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CellularNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eMailAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guests", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    HotelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Motto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCOde = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainPhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TooIIFreeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyeMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.HotelID);
                });

            migrationBuilder.CreateTable(
                name: "paymentTypes",
                columns: table => new
                {
                    PaymentTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentTypes", x => x.PaymentTypeID);
                });

            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "rateTypes",
                columns: table => new
                {
                    RateTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rateTypes", x => x.RateTypeID);
                });

            migrationBuilder.CreateTable(
                name: "reservationAgents",
                columns: table => new
                {
                    ReservationAgentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCOde = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CellularNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationAgents", x => x.ReservationAgentID);
                });

            migrationBuilder.CreateTable(
                name: "roomStatuses",
                columns: table => new
                {
                    RoomStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomsStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomStatuses", x => x.RoomStatusID);
                });

            migrationBuilder.CreateTable(
                name: "roomTypes",
                columns: table => new
                {
                    RoomTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomTypes", x => x.RoomTypeID);
                });

            migrationBuilder.CreateTable(
                name: "paymentStatuses",
                columns: table => new
                {
                    PaymentStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypesPaymentTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentStatuses", x => x.PaymentStatusID);
                    table.ForeignKey(
                        name: "FK_paymentStatuses_paymentTypes_PaymentTypesPaymentTypeID",
                        column: x => x.PaymentTypesPaymentTypeID,
                        principalTable: "paymentTypes",
                        principalColumn: "PaymentTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                columns: table => new
                {
                    StaffID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PositionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCOde = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CellularNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    eMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffs", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_staffs_positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationAgentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoomCount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_bookings_bookingStatuses_BookingStatusID",
                        column: x => x.BookingStatusID,
                        principalTable: "bookingStatuses",
                        principalColumn: "BookingStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookings_reservationAgents_ReservationAgentID",
                        column: x => x.ReservationAgentID,
                        principalTable: "reservationAgents",
                        principalColumn: "ReservationAgentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    RoomsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.RoomsID);
                    table.ForeignKey(
                        name: "FK_rooms_hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "hotels",
                        principalColumn: "HotelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rooms_roomStatuses_RoomStatusID",
                        column: x => x.RoomStatusID,
                        principalTable: "roomStatuses",
                        principalColumn: "RoomStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rooms_roomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "roomTypes",
                        principalColumn: "RoomTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    PaymentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Payment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentStatsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentStatusID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_payments_paymentStatuses_PaymentStatusID",
                        column: x => x.PaymentStatusID,
                        principalTable: "paymentStatuses",
                        principalColumn: "PaymentStatusID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payments_paymentTypes_PaymentTypeID",
                        column: x => x.PaymentTypeID,
                        principalTable: "paymentTypes",
                        principalColumn: "PaymentTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payments_rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "rooms",
                        principalColumn: "RoomsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rates",
                columns: table => new
                {
                    RateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RateTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomsID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rates", x => x.RateID);
                    table.ForeignKey(
                        name: "FK_rates_rateTypes_RateTypeID",
                        column: x => x.RateTypeID,
                        principalTable: "rateTypes",
                        principalColumn: "RateTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rates_rooms_RoomsID",
                        column: x => x.RoomsID,
                        principalTable: "rooms",
                        principalColumn: "RoomsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roomsBookeds",
                columns: table => new
                {
                    RoomBookedID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    BookingsBookingID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomsBookeds", x => x.RoomBookedID);
                    table.ForeignKey(
                        name: "FK_roomsBookeds_bookings_BookingsBookingID",
                        column: x => x.BookingsBookingID,
                        principalTable: "bookings",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_roomsBookeds_rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "rooms",
                        principalColumn: "RoomsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffRooms",
                columns: table => new
                {
                    StaffRoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_staffRooms", x => x.StaffRoomID);
                    table.ForeignKey(
                        name: "FK_staffRooms_rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "rooms",
                        principalColumn: "RoomsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_staffRooms_staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "staffs",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_BookingStatusID",
                table: "bookings",
                column: "BookingStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_GuestID",
                table: "bookings",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_HotelID",
                table: "bookings",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_ReservationAgentID",
                table: "bookings",
                column: "ReservationAgentID");

            migrationBuilder.CreateIndex(
                name: "IX_payments_PaymentStatusID",
                table: "payments",
                column: "PaymentStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_payments_PaymentTypeID",
                table: "payments",
                column: "PaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_payments_RoomID",
                table: "payments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_paymentStatuses_PaymentTypesPaymentTypeID",
                table: "paymentStatuses",
                column: "PaymentTypesPaymentTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_rates_RateTypeID",
                table: "rates",
                column: "RateTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_rates_RoomsID",
                table: "rates",
                column: "RoomsID");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_HotelID",
                table: "rooms",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_RoomStatusID",
                table: "rooms",
                column: "RoomStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_RoomTypeID",
                table: "rooms",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_roomsBookeds_BookingsBookingID",
                table: "roomsBookeds",
                column: "BookingsBookingID");

            migrationBuilder.CreateIndex(
                name: "IX_roomsBookeds_RoomID",
                table: "roomsBookeds",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_staffRooms_RoomID",
                table: "staffRooms",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_staffRooms_StaffID",
                table: "staffRooms",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_PositionID",
                table: "staffs",
                column: "PositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "rates");

            migrationBuilder.DropTable(
                name: "roomsBookeds");

            migrationBuilder.DropTable(
                name: "staffRooms");

            migrationBuilder.DropTable(
                name: "paymentStatuses");

            migrationBuilder.DropTable(
                name: "rateTypes");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "staffs");

            migrationBuilder.DropTable(
                name: "paymentTypes");

            migrationBuilder.DropTable(
                name: "bookingStatuses");

            migrationBuilder.DropTable(
                name: "guests");

            migrationBuilder.DropTable(
                name: "reservationAgents");

            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.DropTable(
                name: "roomStatuses");

            migrationBuilder.DropTable(
                name: "roomTypes");

            migrationBuilder.DropTable(
                name: "positions");
        }
    }
}
