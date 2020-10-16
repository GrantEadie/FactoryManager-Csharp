using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HashSet<EngineerMachine>();
      this.Incidents = new HashSet<MachineIncident>();
    }
    public int MachineId { get; set; }
    public string MachineName { get; set; }
    public string MachineBrand { get; set; }
    public string MachineDescription { get; set; }
    public int LocationId { get; set; }
    public virtual Location Location { get; set; }
    public virtual ICollection<EngineerMachine> Engineers { get; set; }
    public virtual ICollection<MachineIncident> Incidents { get; set; }
  }
}