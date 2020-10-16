using Microsoft.AspNetCore.Mvc;
using FactoryManager.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FactoryManager.Controllers
{
  public class LocationsController : Controller
  {
    private readonly FactoryManagerContext _db;

    public LocationsController(FactoryManagerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Location> model = _db.Locations.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Location location)
    {
      _db.Locations.Add(location);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Location thisLocation = _db.Locations.Include(location => location.Machines).FirstOrDefault(location => location.LocationId == id);
      return View(thisLocation);
    }

    public ActionResult Edit(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(location => location.LocationId == id);
      return View(thisLocation);
    }

    [HttpPost]
    public ActionResult Edit(Location location)
    {
      _db.Entry(location).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(location => location.LocationId == id);
      return View(thisLocation);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisLocation = _db.Locations.FirstOrDefault(location => location.LocationId == id);
      _db.Locations.Remove(thisLocation);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}