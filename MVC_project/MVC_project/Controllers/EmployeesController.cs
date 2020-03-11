 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_project.Models;
using PagedList;

namespace MVC_project.Controllers
{
    public class EmployeesController : Controller
    {
        private MVC_projectEntities1 db = new MVC_projectEntities1();


       
        // GET: Employees
        public ActionResult Index(string sortOrder , string searchString , string currentFilter, int? page)
        {
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.AgeSortParm = string.IsNullOrEmpty(sortOrder) ? "age_desc" : "Age";



            //  ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var Employees = from e in db.Employees select e;


            if (!string.IsNullOrEmpty(searchString))
            {
                Employees = Employees.Where(e => e.Name.ToUpper().Contains(searchString.ToUpper()));
                                      
       
            }
            if (searchString != null)
            {

                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            switch (sortOrder)
            {
                case "name_desc":
                    Employees = Employees.OrderByDescending(e => e.Name);
                    break;
                //case "age_desc":
                //    Employees = Employees.OrderBy(e => e.Age);
                //    break;
                //case "Age":
                //    Employees = Employees.OrderByDescending(e => e.Age);
                //    break;
                default:
                    Employees = Employees.OrderBy(e => e.Name);
                    break;
            }
            // return View(db.Employees.ToList());
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(Employees.ToPagedList(pageNumber, pageSize));
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,Name,Age,Country,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,Name,Age,Country,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
