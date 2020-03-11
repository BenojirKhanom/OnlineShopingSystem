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
    public class ShippingInfoesController : Controller
    {
        private MVC_projectEntities1 db = new MVC_projectEntities1();

        // GET: ShippingInfoes
        public ActionResult Index()
        {
            var shippingInfoes = db.ShippingInfoes.Include(s => s.DeliveryBoy);
            return View(shippingInfoes.ToList());
        }

        // GET: ShippingInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingInfo shippingInfo = db.ShippingInfoes.Find(id);
            if (shippingInfo == null)
            {
                return HttpNotFound();
            }
            return View(shippingInfo);
        }

        // GET: ShippingInfoes/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryBoyId = new SelectList(db.DeliveryBoys, "DeliveryBoyId", "DeliveryBoyName");
            return View();
        }

        // POST: ShippingInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingId,DeliveryBoyId,ShippingCost,ShippingDate")] ShippingInfo shippingInfo)
        {
            if (ModelState.IsValid)
            {
                db.ShippingInfoes.Add(shippingInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryBoyId = new SelectList(db.DeliveryBoys, "DeliveryBoyId", "DeliveryBoyName", shippingInfo.DeliveryBoyId);
            return View(shippingInfo);
        }

        // GET: ShippingInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingInfo shippingInfo = db.ShippingInfoes.Find(id);
            if (shippingInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryBoyId = new SelectList(db.DeliveryBoys, "DeliveryBoyId", "DeliveryBoyName", shippingInfo.DeliveryBoyId);
            return View(shippingInfo);
        }

        // POST: ShippingInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingId,DeliveryBoyId,ShippingCost,ShippingDate")] ShippingInfo shippingInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryBoyId = new SelectList(db.DeliveryBoys, "DeliveryBoyId", "DeliveryBoyName", shippingInfo.DeliveryBoyId);
            return View(shippingInfo);
        }

        // GET: ShippingInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingInfo shippingInfo = db.ShippingInfoes.Find(id);
            if (shippingInfo == null)
            {
                return HttpNotFound();
            }
            return View(shippingInfo);
        }

        // POST: ShippingInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingInfo shippingInfo = db.ShippingInfoes.Find(id);
            db.ShippingInfoes.Remove(shippingInfo);
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
