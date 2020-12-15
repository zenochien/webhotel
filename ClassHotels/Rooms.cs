using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDatabaseHotel.Model
{
    public class Rooms
    {
        [Key]
        public Guid RoomsID { get; set; }
        public Guid HotelID { get; set; }
        public string Floor { get; set; }
        public Guid RoomTypeID { get; set; }
        public string RoomNumber { get; set; }
        public string Desription { get; set; }
        public Guid RoomStatusID { get; set; }

        [ForeignKey("HotelID")]
        public virtual Hotels Hotels { get; set; }
        [ForeignKey("RoomTypeID")]
        public virtual RoomTypes RoomTypes { get; set; }
        public virtual ICollection<StaffRooms> StaffRooms { get; set; }
        public virtual ICollection<Rates> Rates { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
