using InBoxOutBoxExample.Domain.Read.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBoxOutBoxExample.Application.Abstractions.Repositories.Read
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}
