using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRateTypes
    {
        List<RateTypes> GetRateTypes();
        RateTypes GetRateTypes(Guid RateTypesID);
        RateTypes AddRateTypes(RateTypes RateTypes);
        void DeleteRateTypes(RateTypes RateTypes);
        RateTypes EditRateTypes(RateTypes RateTypes);
    }
}
