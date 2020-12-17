using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlPaymentData : IPayments
    {
        private HotelsDbContext _hotelDbContext;
        public SqlPaymentData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public Payments AddPayments(Payments payments)
        {
            payments.PaymentID = Guid.NewGuid();
            _hotelDbContext.payments.Add(payments);
            _hotelDbContext.SaveChanges();
            return payments;
        }

        public void DeletePayments(Payments payments)
        {
            _hotelDbContext.payments.Remove(payments);
            _hotelDbContext.SaveChanges();
        }

        public Payments EditPayments(Payments payments)
        {
            var existingPayments = _hotelDbContext.payments.Find(payments.PaymentID);
            if(existingPayments!=null)
            {
                _hotelDbContext.payments.Update(payments);
                _hotelDbContext.SaveChanges();
            }
            return payments;  
        }

        public List<Payments> GetPayments()
        {
            return _hotelDbContext.payments.ToList();
        }

        public Payments GetPayments(Guid PaymentID)
        {
            var payments = _hotelDbContext.rooms.Find(PaymentID);
            return payments;
        }
    }
}
