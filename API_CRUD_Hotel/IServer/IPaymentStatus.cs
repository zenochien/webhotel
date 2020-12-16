using API_CRUD_Hotel.Repositories;
using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.IServer
{
    public interface IPaymentStatus : IRepository<PaymentStatus>
    {
        IEnumerator<PaymentStatus> GetPaymentStatus();
        PaymentStatus GetPaymentStatus(Guid PaymentStatusID);
        Task<PaymentStatus> AddPaymentStatusAsync(PaymentStatus PaymentStatus, CancellationToken cencellationToken = default);
        Task<bool> DeletePaymentStatusAsync(PaymentStatus PaymentStatus, CancellationToken cencellationToken = default);
        Task<PaymentStatus> UpdatePaymentStatusAsync(PaymentStatus PaymentStatus, CancellationToken cencellationToken = default);
    }
}
