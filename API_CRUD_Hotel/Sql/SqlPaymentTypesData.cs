using API_CRUD_Hotel.IServer;
using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Sql
{
    public class SqlPaymentTypesData: BaseRepository<PaymentTypes>, IPaymentTypes
    {
        private HotelsDbContext _hotelDbContext;
        public SqlPaymentTypesData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<PaymentTypes> AddPaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(PaymentTypes, cencellationToken);
        }

        public async Task<bool> DeletePaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(PaymentTypes);
        }

        public IEnumerable<PaymentTypes> GetPaymentTypes()
        {
            return this.GetAll();
        }

        public PaymentTypes GetPaymentTypes(Guid PaymentTypeID)
        {
            return base.GetById(PaymentTypeID);
        }

        public async Task<PaymentTypes> UpdatePaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default)
        {
            var existingPaymentTypes = _hotelDbContext.paymentTypes.FirstOrDefault(x => x.PaymentTypeID == PaymentTypes.PaymentTypeID);
            if(existingPaymentTypes!=null)
            {
                _hotelDbContext.paymentTypes.Update(PaymentTypes);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingPaymentTypes;
        }
    }
}
