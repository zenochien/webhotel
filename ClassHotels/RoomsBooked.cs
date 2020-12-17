using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class RoomsBooked
    {
        [Key]
        public Guid RoomBookedID { get; set; }
        public Guid BookingID { get; set; }
        public Guid RoomID { get; set; }
        public int Rate { get; set; }

        [ForeignKey("RoomID")]
        public virtual Rooms Rooms { get; set; }
        public virtual Booking Bookings { get; set; }
    }
}
