using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerData.Enitities
{
    public class Feed : Base.Entity<ObjectId>
    {
        public string UserId { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
