using InBoxOutBoxExample.Application.Abstractions.Repositories.Read;
using InBoxOutBoxExample.Domain.Read.Entities;
using InBoxOutBoxExample.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBoxOutBoxExample.Persistence.Repositories.Read
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(InBoxOutBoxExampleReadDbContext context) : base(context)
        {
        }
    }
}
