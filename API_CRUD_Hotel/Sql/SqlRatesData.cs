using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRatesData : IRates
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRatesData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Rates AddRates(Rates rates)
        {
            rates.RateID = Guid.NewGuid();
            _hotelDbContext.rates.Add(rates);
            _hotelDbContext.SaveChanges();
            return rates;
        }

        public void DeleteRates(Rates rates)
        {
            _hotelDbContext.rates.Remove(rates);
            _hotelDbContext.SaveChanges();
        }

        public Rates EditRates(Rates rates)
        {
            var existingRates = _hotelDbContext.rates.Find(rates.RateID);
            if (existingRates != null)
            {
                _hotelDbContext.rates.Update(rates);
                _hotelDbContext.SaveChanges();
            }
            return rates;
        }

        public List<Rates> GetRates()
        {
            return _hotelDbContext.rates.ToList();
        }

        public Rates GetRates(Guid RateID)
        {
            var rates = _hotelDbContext.rates.Find(RateID);
            return rates;
        }
    }
}
