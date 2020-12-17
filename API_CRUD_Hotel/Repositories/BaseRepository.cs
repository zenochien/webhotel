using DesignDatabaseHotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API_CRUD_Hotel.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly HotelsDbContext _context;

        public BaseRepository(HotelsDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
            return await _context.SaveChangesAsync(default) > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}