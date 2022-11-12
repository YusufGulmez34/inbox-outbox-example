using InBoxOutBoxExample.Application.Abstractions.Repositories.Read;
using InBoxOutBoxExample.Domain;
using InBoxOutBoxExample.Persistence.Contexts;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace InBoxOutBoxExample.Persistence.Repositories.Read
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseBson
    {
        private readonly InBoxOutBoxExampleReadDbContext _context;

        public ReadRepository(InBoxOutBoxExampleReadDbContext context)
        {
            _context = context;
        }

        public List<T> FindWhere(Expression<Func<T, bool>> filter)
        {
            return _context.GetCollection<T>().Find(filter).ToList();
        }

        public List<T> GetAll()
        {
            return _context.GetCollection<T>().AsQueryable().ToList();
        }

        public T GetById(int id)
        {
            return _context.GetCollection<T>().Find(x => x.Id == id).Single();
        }
    }
}
