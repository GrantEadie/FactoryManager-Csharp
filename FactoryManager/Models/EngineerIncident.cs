namespace FactoryManager.Models
{
  public class EngineerIncident
  {
    public int EngineerIncidentId { get; set; }
    public int EngineerId { get; set; }
    public int IncidentId { get; set; }
    public Incident Incident { get; set; }
    public Engineer Engineer { get; set; }
  }
}