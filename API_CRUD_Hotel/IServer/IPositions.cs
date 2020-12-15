using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPositions
    {
        List<Positions> GetPositions();
        Positions GetPositions(Guid PositionID);
        Positions AddPositions(Positions positions);
        void DeletePositions(Positions positions);
        Positions EditPositions(Positions positions);
    }
}
