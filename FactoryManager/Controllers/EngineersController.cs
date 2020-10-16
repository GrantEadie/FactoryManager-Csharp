using Microsoft.AspNetCore.Mvc;
using FactoryManager.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace FactoryManager.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryManagerContext _db;

    public EngineersController(FactoryManagerContext db)
    {
      _db = db ;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.Incidents)
        .ThenInclude(join => join.Incident)
        .Include(engineer => engineer.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }
    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.IncidentId = new SelectList(_db.Incidents, "IncidentId", "IncidentName");
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId });
    }
    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteIncident(int engineerId, int joinId)
    {
      var joinEntry = _db.EngineerIncident.FirstOrDefault(entry => entry.EngineerIncidentId == joinId);
      _db.EngineerIncident.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineerId});
    }
    public ActionResult AddIncident(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.IncidentId = new SelectList(_db.Incidents, "IncidentId", "IncidentTitle");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult AddIncident(Engineer engineer, int IncidentId)
    {
      if (IncidentId != 0)
      {
      _db.EngineerIncident.Add(new EngineerIncident() { IncidentId = IncidentId, EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId});
    }
    [HttpPost]
    public ActionResult DeleteMachine(int engineerId, int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineerId});
    }
    public ActionResult AddMachine(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View(thisEngineer);
    }
    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
      {
      _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = engineer.EngineerId});
    }
  }
}