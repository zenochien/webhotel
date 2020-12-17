using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace IdentityServerData.Enitities
{
    public class Post : Base.Entity<ObjectId>
    {
        public Owner By { get; set; }
        [BsonRepresentation(BsonType.String)]
        public PostType Type { get; set; }
        public Detail Datail { get; set; }
        public List<Comment> Comments { get; set; }
    } 
}
