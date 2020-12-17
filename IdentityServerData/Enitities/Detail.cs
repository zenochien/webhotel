using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerData.Enitities
{
    public class Detail
    {
        public string Text { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
    }
}
