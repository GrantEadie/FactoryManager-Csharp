using Microsoft.EntityFrameworkCore;

namespace FactoryManager.Models
{
  public class FactoryManagerContext : DbContext
  {
    
    public virtual DbSet<Engineer> Engineers { get; set; }
    public virtual DbSet<Mission> Missions { get; set; }
    public virtual DbSet<Manifest> Manifests { get; set; }
    public DbSet<MissionManifest> MissionManifest { get; set; }
    public DbSet<EngineerManifest> EngineerManifest { get; set; }
    public DbSet<EngineerMission> EngineerMission { get; set; }
    public FactoryManagerContext(DbContextOptions options) : base(options) { }
  }
}