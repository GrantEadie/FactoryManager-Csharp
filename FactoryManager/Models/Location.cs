using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Location
  {
    public Location()
    {
      this.Machines = new HashSet<Machine>();
      this.Incidents = new HashSet<Incident>();
    }
    public int LocationId { get; set; }
    public string LocationName { get; set; }
    public virtual ICollection<Machine> Machines { get; set; }
    public virtual ICollection<Incident> Incidents { get; set; }
  }
}