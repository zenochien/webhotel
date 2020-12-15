using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesignDatabaseHotel.Model
{
    public class Hotels
    {
        [Key]
        public Guid HotelID { get; set; }
        public string HotelCode { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
        public string Motto { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCOde { get; set; }
        [Required]
        [StringLength(15)]
        public string MainPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string TooIIFreeNumber { get; set; }
        public string CompanyeMailAddress { get; set; }
        public string WebsiteAddress { get; set; }
        public string Main { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Rooms> Rooms { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }        
    }
}
