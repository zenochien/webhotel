using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class BookingStatus
    {
        public Guid BookingStatusID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}
