using iShop.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace iShop.Infrastructure.EF
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString(SystemConstants.DbConnection);
            var optionsBuilder = new DbContextOptionsBuilder<StoreDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new StoreDbContext(optionsBuilder.Options);
        }

    }
}
