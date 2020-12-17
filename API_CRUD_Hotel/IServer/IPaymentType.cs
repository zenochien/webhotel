using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPaymentType : IRepository<PaymentTypes>
    {
        IEnumerable<PaymentTypes> GetAllPaymentTypes();
        PaymentTypes GetPaymentTypes(Guid PaymentTypeID);
        Task<PaymentTypes> AddPaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default);
        Task<bool> DeletePaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default);
        Task<PaymentTypes> UpdatePaymentTypesAsync(PaymentTypes PaymentTypes, CancellationToken cencellationToken = default);
    }
}
