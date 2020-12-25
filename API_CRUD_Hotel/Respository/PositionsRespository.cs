using API_CRUD_Hotel.IServer;
using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class PositionsRespository : BaseRepository<Positions>, IPositions
    {
        private HotelsDbContext _hotelDbContext;
        public PositionsRespository(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Positions> AddPositionsAsync(Positions positions, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(positions, cencellationToken);
        }

        public async Task<bool> DeletePositionsAsync(Positions positions, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(positions);
        }

        public IEnumerable<Positions> GetAllPositions()
        {
            return this.GetAll();
        }

        public Positions GetPositions(Guid PositionID)
        {
            return base.GetById(PositionID);
        }

        public async Task<Positions> UpdatePositions(Positions positions, CancellationToken cencellationToken = default)
        {
            var existingPosition = _hotelDbContext.positions.FirstOrDefault(x => x.PositionID == positions.PositionID);
            if(existingPosition!=null)
            {
                _hotelDbContext.positions.Update(positions);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingPosition;
        }
    }
}
