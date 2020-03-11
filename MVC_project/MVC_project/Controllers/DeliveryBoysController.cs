using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_project.Models;

namespace MVC_project.Controllers
{
    public class DeliveryBoysController : Controller
    {
        private MVC_projectEntities1 db = new MVC_projectEntities1();

        // GET: DeliveryBoys
        public ActionResult Index()
        {
            return View(db.DeliveryBoys.ToList());
        }

        // GET: DeliveryBoys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryBoy deliveryBoy = db.DeliveryBoys.Find(id);
            if (deliveryBoy == null)
            {
                return HttpNotFound();
            }
            return View(deliveryBoy);
        }

        // GET: DeliveryBoys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryBoys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryBoyId,DeliveryBoyName")] DeliveryBoy deliveryBoy)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryBoys.Add(deliveryBoy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryBoy);
        }

        // GET: DeliveryBoys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryBoy deliveryBoy = db.DeliveryBoys.Find(id);
            if (deliveryBoy == null)
            {
                return HttpNotFound();
            }
            return View(deliveryBoy);
        }

        // POST: DeliveryBoys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryBoyId,DeliveryBoyName")] DeliveryBoy deliveryBoy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryBoy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryBoy);
        }

        // GET: DeliveryBoys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryBoy deliveryBoy = db.DeliveryBoys.Find(id);
            if (deliveryBoy == null)
            {
                return HttpNotFound();
            }
            return View(deliveryBoy);
        }

        // POST: DeliveryBoys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryBoy deliveryBoy = db.DeliveryBoys.Find(id);
            db.DeliveryBoys.Remove(deliveryBoy);
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
