using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockReservationAgents : IReservationAgents
    {
        private List<ReservationAgents> ReservationAgent = new List<ReservationAgents>()
        {
             new ReservationAgents()
            {
                ReservationAgentID=Guid.NewGuid(),
                FirstName="Hùng",
                LastName="Phạm Mạnh",
                Address="32 Thị Yến",
                Address2="21 Nguyễn Thị Sáu",
                City="Hồ Chí Minh",
                State="?",
                ZipCOde="333",
                Country="VietNam",
                HomePhoneNumber="0123456789",
                CellularNumber="0123456789",
                eMailAddress="phammanhhung@mail.com",
                Gender="Vietnam"
            },
            new ReservationAgents()
            {
                ReservationAgentID=Guid.NewGuid(),
                FirstName="Thìa",
                LastName="Hương Văn",
                Address="21 Thông Mông",
                Address2="33 Nguyễn Minh Mạnh",
                City="Hồ Chí Minh",
                State="?",
                ZipCOde="443",
                Country="VietNam",
                HomePhoneNumber="0123456789",
                CellularNumber="0123456789",
                eMailAddress="huongvanthia@mail.com",
                Gender="Vietnam"
            }
        };
        public ReservationAgents AddReservationAgents(ReservationAgents reservationAgents)
        {
            reservationAgents.ReservationAgentID = Guid.NewGuid();
            ReservationAgent.Add(reservationAgents);
            return reservationAgents;
        }

        public void DeleteReservationAgents(ReservationAgents reservationAgents)
        {
            ReservationAgent.Remove(reservationAgents);
        }

        public ReservationAgents EditReservationAgents(ReservationAgents reservationAgents)
        {
            var existRA = GetReservationAgents(reservationAgents.ReservationAgentID);
            existRA.FirstName = reservationAgents.FirstName;
            return existRA;
        }

        public List<ReservationAgents> GetReservationAgents()
        {
            return ReservationAgent;
        }

        public ReservationAgents GetReservationAgents(Guid ReservationAgentID)
        {
            return ReservationAgent.SingleOrDefault(x => x.ReservationAgentID == ReservationAgentID);
        }
    }
}
