using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class StaffRooms
    {
        [Key]
        public Guid StaffRoomID { get; set; }
        public Guid RoomID { get; set; }
        public Guid StaffID { get; set; }

        [ForeignKey("RoomID")]
        public virtual Rooms Rooms { get; set; }
        [ForeignKey("StaffID")]
        public virtual Staff Staff { get; set; }
    }
}
