using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Incident
  {
    public Incident()
    {
      this.Machines = new HashSet<MachineIncident>() ;
      this.Engineers = new HashSet<EngineerIncident>();
    }
    public int IncidentId { get; set; }
    public string IncidentTitle { get; set; }
    public string IncidentDamage { get; set; }
    public int LocationId { get; set; }
    public virtual Location Location { get; set; }
    public virtual ICollection<EngineerIncident> Engineers { get; set; }
    public virtual ICollection<MachineIncident> Machines { get; set; }
  }
}