using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlGuestData : IGuests
    {
        private HotelsDbContext _hotelDbContext;
        public SqlGuestData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }
        public Guests AddGuests(Guests guests)
        {
            guests.GuestID = Guid.NewGuid();
            _hotelDbContext.guests.Add(guests);
            _hotelDbContext.SaveChanges();
            return guests;
        }

        public void DeleteGuests(Guests guests)
        {           
            _hotelDbContext.guests.Remove(guests);
            _hotelDbContext.SaveChanges();
        }

        public Guests EditGuests(Guests guests)
        {
            var existingGuests = _hotelDbContext.guests.Find(guests.GuestID);
            if (existingGuests != null)
            {
                _hotelDbContext.guests.Update(guests);
                _hotelDbContext.SaveChanges();
            }
            return guests;
        }

        public List<Guests> GetGuests()
        {
           return _hotelDbContext.guests.ToList();
        }

        public Guests GetGuests(Guid GuestID)
        {
            var guests = _hotelDbContext.guests.Find(GuestID);
            return guests;
        }
    }
}
