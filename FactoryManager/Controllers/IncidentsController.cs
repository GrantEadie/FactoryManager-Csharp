using Microsoft.AspNetCore.Mvc;
using FactoryManager.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FactoryManager.Controllers
{
  public class IncidentsController : Controller
  {
    private readonly FactoryManagerContext _db;

    public IncidentsController(FactoryManagerContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Incident> model = _db.Incidents.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Incident incident)
    {
      _db.Incidents.Add(incident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisIncident = _db.Incidents
        .Include(incident => incident.Engineers)
        .ThenInclude(join => join.Engineer)
        .Include(incident => incident.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(incident => incident.IncidentId == id);
      return View(thisIncident);
    }
    public ActionResult Edit(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisIncident);
    }

    [HttpPost]
    public ActionResult Edit(Incident incident)
    {
      _db.Entry(incident).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = incident.IncidentId });
    }
    public ActionResult Delete(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      return View(thisIncident);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      _db.Incidents.Remove(thisIncident);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteEngineer(int incidentId, int joinId)
    {
      var joinEntry = _db.EngineerIncident.FirstOrDefault(entry => entry.EngineerIncidentId == joinId);
      _db.EngineerIncident.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = incidentId});
    }
    public ActionResult AddEngineer(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisIncident);
    }
    [HttpPost]
    public ActionResult AddEngineer(Incident incident, int EngineerId)
    {
      if (EngineerId != 0)
      {
      _db.EngineerIncident.Add(new EngineerIncident() { EngineerId = EngineerId, IncidentId = incident.IncidentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = incident.IncidentId});
    }
    [HttpPost]
    public ActionResult DeleteMachine(int incidentId, int joinId)
    {
      var joinEntry = _db.MachineIncident.FirstOrDefault(entry => entry.MachineIncidentId == joinId);
      _db.MachineIncident.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = incidentId});
    }
    public ActionResult AddMachine(int id)
    {
      var thisIncident = _db.Incidents.FirstOrDefault(incidents => incidents.IncidentId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View(thisIncident);
    }
    [HttpPost]
    public ActionResult AddMachine(Incident incident, int MachineId)
    {
      if (MachineId != 0)
      {
      _db.MachineIncident.Add(new MachineIncident() { MachineId = MachineId, IncidentId = incident.IncidentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = incident.IncidentId});
    }
  }
}