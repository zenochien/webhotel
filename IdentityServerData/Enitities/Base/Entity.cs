using MongoDB.Bson.Serialization.Attributes;

namespace IdentityServerData.Enitities.Base
{
    public class Entity<T>
    {
        [BsonId]
        public T Id { get; set; }
        public Meta Meta { get; set; } = new Meta();
    }
}
