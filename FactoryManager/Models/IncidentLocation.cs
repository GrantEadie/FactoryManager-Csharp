namespace FactoryManager.Models
{
  public class IncidentLocation
  {
    public int IncidentLocationId { get; set; }
    public int IncidentId { get; set; }
    public int LocationId { get; set; }
    public Incident Incident { get; set; }
    public Location Location { get; set; }
  }
}