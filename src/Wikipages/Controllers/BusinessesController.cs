using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wikipages.Models;


namespace Wikipages.Controllers
{
    public class BusinessesController : Controller
    {
        private WikipagesContext db = new WikipagesContext();
        public IActionResult Index()
        {
            return View(db.Businesses.Include(businesses => businesses.Type).ToList());
        }

        public IActionResult Details(int id)
        {
            var returnedBusiness = db.Businesses
                .Include(businesses => businesses.Type)
                .FirstOrDefault(businesses => businesses.BusinessId == id);
              
                
            return View(returnedBusiness);
        }
        public IActionResult Edit(int id)
        {
            var selectedBusiness = db.Businesses.FirstOrDefault(businesses => businesses.BusinessId == id);
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "type");
            return View(selectedBusiness); 
        }

        [HttpPost]
        public ActionResult Edit(Business selectedBusiness)
        {
            db.Entry(selectedBusiness).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            ViewBag.TypeId = new SelectList(db.Types, "TypeId", "type");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Business newBusiness)
        {
            db.Businesses.Add(newBusiness);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisBiz = db.Businesses.FirstOrDefault(businesses => businesses.BusinessId == id);
            return View(thisBiz);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisBiz = db.Businesses.FirstOrDefault(businesses => businesses.BusinessId == id);
            db.Businesses.Remove(thisBiz);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
