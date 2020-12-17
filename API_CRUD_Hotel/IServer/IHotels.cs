using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IHotels
    {
        List<Hotels> GetHotels();
        Hotels GetHotels(Guid HotelID);
        Hotels AddHotels(Hotels hotels);
        void DeleteHotels(Hotels hotels);
        Hotels EditHotels(Hotels hotels);
    }
}
