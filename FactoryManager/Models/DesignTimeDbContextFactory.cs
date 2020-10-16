using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FactoryManager.Models
{
  public class FactoryManagerContextFactory : IDesignTimeDbContextFactory<FactoryManagerContext>
  {
    FactoryManagerContext IDesignTimeDbContextFactory<FactoryManagerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<FactoryManagerContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new FactoryManagerContext(builder.Options);
    }
  }
}