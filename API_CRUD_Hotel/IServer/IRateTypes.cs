using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRateTypes: IRepository<RateTypes>
    {
        IEnumerable<RateTypes> GetAllRateTypes();
        RateTypes GetRateTypes(Guid RateTypesID);
        Task<RateTypes> AddRateTypesAsync(RateTypes RateTypes, CancellationToken cencellationToken = default);
        Task<bool> DeleteRateTypesAsync(RateTypes RateTypes, CancellationToken cencellationToken = default);
        Task<RateTypes> UpdateRateTypesAsync(RateTypes RateTypes, CancellationToken cencellationToken = default);
    }
}
