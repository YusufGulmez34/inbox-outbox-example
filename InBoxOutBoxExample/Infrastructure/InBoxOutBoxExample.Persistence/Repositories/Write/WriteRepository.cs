using InBoxOutBoxExample.Application.Abstractions.MessageBroker;
using InBoxOutBoxExample.Application.Abstractions.Repositories.Write;
using InBoxOutBoxExample.Domain;
using InBoxOutBoxExample.Domain.Write.Entities;
using InBoxOutBoxExample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace InBoxOutBoxExample.Persistence.Repositories.Write
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly InBoxOutBoxExampleWriteDbContext _context;

        public WriteRepository(InBoxOutBoxExampleWriteDbContext context)
        {
            _context = context;
        }

        public InBoxOutBoxExampleWriteDbContext Context { get { return _context; } }

        public virtual async Task<bool> AddAsync(T entity)
        {
            EntityEntry entry = await _context.AddAsync<T>(entity);
            return entry.State == EntityState.Added;
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            T entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                return false;
            }
            EntityEntry entry = _context.Remove<T>(entity);
            return entry.State == EntityState.Deleted;
        }
        public virtual bool Update(T entity)
        {

            EntityEntry entry = _context.Set<T>().Update(entity);
            return entry.State == EntityState.Modified;

        }
        public virtual async Task<T> FindById(int id) {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }
        public virtual Task<int> SaveAndPublish<TEntity>(TEntity entity, string type, string queue, string routingKey, string exchange)
        {
            return null;
        }



    }
}
