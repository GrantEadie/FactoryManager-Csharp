using Microsoft.AspNetCore.Mvc;
using FactoryManager.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FactoryManager.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryManagerContext _db;

    public MachinesController(FactoryManagerContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine mission)
    {
      _db.Machines.Add(mission);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(mission => mission.Engineers)
        .ThenInclude(join => join.Engineer)
        .Include(mission => mission.Incidents)
        .ThenInclude(join => join.Incident)
        .FirstOrDefault(mission => mission.MachineId == id);
      return View(thisMachine);
    }
    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(missions => missions.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine mission)
    {
      _db.Entry(mission).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mission.MachineId });
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(missions => missions.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(missions => missions.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteEngineer(int joinId, int missionId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = missionId});
    }
    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(missions => missions.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult AddEngineer(Machine mission, int EngineerId)
    {
      if (EngineerId != 0)
      {
      _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = mission.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mission.MachineId});
    }
    [HttpPost]
    public ActionResult DeleteIncident(int joinId, int missionId)
    {
      var joinEntry = _db.MachineIncident.FirstOrDefault(entry => entry.MachineIncidentId == joinId);
      _db.MachineIncident.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = missionId});
    }
    public ActionResult AddIncident(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(missions => missions.MachineId == id);
      ViewBag.IncidentId = new SelectList(_db.Incidents, "IncidentId", "IncidentTitle");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult AddIncident(Machine mission, int IncidentId)
    {
      if (IncidentId != 0)
      {
      _db.MachineIncident.Add(new MachineIncident() { IncidentId = IncidentId, MachineId = mission.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = mission.MachineId});
    }
  }
}