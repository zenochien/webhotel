using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPaymentTypes : IRepository<PaymentTypes>
    {
        IEnumerable<PaymentTypes> GetPaymentTypes();
        PaymentTypes GetPaymentTypes(Guid PaymentTypeID);
        Task<PaymentTypes> AddPaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default);
        Task<bool> DeletePaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default);
        Task<PaymentTypes> UpdatePaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default);
    }
}
