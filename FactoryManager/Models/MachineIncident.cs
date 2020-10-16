namespace FactoryManager.Models
{
  public class MachineIncident
  {
    public int MachineIncidentId { get; set; }
    public int MachineId { get; set; }
    public int IncidentId { get; set; }
    public Machine Machine { get; set; }
    public Incident Incident { get; set; }
  }
}