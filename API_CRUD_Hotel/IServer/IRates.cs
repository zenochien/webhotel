using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRates
    {
        List<Rates> GetRates();
        Rates GetRates(Guid RateID);
        Rates AddRates(Rates rates);
        void DeleteRates(Rates rates);
        Rates EditRates(Rates rates);
    }
}
