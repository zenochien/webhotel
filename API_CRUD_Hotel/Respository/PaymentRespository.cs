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
    public class PaymentRespository : BaseRepository<Payments>, IPayments
    {
        private HotelsDbContext _hotelDbContext;
        public PaymentRespository(HotelsDbContext hotelsDbContext) : base(hotelsDbContext)
        {
            _hotelDbContext = hotelsDbContext;
        }

        public async Task<Payments> AddPayments(Payments payments, CancellationToken cencellationToken = default)
        {
            return await CreateAsync(payments, cencellationToken);
        }

        public async Task<bool> DeletePayments(Payments payments, CancellationToken cencellationToken = default)
        {
            return await this.DeleteAsync(payments);
        }

        public IEnumerable<Payments> GetAllPayments()
        {
            return this.GetAll();
        }

        public Payments GetPayments(Guid PaymentID)
        {
            return base.GetById(PaymentID);
        }

        public async Task<Payments> UpdatePaymentsAsync(Payments payments, CancellationToken cencellationToken = default)
        {
            var existingPayments = _hotelDbContext.payments.FirstOrDefault(x => x.PaymentID == payments.PaymentID);
            if (existingPayments != null)
            {
                _hotelDbContext.payments.Update(payments);
                await _hotelDbContext.SaveChangesAsync(cencellationToken);
            }
            return existingPayments;
        }
    }
}
