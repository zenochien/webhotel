using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class Bookings
    {
        [Key]
        public Guid BookingID { get; set; }
        public Guid HotelID { get; set; }
        public Guid GuestID { get; set; }
        public Guid ReservationAgentID { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string RoomCount { get; set; }
        public Guid BookingStatusID { get; set; }

        [ForeignKey("GuestID")]
        public virtual Guests Guests { get; set; }
        [ForeignKey("ReservationAgentID")]
        public virtual ReservationAgents ReservationAgents { get; set; }
        [ForeignKey("HotelID")]
        public virtual Hotels Hotels { get; set; }
        [ForeignKey("BookingStatusID")]
        public virtual BookingStatus BookingStatus { get; set; }
        public virtual ICollection<RoomsBooked> RoomsBookeds { get; set; }

    }
}
