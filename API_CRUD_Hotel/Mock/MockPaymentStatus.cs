using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockPaymentStatus : IPaymentStatus
    {
        private List<PaymentStatus> paymentStatuses = new List<PaymentStatus>()
        {
            new PaymentStatus()
            {
                PaymentStatusID=Guid.NewGuid(),
                Status="123",
                Description="12334",
                SortOrder="2312",
                Active="123123"
            },
            new PaymentStatus()
            {
                PaymentStatusID=Guid.NewGuid(),
                Status="123",
                Description="12334",
                SortOrder="2312",
                Active="123123"
            }
        };
        public PaymentStatus AddPaymentStatus(PaymentStatus PaymentStatus)
        {
            PaymentStatus.PaymentStatusID = Guid.NewGuid();
            paymentStatuses.Add(PaymentStatus);
            return PaymentStatus;
        }

        public void DeletePaymentStatus(PaymentStatus PaymentStatus)
        {
            paymentStatuses.Remove(PaymentStatus);
        }

        public PaymentStatus EditPaymentStatus(PaymentStatus PaymentStatus)
        {
            var existingPaymentStatus = GetPaymentStatus(PaymentStatus.PaymentStatusID);
            existingPaymentStatus.Status = PaymentStatus.Status;
            return existingPaymentStatus;
        }

        public List<PaymentStatus> GetPaymentStatus()
        {
            return paymentStatuses;
        }

        public PaymentStatus GetPaymentStatus(Guid PaymentStatusID)
        {
            return paymentStatuses.SingleOrDefault(x => x.PaymentStatusID == PaymentStatusID);
        }
    }
}
