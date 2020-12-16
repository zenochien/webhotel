using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPositions : IRepository<Positions>
    {
        IEnumerable<Positions> GetPositions();
        Positions GetPositions(Guid PositionID);
        Task<Positions> AddPositionsAsync(Positions positions, CancellationToken cencellationToken = default);
        Task<bool> DeletePositionsAsync(Positions positions, CancellationToken cencellationToken = default);
        Task<Positions> UpdatePositions(Positions positions, CancellationToken cencellationToken = default);
    }
}
