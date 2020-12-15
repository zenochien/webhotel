using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class RoomStatus
    {
        [Key]
        public Guid RoomStatusID { get; set; }
        public  string RoomsStatus { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
