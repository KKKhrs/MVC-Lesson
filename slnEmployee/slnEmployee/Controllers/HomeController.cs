using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using slnEmployee.Models;

namespace slnEmployee.Controllers
{
    public class HomeController : Controller
    {
        private dbEmployeeEntities db = new dbEmployeeEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.tEmployee.ToList());
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fEmpId,fName,fPhone,fDepId")] tEmployee tEmployee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Error = false;
                var temp = db.tEmployee.Where(x => x.fEmpId == tEmployee.fEmpId).FirstOrDefault();
                if(temp != null)
                {
                    ViewBag.Error = true;
                    return View(tEmployee);
                }
                db.tEmployee.Add(tEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEmployee);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tEmployee tEmployee = db.tEmployee.Find(id);
            if (tEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tEmployee);
        }

        // POST: Home/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fEmpId,fName,fPhone,fDepId")] tEmployee tEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEmployee);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tEmployee tEmployee = db.tEmployee.Find(id);
            if (tEmployee == null)
            {
                return HttpNotFound();
            }
            return View(tEmployee);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tEmployee tEmployee = db.tEmployee.Find(id);
            db.tEmployee.Remove(tEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
