using IdentityServerData.Context;
using IdentityServerData.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServerData
{
    public static class ServiceRegistration
    {
        public static void AddResourceData(this IServiceCollection services, string connectionString, string dbName)
        {
            services.AddSingleton(s => new ResourceDbContext(connectionString, dbName));
            services.AddScoped<UserRepository>();
            services.AddScoped<PostRepository>();
            services.AddScoped<FeedRepository>();
        }
    }
}
