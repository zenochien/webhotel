using IdentityServerData.Context;
using IdentityServerData.Enitities;
using IdentityServerData.Repositories.Base;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace IdentityServerData.Repositories
{
    public class UserRepository:BaseRepository
    {
        public UserRepository(ResourceDbContext context) : base(context)
        {
        }

        public async Task CreateAsync(User user)
        {
            await Task.WhenAll(Context.Users.InsertOneAsync(user),
                Context.Wall.InsertOneAsync(new Feed { UserId = user.Id }),
                Context.Wall.InsertOneAsync(new Feed { UserId = user.Id }));
        }

        public Task CreateAsync(string userId, Profile profile)
        {
            var user = new User() { Id = userId, Profile = profile };

            return CreateAsync(user);
        }

        public Task CreateAsync(string userId, string name, string gender, string image)
        {
            var user = new User
            {
                Id = userId,
                Profile = new Profile(name, image, gender)
            };

            return CreateAsync(user);
        }

        public async Task<bool> FollowAsync(string userId, string destId)
        {
            var profile = await ProfileAsync(userId);

            if (profile != null)
            {
                var path = "Followers." + userId;

                var update = Builders<User>.Update.Set(path, profile)
                    .Set(x => x.Meta.Updated, DateTime.UtcNow);

                var result = await Context.Users.UpdateOneAsync(x => x.Id == destId, update, new UpdateOptions()
                {
                    IsUpsert = true
                });

                return result.ModifiedCount > 0;
            }

            return false;
        }

        public Task<Profile> ProfileAsync(string userId)
        {
            return Context.Users.Find(x => x.Id == userId).Project(x => x.Profile).SingleOrDefaultAsync();
        }
    }
}
