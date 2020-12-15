using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockRateTypes : IRateTypes
    {
        private List<RateTypes> rateType = new List<RateTypes>()
        {
            new RateTypes()
            {
                RateTypeID=Guid.NewGuid(),
                RateType="vip",
                Description="sss",
                SortOrder="123",
                Active="có"
            },
            new RateTypes()
            {
                RateTypeID=Guid.NewGuid(),
                RateType="thường",
                Description="aaa",
                SortOrder="aaa",
                Active="có"
            }
        };
        public RateTypes AddRateTypes(RateTypes RateTypes)
        {
            RateTypes.RateTypeID = Guid.NewGuid();
            rateType.Add(RateTypes);
            return RateTypes;
        }

        public void DeleteRateTypes(RateTypes RateTypes)
        {
            rateType.Remove(RateTypes);
        }

        public RateTypes EditRateTypes(RateTypes RateTypes)
        {
            var existingRateTypes = GetRateTypes(RateTypes.RateTypeID);
            existingRateTypes.RateType = RateTypes.RateType;
            return existingRateTypes;
        }

        public List<RateTypes> GetRateTypes()
        {
            return rateType;
        }

        public RateTypes GetRateTypes(Guid RateTypesID)
        {
            return rateType.SingleOrDefault(x => x.RateTypeID == RateTypesID);
        }
    }
}
