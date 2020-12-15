using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class RateTypes
    {
        [Key]
        public Guid RateTypeID { get; set; }
        public string RateType { get; set; }
        public string Description { get; set; }
        public string SortOrder { get; set; }
        public string Active { get; set; }

        public virtual ICollection<Rates> Rates { get; set; }
    }
}
