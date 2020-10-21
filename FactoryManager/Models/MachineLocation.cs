namespace FactoryManager.Models
{
  public class MachineLocation
  {
    public int MachineLocationId { get; set; }
    public int MachineId { get; set; }
    public int LocationId { get; set; }
    public Machine Machine { get; set; }
    public Location Location { get; set; }
  }
}