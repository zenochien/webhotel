using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_CRUD_Hotel.Mock
{
    public class MockRoomTypes : IRoomTypes
    {
        private List<RoomTypes> RoomType = new List<RoomTypes>()
        {
            new RoomTypes()
            {
                RoomTypeID=Guid.NewGuid(),
                RoomType="vip",
                Description="sss",
                SortOrder="123",
                Active="có"
            },
            new RoomTypes()
            {
                RoomTypeID=Guid.NewGuid(),
                RoomType="thường",
                Description="aaa",
                SortOrder="aaa",
                Active="có"
            }
        };
        public RoomTypes AddRoomTypes(RoomTypes roomTypes)
        {
            roomTypes.RoomTypeID = Guid.NewGuid();
            RoomType.Add(roomTypes);
            return roomTypes;
        }

        public void DeleteRoomTypes(RoomTypes roomTypes)
        {
            RoomType.Remove(roomTypes);
        }

        public RoomTypes EditRoomTypes(RoomTypes roomTypes)
        {
            var existingRoomTypes = GetRoomTypes(roomTypes.RoomTypeID);
            existingRoomTypes.RoomTypeID = roomTypes.RoomTypeID;
            return existingRoomTypes;
        }

        public List<RoomTypes> GetRoomTypes()
        {
            return RoomType;
        }

        public RoomTypes GetRoomTypes(Guid RoomTypesID)
        {
            return RoomType.SingleOrDefault(x => x.RoomTypeID == RoomTypesID);
        }
    }
}
