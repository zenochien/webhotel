using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockHotels : IHotels
    {
        private List<Hotels> Hotel = new List<Hotels>()
        {
            new Hotels()
            {
                HotelID=Guid.NewGuid(),
                HotelCode="1234",
                Name="Spa Biển Đep5",
                Motto="SSS",
                Address="43 Nguyễn Thị Sáu",
                Address2="",
                City="Hồ Chí Minh",
                State="?",
                ZipCOde="007",
                MainPhoneNumber="123456789",
                FaxNumber="0123456789",
                TooIIFreeNumber="0123456789",
                CompanyeMailAddress="nguyenvananh@mail.com",
                WebsiteAddress="Vietnam",
                Main="AAAA",
                ImagePath="AAAAA",
            },
              new Hotels()
            {
                HotelID=Guid.NewGuid(),
                HotelCode="1234",
                Name="Spa Biển Đep5",
                Motto="SSS",
                Address="43 Nguyễn Thị Sáu",
                Address2="",
                City="Hồ Chí Minh",
                State="?",
                ZipCOde="007",
                MainPhoneNumber="123456789",
                FaxNumber="0123456789",
                TooIIFreeNumber="0123456789",
                CompanyeMailAddress="nguyenvananh@mail.com",
                WebsiteAddress="Vietnam",
                Main="AAAA",
                ImagePath="AAAAA",
            }
        };

        public Hotels AddHotels(Hotels hotels)
        {
            hotels.HotelID = Guid.NewGuid();
            Hotel.Add(hotels);

            return hotels;
        }

        public void DeleteHotels(Hotels hotels)
        {
            Hotel.Remove(hotels);
        }

        public Hotels EditHotels(Hotels hotels)
        {
            var existHotels = GetHotels(hotels.HotelID);
            existHotels.Name = hotels.Name;
            return existHotels;
        }

        public List<Hotels> GetHotels()
        {
            return Hotel;
        }

        public Hotels GetHotels(Guid HotelID)
        {
            return Hotel.SingleOrDefault(x => x.HotelID == HotelID);
        }
    }
}
