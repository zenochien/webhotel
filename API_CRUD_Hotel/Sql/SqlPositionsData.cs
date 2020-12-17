using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlPositionsData : IPositions
    {
        private HotelsDbContext _hotelDbContext;
        public SqlPositionsData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Positions AddPositions(Positions positions)
        {
            positions.PositionID = Guid.NewGuid();
            _hotelDbContext.positions.Add(positions);
            _hotelDbContext.SaveChanges();
            return positions;
        }

        public void DeletePositions(Positions positions)
        {
            _hotelDbContext.positions.Remove(positions);
            _hotelDbContext.SaveChanges();
        }

        public Positions EditPositions(Positions positions)
        {
            var existingPositions = _hotelDbContext.positions.Find(positions.PositionID);
            if (existingPositions != null)
            {
                _hotelDbContext.positions.Update(positions);
                _hotelDbContext.SaveChanges();
            }
            return positions;
        }

        public List<Positions> GetPositions()
        {
            return _hotelDbContext.positions.ToList();
        }

        public Positions GetPositions(Guid PositionID)
        {
            var positions = _hotelDbContext.positions.Find(PositionID);
            return positions;
        }
    }
}
