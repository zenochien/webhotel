using API_CRUD_Hotel.IServer;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlPaymentTypesData:IPaymentTypes
    {
        private HotelsDbContext _hotelDbContext;
        public SqlPaymentTypesData(HotelsDbContext hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public PaymentTypes AddPaymentTypes(PaymentTypes PaymentTypes)
        {
            PaymentTypes.PaymentTypeID = Guid.NewGuid();
            _hotelDbContext.paymentTypes.Add(PaymentTypes);
            _hotelDbContext.SaveChanges();
            return PaymentTypes;
        }

        public void DeletePaymentTypes(PaymentTypes PaymentTypes)
        {
            _hotelDbContext.paymentTypes.Remove(PaymentTypes);
            _hotelDbContext.SaveChanges();
        }

        public PaymentTypes EditPaymentTypes(PaymentTypes PaymentTypes)
        {
            var existingPaymentTypes = _hotelDbContext.paymentTypes.Find(PaymentTypes.PaymentTypeID);
            if (existingPaymentTypes != null)
            {
                _hotelDbContext.paymentTypes.Update(PaymentTypes);
                _hotelDbContext.SaveChanges();
            }
            return PaymentTypes;
        }

        public List<PaymentTypes> GetPaymentTypes()
        {
            return _hotelDbContext.paymentTypes.ToList();
        }

        public PaymentTypes GetPaymentTypes(Guid PaymentTypeID)
        {
            var paymentType = _hotelDbContext.paymentTypes.Find(PaymentTypeID);
            return paymentType;
        }
    }
}
