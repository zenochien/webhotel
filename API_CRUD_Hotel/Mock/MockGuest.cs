using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CRUD_Hotel.IServer
{
    public class MockGuest : IGuests
    {        
        private List<Guests> Guest = new List<Guests>()
        {
            new Guests()
            {
                GuestID=Guid.NewGuid(),
                FirstName="Anh",
                LastName="Nguyễn Văn",
                Address="20 Thông Nhất",
                Address2="43 Nguyễn Thị Sáu",
                City="Hồ Chí Minh",
                State="?",
                ZipCOde="007",
                Country="VietNam",
                HomePhoneNumber="0123456789",
                CellularNumber="0123456789",
                eMailAddress="nguyenvananh@mail.com",
                Gender="Vietnam"                 
            },
            new Guests()
            {
                GuestID=Guid.NewGuid(),
                FirstName="Mạnh",
                LastName="Nguyễn Văn",
                Address="21 Thông Nhất",
                Address2="33 Nguyễn Minh Khai",
                City="Hồ Chí Minh",
                State="?",
                ZipCOde="007",
                Country="VietNam",
                HomePhoneNumber="0123456789",
                CellularNumber="0123456789",
                eMailAddress="nguyenvanmanh@mail.com",
                Gender="Vietnam"
            }
        };
        public Guests AddGuests(Guests guests)
        {
            guests.GuestID = Guid.NewGuid();
            Guest.Add(guests);
           
            return guests;
        }

        public void DeleteGuests(Guests guests)
        {
            Guest.Remove(guests);

        }

        public Guests EditGuests(Guests guests)
        {
            var existingGuests = GetGuests(guests.GuestID);
            existingGuests.FirstName = guests.FirstName;
            return existingGuests;
        }

        public List<Guests> GetGuests()
        {
            return Guest;
        }

        public Guests GetGuests(Guid GuestID)
        {
            return Guest.SingleOrDefault(x => x.GuestID == GuestID);
        }

    }
}
