using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockPayments : IPayments
    {
        private List<Payments> Payment = new List<Payments>()
        {
            new Payments()
            {
                PaymentID=Guid.NewGuid(),
                RoomID=Guid.NewGuid(),
                Date=new DateTime(2020,12,03),
                Payment="3025",
                PaymentStatsID=Guid.NewGuid(),
                PaymentTypeID=Guid.NewGuid()
            },
             new Payments()
            {
                PaymentID=Guid.NewGuid(),
                RoomID=Guid.NewGuid(),
                Date=new DateTime(2020,01,03),
                Payment="2450",
                PaymentStatsID=Guid.NewGuid(),
                PaymentTypeID=Guid.NewGuid()
            },
        };
        public Payments AddPayments(Payments payments)
        {
            payments.PaymentID = Guid.NewGuid();
            Payment.Add(payments);
            return payments;
        }

        public void DeletePayments(Payments payments)
        {
            Payment.Remove(payments);
        }

        public Payments EditPayments(Payments payments)
        {
            var existPayments = GetPayments(payments.PaymentID);
            existPayments.Payment = payments.Payment;
            return existPayments;
        }

        public List<Payments> GetPayments()
        {
            return Payment;
        }

        public Payments GetPayments(Guid PaymentID)
        {
            return Payment.SingleOrDefault(x => x.PaymentID == PaymentID);
        }
    }
}
