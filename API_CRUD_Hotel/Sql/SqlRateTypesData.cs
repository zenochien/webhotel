using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlRateTypesData : IRateTypes
    {
        private HotelsDbContext _hotelDbContext;
        public SqlRateTypesData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public RateTypes AddRateTypes(RateTypes RateTypes)
        {
            RateTypes.RateTypeID = Guid.NewGuid();
            _hotelDbContext.rateTypes.Add(RateTypes);
            _hotelDbContext.SaveChanges();
            return RateTypes;
        }

        public void DeleteRateTypes(RateTypes RateTypes)
        {
            _hotelDbContext.rateTypes.Remove(RateTypes);
            _hotelDbContext.SaveChanges();
        }

        public RateTypes EditRateTypes(RateTypes RateTypes)
        {
            var existingRateTypes = _hotelDbContext.rateTypes.Find(RateTypes.RateTypeID);
            if (existingRateTypes != null)
            {
                _hotelDbContext.rateTypes.Update(RateTypes);
                _hotelDbContext.SaveChanges();
            }
            return RateTypes;
        }

        public List<RateTypes> GetRateTypes()
        {
            return _hotelDbContext.rateTypes.ToList();
        }

        public RateTypes GetRateTypes(Guid RateTypesID)
        {
            var rateTypes = _hotelDbContext.rateTypes.Find(RateTypesID);
            return rateTypes;
        }
    }
}
