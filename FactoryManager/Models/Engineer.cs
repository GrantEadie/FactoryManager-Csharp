using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Machines = new HashSet<EngineerMachine>() ;
      this.Incidents = new HashSet<EngineerIncident>();
    }
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }
    public string EngineerSpecialty { get; set; }
    public string EngineerExperience { get; set; }
    public virtual ICollection<EngineerIncident> Incidents { get; set; }
    public virtual ICollection<EngineerMachine> Machines { get; set; }
  }
}