using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlHotelData : IHotels
    {
        private HotelsDbContext _hotelDbContext;
        public SqlHotelData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Hotels AddHotels(Hotels hotels)
        {
            hotels.HotelID = Guid.NewGuid();
            _hotelDbContext.hotels.Add(hotels);
            _hotelDbContext.SaveChanges();
            return hotels;
        }

        public void DeleteHotels(Hotels hotels)
        {
            _hotelDbContext.hotels.Remove(hotels);
            _hotelDbContext.SaveChanges();
        }

        public Hotels EditHotels(Hotels hotels)
        {
            var existHotel = _hotelDbContext.hotels.Find(hotels.HotelID);
            if (existHotel != null)
            {
                _hotelDbContext.hotels.Update(existHotel);
                _hotelDbContext.SaveChanges();
            }
            return hotels;
        }

        public List<Hotels> GetHotels()
        {
            return _hotelDbContext.hotels.ToList();
        }

        public Hotels GetHotels(Guid HotelID)
        {
            var hotels = _hotelDbContext.hotels.Find(HotelID);
            return hotels;
        }
    }
}

