using MongoDB.Bson.Serialization.Attributes;
using System;

namespace IdentityServerData.Enitities.Base
{
    public class ModelBase<T>
    {
        [BsonId]
        public T Id { get; set; }
        public Meta MetaModel { get; set; }
        public ModelBase()
        {
            MetaModel = new Meta();
        }

        public class Meta
        {
            public DateTime? Created { get; set; }
            public DateTime? Updated { get; set; }
            public DateTime? Deleted { get; set; }

            public Meta()
            {
                Updated = Created = DateTime.UtcNow;
            }
        }
    }
}
