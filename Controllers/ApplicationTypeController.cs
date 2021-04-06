using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> ojbList = _db.ApplicationTypes;
            return View(ojbList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationTypes.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            //Server side validation
            if (ModelState.IsValid)
            {
                _db.ApplicationTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        // POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAction(int? id)
        {
            var obj = _db.ApplicationTypes.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.ApplicationTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
