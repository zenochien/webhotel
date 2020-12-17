using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockPositions : IPositions
    {
        private List<Positions> Position = new List<Positions>()
        {
            new Positions()
            {
                PositionID=Guid.NewGuid(),
                Position="asdf",
                SortOrder="123",
                Active="có"
            },
            new Positions()
            {
                PositionID=Guid.NewGuid(),
                Position="asdf",
                SortOrder="123",
                Active="có"
            }
        };
        public Positions AddPositions(Positions positions)
        {
            positions.PositionID = Guid.NewGuid();
            Position.Add(positions);
            return positions;
        }

        public void DeletePositions(Positions positions)
        {
            Position.Remove(positions);
        }

        public Positions EditPositions(Positions positions)
        {
            var existingPositions = GetPositions(positions.PositionID);
            existingPositions.Position = positions.Position;
            return existingPositions;
        }

        public List<Positions> GetPositions()
        {
            return Position;
        }

        public Positions GetPositions(Guid PositionID)
        {
            return Position.SingleOrDefault(x => x.PositionID == PositionID);
        }
    }
}
