using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class Rates
    {
        [Key]
        public Guid RateID { get; set; }
        public Guid RoomID { get; set; }
        public int Rate { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Guid RateTypeID { get; set; }

        [ForeignKey("RateTypeID")]
        public virtual RateTypes RateTypes { get; set; }
    }
}
