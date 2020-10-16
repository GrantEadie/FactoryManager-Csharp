using Microsoft.EntityFrameworkCore;

namespace FactoryManager.Models
{
  public class FactoryManagerContext : DbContext
  {
    
    public virtual DbSet<Engineer> Engineers { get; set; }
    public virtual DbSet<Machine> Machines { get; set; }
    public virtual DbSet<Incident> Incidents { get; set; }
    public DbSet<MachineIncident> MachineIncident { get; set; }
    public DbSet<EngineerIncident> EngineerIncident { get; set; }
    public DbSet<EngineerMachine> EngineerMachine { get; set; }
    public FactoryManagerContext(DbContextOptions options) : base(options) { }
  }
}