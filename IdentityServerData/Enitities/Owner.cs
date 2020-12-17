using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerData.Enitities
{
   public  class Owner : Profile
    {
        public Owner(string userId, Profile profile) : base(profile.Name, profile.Gender, profile.Image)
        {
            Id = userId;
        }

        public Owner()
        {

        }
        public string Id { get; set; }
    }
}
