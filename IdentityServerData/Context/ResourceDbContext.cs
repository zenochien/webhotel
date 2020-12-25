using IdentityServerData.Enitities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServerData.Context
{
   public class ResourceDbContext
    {
        IMongoClient MongoClient { get; }

        IMongoDatabase Database { get; }

        public ResourceDbContext(string connectionString, string dbName)
        {
            MongoClient = new MongoClient(connectionString);
            Database = MongoClient.GetDatabase(dbName);
        }

        public IMongoCollection<User> Users => Database.GetCollection<User>("users");
        public IMongoCollection<Post> Posts => Database.GetCollection<Post>("posts");
        public IMongoCollection<Feed> Wall => Database.GetCollection<Feed>("wall");
        public IMongoCollection<Feed> News => Database.GetCollection<Feed>("news");
    }
}
