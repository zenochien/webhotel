using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class Payments
    {
        [Key]
        public Guid PaymentID { get; set; }
        public Guid RoomID { get; set; }
        public DateTime? Date { get; set; }
        public string Payment { get; set; }
        public Guid PaymentTypeID { get; set; }
        public Guid PaymentStatsID { get; set; }

        [ForeignKey("RoomID")]
        public virtual Rooms Rooms { get; set; }
        [ForeignKey("PaymentTypeID")]
        public virtual PaymentTypes PaymentTypes { get; set; }
        [ForeignKey("PaymentStatusID")]
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
