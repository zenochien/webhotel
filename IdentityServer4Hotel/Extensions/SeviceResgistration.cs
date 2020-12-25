using AutoMapper;
using IdentityServer4Hotel.Configuration;
using IdentityServer4Hotel.DbContext;
using IdentityServer4Hotel.Models;
using IdentityServer4Hotel.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer4Hotel.Extensions
{
    internal static class SeviceResgistration
    {
        public static void AddResourceData(this IServiceCollection services, string connectionString, string dbName)
        {
            //services.AddSingleton(s => new ResourceDbContext(connectionString, dbName));
            //services.AddScoped<UserRepository>();
            //services.AddScoped<PostRepository>();
            //services.AddScoped<FeedRepository>();
            
        }
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(
               options => options.UseSqlServer(configuration.GetConnectionString("deafualtConnection")));
            services.AddIdentity<User, IdentityRole>()
                         .AddEntityFrameworkStores<UserDbContext>()
                         .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
        

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<User>();

            services.AddMapper();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthencationService, AuthencationService>();
            return services;
        }

        private static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            }, typeof(SeviceResgistration));
        }
    }
}
