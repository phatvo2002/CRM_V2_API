using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Persistence
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<CrmDbContext>
    {
        public CrmDbContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            var apiPath = Path.Combine(basePath, "../CRM.API");

            var config = new ConfigurationBuilder()
                .SetBasePath(apiPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CrmDbContext>();

            var dsBuilder = new NpgsqlDataSourceBuilder(connectionString);
            dsBuilder.MapEnum<TinhTrang>();   
            var dataSource = dsBuilder.Build();

            optionsBuilder.UseNpgsql(dataSource);  

            return new CrmDbContext(optionsBuilder.Options);
        }
    }
}
