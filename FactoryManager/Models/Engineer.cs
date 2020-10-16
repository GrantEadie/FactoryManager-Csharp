using System.Collections.Generic;

namespace FactoryManager.Models
{
  public class Manifest
  {
    public Manifest()
    {
      this.Missions = new HashSet<MissionManifest>() ;
      this.Engineers = new HashSet<EngineerManifest>();
    }
    public int ManifestId { get; set; }
    public string ManifestTitle { get; set; }
    public string ManifestLifeSupportSupply { get; set; }
    public string ManifestEngineerCargo { get; set; }
    public string ManifestWeapon { get; set; }
    public virtual ICollection<EngineerManifest> Engineers { get; set; }
    public virtual ICollection<MissionManifest> Missions { get; set; }
  }
}