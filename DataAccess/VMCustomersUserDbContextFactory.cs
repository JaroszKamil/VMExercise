
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess
{
    public class VMCustomersUserDbContextFactory : IDesignTimeDbContextFactory<VMDBContext>
    {
        public VMDBContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<VMDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("VMCustomersDBConnection"));

            return new VMDBContext(optionsBuilder.Options);
        }
    }
}
