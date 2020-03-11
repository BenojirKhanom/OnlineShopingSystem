using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MVC_project.Models;
namespace MVC_project.Controllers
{
    public class Admin_RollController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            List<Admin_RollCreation> rollList = new List<Admin_RollCreation>();
            if (HttpContext.User.IsInRole("Admin"))
            {
                foreach (var v in roleManager.Roles.ToList())
                {
                    rollList.Add(new Admin_RollCreation()
                    {
                        RoleName = v.Name,
                        Id = 0

                    });
                }


            }
            else
            {

                foreach (var v in roleManager.Roles.Where(w => w.Name != "Admin").ToList())
                {
                    rollList.Add(new Admin_RollCreation()
                    {
                        RoleName = v.Name,
                        Id = 0

                    });
                }



            }
            return View(rollList);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult RollCreate()
        {
            if (HttpContext.User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]

        public ActionResult RollCreate(Admin_RollCreation admin_RollCreation)
        {

            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));



            IdentityRole idenName = new IdentityRole();
            idenName.Name = admin_RollCreation.RoleName;

            IdentityResult r = roleManager.Create(idenName);
            if (r.Succeeded)
            {

                return View("Index");
            }

            return View();

        }

        //public ActionResult UserDelete(string id)
        //{

        //    if (string.IsNullOrEmpty(id))
        //    {

        //        id = HttpContext.User.Identity.GetUserId();
        //        ApplicationDbContext db1 = new ApplicationDbContext();

        //        ApplicationUser au1 = db1.Users.Find(new object[] { id });
        //        db1.Users.Remove(au1);
        //        db1.SaveChanges();

        //        return RedirectToAction("LogOff", "Account");
        //        //return RedirectToAction("Index", "Home");
        //    }

        //    ApplicationDbContext db = new ApplicationDbContext();

        //    ApplicationUser au = db.Users.Find(new object[] { id });
        //    db.Users.Remove(au);
        //    db.SaveChanges();

        //    return RedirectToAction("Index", "Admin_Roll");
        //}


    }
}
