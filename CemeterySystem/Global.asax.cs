using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using CemeterySystem.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CemeterySystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {            
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ApplicationDbContext dbContext = new ApplicationDbContext();
            UserRoleRepository userRoleRepo = new UserRoleRepository(dbContext);
            // admin
            userRoleRepo.create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "ADM", Name = "Administrator" });
            // family member
            userRoleRepo.create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "FMB", Name = "Członek rodziny" });
            // cementary manager (zarządca cmentarza)
            userRoleRepo.create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = "MAN", Name = "Zarządca cmentarza" });            

            // create dummy service user
            // remove this after user registration implementation is done
            var serviceUsers = new UserRepository(dbContext).getBy(x => x.UserName.Equals("service"));
            if(serviceUsers.Count == 0)
            {
                ApplicationUser user = new ApplicationUser()
                {                    
                    UserName = "service",
                    Email = "dummy@example.com"
                };

                new UserService().registerUser(user, "aB34567!");
            }

            var roleAdmin = userRoleRepo.getByID("ADM");

            // attach admin role to user
            var serviceUser = new UserRepository(dbContext).getBy(x => x.UserName.Equals("service"))[0];
            if (serviceUser.Roles.FirstOrDefault(x => x.RoleId.Equals("ADM")) == null)
            {
                serviceUser.Roles.Add(new IdentityUserRole() { RoleId = roleAdmin.Id, UserId = serviceUser.Id });
                new UserRepository(dbContext).update(serviceUser);
            }

            dbContext.SaveChanges();
        }
    }
}