using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPaymentStatus
    {
        List<PaymentStatus> GetPaymentStatus();
        PaymentStatus GetPaymentStatus(Guid PaymentStatusID);
        PaymentStatus AddPaymentStatus(PaymentStatus PaymentStatus);
        void DeletePaymentStatus(PaymentStatus PaymentStatus);
        PaymentStatus EditPaymentStatus(PaymentStatus PaymentStatus);
    }
}
