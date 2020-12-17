using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CRUD_Hotel.Mock
{
    public class MockRates : IRates
    {
        private List<Rates> Ratess = new List<Rates>()
        {
            new Rates()
            {
                RateID=Guid.NewGuid(),
                RoomID=Guid.NewGuid(),
                FromDate=new DateTime(2020,01,02),
                ToDate=new DateTime(2020,05,30),
                RateTypeID=Guid.NewGuid()
            },
            new Rates()
            {
                RateID=Guid.NewGuid(),
                RoomID=Guid.NewGuid(),
                FromDate=new DateTime(2020,01,02),
                ToDate=new DateTime(2020,05,30),
                RateTypeID=Guid.NewGuid()
            }
        };
        public Rates AddRates(Rates rates)
        {
            rates.RateID = Guid.NewGuid();
            Ratess.Add(rates);
            return rates;
        }

        public void DeleteRates(Rates rates)
        {
            Ratess.Remove(rates);
        }

        public Rates EditRates(Rates rates)
        {
            var existingRates = GetRates(rates.RateID);
            existingRates.Rate = rates.Rate;
            return existingRates;
        }

        public List<Rates> GetRates()
        {
            return Ratess;
        }

        public Rates GetRates(Guid RateID)
        {
            return Ratess.SingleOrDefault(x => x.RateID == RateID);
        }
    }
}
