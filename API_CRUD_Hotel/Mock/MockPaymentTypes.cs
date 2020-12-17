using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Mock
{
    public class MockPaymentTypes : IPaymentTypes
    {
        private List<PaymentTypes> paymentType = new List<PaymentTypes>()
        {
            new PaymentTypes()
            {
                PaymentTypeID=Guid.NewGuid(),
                PaymentType="vip",
                SortOrder="123",
                Active="có"
            },
            new PaymentTypes()
            {
                PaymentTypeID=Guid.NewGuid(),
                PaymentType="vip",
                SortOrder="123",
                Active="có"
            }
        };
        public PaymentTypes AddPaymentTypes(PaymentTypes PaymentTypes)
        {
            PaymentTypes.PaymentTypeID = Guid.NewGuid();
            paymentType.Add(PaymentTypes);
            return PaymentTypes;
        }

        public void DeletePaymentTypes(PaymentTypes PaymentTypes)
        {
            paymentType.Remove(PaymentTypes);
        }

        public PaymentTypes EditPaymentTypes(PaymentTypes PaymentTypes)
        {
            var existingPaymentTypes = GetPaymentTypes(PaymentTypes.PaymentTypeID);
            existingPaymentTypes.PaymentType = PaymentTypes.PaymentType;
            return existingPaymentTypes;
        }

        public List<PaymentTypes> GetPaymentTypes()
        {
            return paymentType;
        }

        public PaymentTypes GetPaymentTypes(Guid PaymentTypeID)
        {
            return paymentType.SingleOrDefault(x => x.PaymentTypeID == PaymentTypeID);
        }
    }
}
