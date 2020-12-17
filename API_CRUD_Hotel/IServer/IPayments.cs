using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPayments : IRepository<Payments>
    {
        IEnumerator<Payments> GetPayments();
        Payments GetPayments(Guid PaymentID);
        Task<Payments> AddPayments(Payments payments, CancellationToken cencellationToken = default);
        Task<bool> DeletePayments(Payments payments, CancellationToken cencellationToken = default);
        Task<Payments> UpdatePaymentsAsync(Payments payments, CancellationToken cencellationToken = default);
    }
}
