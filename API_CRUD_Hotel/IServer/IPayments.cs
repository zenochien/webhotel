using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPayments
    {
        List<Payments> GetPayments();
        Payments GetPayments(Guid PaymentID);
        Payments AddPayments(Payments payments);
        void DeletePayments(Payments payments);
        Payments EditPayments(Payments payments);
    }
}
