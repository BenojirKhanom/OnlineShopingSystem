using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MVC_project.Models;

namespace MVC_project.Controllers
{
    public class OrderDtlsController : Controller
    {
        private MVC_projectEntities1 db = new MVC_projectEntities1();

        public JsonResult getProductList(int? ProductId)
        {

            return Json(db.Products.Where(w => w.ProductId == ProductId.Value).Select(s => new { ProductId = s.ProductId, ProductName = s.ProductName }).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }



        public JsonResult getEmployeeList(int? EmployeeId)
        {
            return Json(db.Employees.Where(w => w.EmpID == EmployeeId.Value).Select(s => new { EmployeeId = s.EmpID, EmployeeName = s.Name }).FirstOrDefault(), JsonRequestBehavior.AllowGet);
        }

        // GET: OrderDtls
        public ActionResult Index()
        {
            var orderDtls = db.OrderDtls.Include(o => o.Employee).Include(o => o.Order).Include(o => o.Product);
            return View(orderDtls.ToList());
        }
        public ActionResult DataInsert()
        {
            ViewBag.ProductId = new SelectList(db.Products.ToList().Select(s => new { Text = s.ProductName, Value = s.ProductId }), "Value", "Text", "Select");
            ViewBag.OrderId = new SelectList(db.Orders.ToList().Select(s => new { Text = s.OrderId, Value = s.OrderId }), "Value", "Text", "Select");
            ViewBag.EmpID = new SelectList(db.Employees.ToList().Select(s => new { Text = s.Name, Value = s.EmpID }), "Value", "Text", "Select");

            return View();
        }




        [HttpPost]
        public JsonResult DataInsert(string OrderJason)
        {
            var js = new JavaScriptSerializer();

            OrderDtl[] orderDelts = js.Deserialize<OrderDtl[]>(OrderJason);

            using (var dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.OrderDtls.AddRange(orderDelts);
                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    return Json("Data are inserted in Institute Table");
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return Json("There is a Probem arise");
                }


            }
        }
        // GET: OrderDtls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDtl orderDtl = db.OrderDtls.Find(id);
            if (orderDtl == null)
            {
                return HttpNotFound();
            }
            return View(orderDtl);
        }

        // GET: OrderDtls/Create
        public ActionResult Create()
        {
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Orderdate");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: OrderDtls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderDtlsId,OrderId,ProductId,EmpID,Quentity,TotalCost")] OrderDtl orderDtl)
        {
            if (ModelState.IsValid)
            {
                db.OrderDtls.Add(orderDtl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", orderDtl.EmpID);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Orderdate", orderDtl.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderDtl.ProductId);
            return View(orderDtl);
        }

        // GET: OrderDtls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDtl orderDtl = db.OrderDtls.Find(id);
            if (orderDtl == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", orderDtl.EmpID);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Orderdate", orderDtl.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderDtl.ProductId);
            return View(orderDtl);
        }

        // POST: OrderDtls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDtlsId,OrderId,ProductId,EmpID,Quentity,TotalCost")] OrderDtl orderDtl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDtl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", orderDtl.EmpID);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Orderdate", orderDtl.OrderId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", orderDtl.ProductId);
            return View(orderDtl);
        }

        // GET: OrderDtls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDtl orderDtl = db.OrderDtls.Find(id);
            if (orderDtl == null)
            {
                return HttpNotFound();
            }
            return View(orderDtl);
        }

        // POST: OrderDtls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDtl orderDtl = db.OrderDtls.Find(id);
            db.OrderDtls.Remove(orderDtl);
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
