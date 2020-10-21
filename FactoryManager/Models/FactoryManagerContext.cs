using Microsoft.EntityFrameworkCore;

namespace FactoryManager.Models
{
  public class FactoryManagerContext : DbContext
  {
    
    public virtual DbSet<Engineer> Engineers { get; set; }
    public virtual DbSet<Machine> Machines { get; set; }
    public virtual DbSet<Incident> Incidents { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public DbSet<MachineLocation> MachineLocation { get; set; }
    public DbSet<IncidentLocation> IncidentLocation { get; set; }
    public DbSet<MachineIncident> MachineIncident { get; set; }
    public DbSet<EngineerIncident> EngineerIncident { get; set; }
    public DbSet<EngineerMachine> EngineerMachine { get; set; }
    public FactoryManagerContext(DbContextOptions options) : base(options) { }
  }
}