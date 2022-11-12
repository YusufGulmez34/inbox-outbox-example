using InBoxOutBoxExample.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InBoxOutBoxExample.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InBoxOutBoxExampleWriteDbContext>
{
    public InBoxOutBoxExampleWriteDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<InBoxOutBoxExampleWriteDbContext>();
        optionsBuilder.UseNpgsql(Configuration.PostgreSQLConnectionString);
        return new InBoxOutBoxExampleWriteDbContext(optionsBuilder.Options);
    }
}