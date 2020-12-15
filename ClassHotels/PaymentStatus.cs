using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class PaymentStatus
    {
        [Key]
        public Guid PaymentStatusID { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Payments> Payments { get; set; }
    }
}
