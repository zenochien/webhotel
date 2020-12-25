using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Hotel.Models
{
    public class UserToken
    {
        public UserToken(string token, DateTime expirationDate)
        {
            Token = token;
            ExpirationDate = expirationDate;
        }

        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
