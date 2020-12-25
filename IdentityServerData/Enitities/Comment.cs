using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerData.Enitities
{
    public class Comment
    {
        public Owner By { get; set; }
        public DateTime Ts { get; set; }
        public string Text { get; set; }
    }
}
