using InBoxOutBoxExample.Domain.Write.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBoxOutBoxExample.Application.Abstractions.Repositories.Write
{
    public interface IProductWriteRepository : IWriteRepository<Product>
    {
    }
}
