using API_CRUD_Hotel.IServer;
using API_CRUD_Hotel.Sql;
using DesignDatabaseHotel.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API_CRUD_Hotel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IBookingStatus, SqlBSData>();
            services.AddScoped<IHotels, SqlHotelData>();
            services.AddScoped<IPayments, SqlPaymentData>();
            services.AddScoped<IPaymentStatus, SqlPaymentStatusData>();
            services.AddScoped<IPaymentTypes, SqlPaymentTypesData>();
            services.AddScoped<IPositions, SqlPositionsData>();
            services.AddScoped<IRates, SqlRatesData>();
            services.AddScoped<IRateTypes, SqlRateTypesData>();
            services.AddScoped<IRoomsBooked, SqlRoomsBooked>();
            services.AddScoped<IRooms, SqlRoomsData>();
            services.AddScoped<IRoomStatus, SqlRoomStatusData>();
            services.AddScoped<IRoomTypes, SqlRoomTypesData>();
            services.AddScoped<IStaff, SqlStaffData>();
            services.AddScoped<IStaffRooms, SqlStaffRooms>();
            services.AddScoped<IPositions, SqlPositionsData>();
            services.AddScoped<IGuests, SqlGuestData>();
            services.AddScoped<IBookingRepository, SqlBookingsRepository>();
            services.AddScoped<IReservationAgents, SqlRAData>();

            services.AddDbContextPool<HotelsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ketnoisql")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}