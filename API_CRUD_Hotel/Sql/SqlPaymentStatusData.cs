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
    public class SqlPaymentStatusData : BaseRepository<PaymentStatus>, IPaymentStatus
    {
        private HotelsDbContext _hotelDbContext;
        public SqlPaymentStatusData(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<PaymentStatus> AddPaymentStatusAsync(PaymentStatus PaymentStatus, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(PaymentStatus, cencellationToken);
        }

        public async Task<bool> DeletePaymentStatusAsync(PaymentStatus PaymentStatus, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(PaymentStatus);
        }

        public IEnumerator<PaymentStatus> GetPaymentStatus()
        {
            return this.GetAll();
        }

        public PaymentStatus GetPaymentStatus(Guid PaymentStatusID)
        {
            return base.GetById(PaymentStatusID);
        }

        public async Task<PaymentStatus> UpdatePaymentStatusAsync(PaymentStatus PaymentStatus, CancellationToken cencellationToken = default)
        {
            var existingPaymentStatus = _hotelDbContext.paymentStatuses.FirstOrDefault(x => x.PaymentStatusID == PaymentStatus.PaymentStatusID);
            if(PaymentStatus!=null)
            {
                _hotelDbContext.paymentStatuses.Update(existingPaymentStatus);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingPaymentStatus;
        }
    }
}
