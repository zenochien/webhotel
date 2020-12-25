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
            services.AddScoped<IBookingStatus, BookingStatusRespository>();
            services.AddScoped<IHotels, HotelRepository>();
            services.AddScoped<IPayments, PaymentRespository>();
            services.AddScoped<IPaymentStatus, PaymentStatusRepostory>();
            services.AddScoped<IPaymentType, PaymentTypesRespository>();
            services.AddScoped<IPositions, PositionsRespository>();
            services.AddScoped<IRates, RatesRespository>();
            services.AddScoped<IRateTypes, RateTypesRespository>();
            services.AddScoped<IRoomsBooked, RoomsBookedRespository>();
            services.AddScoped<IRooms, RoomsRespository>();
            services.AddScoped<IRoomStatus, RoomStatusRespository>();
            services.AddScoped<IRoomTypes, RoomTypesRespository>();
            services.AddScoped<IStaff, StaffRespository>();
            services.AddScoped<IStaffRooms, StaffRoomsRespository>();
            services.AddScoped<IPositions, PositionsRespository>();
            services.AddScoped<IGuests, GuestRespository>();
            services.AddScoped<IBooking, BookingRespository>();
            services.AddScoped<IReservationAgents, ReservationAgentsRespository>();

            services.AddDbContextPool<HotelsDbContext>(options => options.UseSqlServer("Data Source=DESKTOP-79CPV12;Initial Catalog=DesignData_Hotel;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
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