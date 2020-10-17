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
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }  
    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
        .Include(machine => machine.Engineers)
        .ThenInclude(join => join.Engineer)
        .Include(machine => machine.Incidents)
        .ThenInclude(join => join.Incident)
        .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }
    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId });
    }
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteEngineer(int joinId, int machineId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = machineId});
    }
    public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
      _db.EngineerMachine.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId});
    }
    [HttpPost]
    public ActionResult DeleteIncident(int joinId, int machineId)
    {
      var joinEntry = _db.MachineIncident.FirstOrDefault(entry => entry.MachineIncidentId == joinId);
      _db.MachineIncident.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = machineId});
    }
    public ActionResult AddIncident(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.IncidentId = new SelectList(_db.Incidents, "IncidentId", "IncidentTitle");
      return View(thisMachine);
    }
    [HttpPost]
    public ActionResult AddIncident(Machine machine, int IncidentId)
    {
      if (IncidentId != 0)
      {
      _db.MachineIncident.Add(new MachineIncident() { IncidentId = IncidentId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = machine.MachineId});
    }
  }
}