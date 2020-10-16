using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Engineer
  {
    public Engineer()
    {
      this.Machines = new HashSet<EngineerMachine>() ;
      this.Engineers = new HashSet<EngineerIncident>();
    }
    public int EngineerId { get; set; }
    public string EngineerName { get; set; }
    public string EngineerSpecialty { get; set; }
    public string EngineerExperience { get; set; }
    public virtual ICollection<EngineerMachine> Engineers { get; set; }
    public virtual ICollection<EngineerIncident> Machines { get; set; }
  }
}