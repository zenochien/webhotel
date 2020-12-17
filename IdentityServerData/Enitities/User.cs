using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerData.Enitities
{
   public class User : Base.Entity<string>
    {
        public Profile Profile { get; set; }

        public Dictionary<string, Profile> Followers { get; set; } = new Dictionary<string, Profile>();

    }

    public class Profile
    {
        public Profile() { }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Image { get; set; }

        public Profile(string name, string gender, string image)
        {
            Name = name;
            Gender = gender;
            Image = image;
        }
    }
}
