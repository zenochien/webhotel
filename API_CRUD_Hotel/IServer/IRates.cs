using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IRates : IRepository<Rates>
    {
        IEnumerable<Rates> GetAllRates();
        Rates GetRates(Guid RateID);
        Task<Rates> AddRatesAsync(Rates rates, CancellationToken cencellationToken = default);
        Task<bool> DeleteRatesAsync(Rates rates, CancellationToken cencellationToken = default);
        Task<Rates> UpdateRatesAsync(Rates rates, CancellationToken cencellationToken = default);
    }
}
