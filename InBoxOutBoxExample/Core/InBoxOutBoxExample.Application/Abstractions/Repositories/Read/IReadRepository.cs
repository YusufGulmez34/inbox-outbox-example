using InBoxOutBoxExample.Domain;
using System.Linq.Expressions;

namespace InBoxOutBoxExample.Application.Abstractions.Repositories.Read
{
    public interface IReadRepository<T> where T : BaseBson
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> FindWhere(Expression<Func<T,bool>> filter);

    }
}
