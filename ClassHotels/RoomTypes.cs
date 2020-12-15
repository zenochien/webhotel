using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class RoomTypes
    {
        [Key]
        public Guid RoomTypeID { get; set; }
        public string RoomType { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
    }
}
