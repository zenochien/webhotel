using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class PaymentTypes
    {
        [Key]
        public Guid PaymentTypeID { get; set; }
        public string PaymentType { get; set; }
        public string SortOrder { get; set; }
        public string Active { get; set; }

        public virtual ICollection<PaymentStatus> PaymentStatuses { get; set; }
    }
}
