using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Location
  {
    public Location()
    {
      this.Machines = new HashSet<MachineLocation>();
      this.Incidents = new HashSet<IncidentLocation>();
    }
    public int LocationId { get; set; }
    public string LocationName { get; set; }
    public virtual ICollection<MachineLocation> Machines { get; set; }
    public virtual ICollection<IncidentLocation> Incidents { get; set; }
  }
}