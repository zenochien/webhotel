using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlPaymentStatusData:IPaymentStatus
    {
        private HotelsDbContext _hotelDbContext;
        public SqlPaymentStatusData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public PaymentStatus AddPaymentStatus(PaymentStatus PaymentStatus)
        {
            PaymentStatus.PaymentStatusID = Guid.NewGuid();
            _hotelDbContext.paymentStatuses.Add(PaymentStatus);
            _hotelDbContext.SaveChanges();
            return PaymentStatus;
        }

        public void DeletePaymentStatus(PaymentStatus PaymentStatus)
        {
            _hotelDbContext.paymentStatuses.Remove(PaymentStatus);
            _hotelDbContext.SaveChanges();
        }

        public PaymentStatus EditPaymentStatus(PaymentStatus PaymentStatus)
        {
            var existingPaymentStatus = _hotelDbContext.paymentStatuses.Find(PaymentStatus.PaymentStatusID);
            if (existingPaymentStatus != null)
            {
                _hotelDbContext.paymentStatuses.Update(PaymentStatus);
                _hotelDbContext.SaveChanges();
            }
            return PaymentStatus;
        }

        public List<PaymentStatus> GetPaymentStatus()
        {
            return _hotelDbContext.paymentStatuses.ToList();
        }

        public PaymentStatus GetPaymentStatus(Guid PaymentStatusID)
        {
            var paymentStatus = _hotelDbContext.paymentStatuses.Find(PaymentStatusID);
            return paymentStatus;
        }
    }
}
