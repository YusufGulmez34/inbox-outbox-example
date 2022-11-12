using InBoxOutBoxExample.Domain;
using InBoxOutBoxExample.Domain.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBoxOutBoxExample.Application.Abstractions.Repositories.Write
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        Task<bool> DeleteByIdAsync(int id);
        Task<int> SaveAndPublish<TEntity>(TEntity entity, string type, string queue, string routingKey, string exchange);
        Task<T> FindById(int id);
    }
}
