using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Repositories
{
    public interface IRepository<T>
    {
        T GetById(object id);

        IEnumerable<T> GetAll();

        Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(object id, CancellationToken cancellationToken = default);
    }
}