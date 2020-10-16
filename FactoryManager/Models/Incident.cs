using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Mission
  {
    public Mission()
    {
      this.Engineers = new HashSet<EngineerMission>();
      this.Manifests = new HashSet<MissionManifest>();
    } 
    public int MissionId { get; set; }
    public string MissionName { get; set; }
    public string MissionDescription { get; set; }
    public virtual ICollection<EngineerMission> Engineers { get; set; }
    public virtual ICollection<MissionManifest> Manifests { get; set; }
  }
}