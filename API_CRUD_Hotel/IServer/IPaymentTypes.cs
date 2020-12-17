using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPaymentTypes
    {
        List<PaymentTypes> GetPaymentTypes();
        PaymentTypes GetPaymentTypes(Guid PaymentTypeID);
        PaymentTypes AddPaymentTypes(PaymentTypes PaymentTypes);
        void DeletePaymentTypes(PaymentTypes PaymentTypes);
        PaymentTypes EditPaymentTypes(PaymentTypes PaymentTypes);
    }
}
