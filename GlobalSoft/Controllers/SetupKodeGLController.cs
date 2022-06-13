using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GlobalSoft.Models;

namespace GlobalSoft.Controllers
{
    [Authorize(Roles = "Admin,Manager,Employee")]
    public class SetupKodeGLController : Controller
    {
        private GlobalsoftDBContext db = new GlobalsoftDBContext();

        // GET: SetupGlTipes
        public ActionResult Index()
        {
            List<GlCode> TipeGl = new List<GlCode>();
           

            var cekNull = (from e in db.GlCodes select e).Count();
           if (cekNull == 0)
            {
               

                foreach (var values in TipeGl)
                {
                    db.GlCodes.Add(values);
                    db.SaveChanges();
                }

               
           }


            return View(db.GlCodes.ToList());
        }

        // GET: SetupGlTipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlCode glTipe = db.GlCodes.Find(id);
            if (glTipe == null)
            {
                return HttpNotFound();
            }
            return View(glTipe);
        }

        // GET: SetupGlTipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SetupGlTipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlCodeID,KodeGL,NamaGL")] GlCode glTipe)
        {
            if (ModelState.IsValid)
            {
                db.GlCodes.Add(glTipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glTipe);
        }

        // GET: SetupGlTipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlCode glTipe = db.GlCodes.Find(id);
            if (glTipe == null)
            {
                return HttpNotFound();
            }
            return View(glTipe);
        }

        // POST: SetupGlTipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlCodeID,KodeGL,NamaGL")] GlCode glTipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glTipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glTipe);
        }

        // GET: SetupGlTipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlCode glTipe = db.GlCodes.Find(id);
            if (glTipe == null)
            {
                return HttpNotFound();
            }
            return View(glTipe);
        }

        // POST: SetupGlTipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlCode glTipe = db.GlCodes.Find(id);
            db.GlCodes.Remove(glTipe);
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
