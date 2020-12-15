using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IGuests
    {
        List<Guests> GetGuests();
        Guests GetGuests(Guid GuestID);
        Guests AddGuests(Guests guests);
        void DeleteGuests(Guests guests);
        Guests EditGuests(Guests guests);
    }
}
