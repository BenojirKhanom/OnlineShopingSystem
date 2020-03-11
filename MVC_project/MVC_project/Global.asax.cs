using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVC_project.Controllers;
using MVC_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC_project
{
    public class MvcApplication : System.Web.HttpApplication
    {
       
        protected void Application_Start()
        {
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
           // GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));






            IdentityRole idenName = new IdentityRole();
            idenName.Name = "Admin";

            // ApplicationRoleManager.Create()

            IdentityResult r = roleManager.Create(idenName);
            if (r.Succeeded)
            {
                createDefaultRollAndUser();
            }


        }


        public async void createDefaultRollAndUser()
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" };
                var result = await UserManager.CreateAsync(user, "admin123"); //password=admin
                if (result.Succeeded)
                {
                    var userIdInstance = UserManager.Users.Where(w => w.UserName == "admin@gmail.com").FirstOrDefault();

                    UserManager.AddToRole(userIdInstance.Id, "Admin");




                }
            }
            catch (Exception)
            {

            }
        }


    }
}
