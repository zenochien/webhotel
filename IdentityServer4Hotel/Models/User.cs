using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IdentityServer4Hotel.Models
{
    public class User : IdentityUser
    {
        public ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();
    }
}
