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
            userRoleRepo.create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = UserRoleRepository.ADMIN_ROLE_ID, Name = UserRoleRepository.ADMIN_ROLE_NAME });
            // family member
            userRoleRepo.create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = UserRoleRepository.FAMILY_MEMBER_ROLE_ID, Name = UserRoleRepository.FAMILY_MEMBER_ROLE_NAME});
            // cementary manager (zarządca cmentarza)
            userRoleRepo.create(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole() { Id = UserRoleRepository.MANAGER_ROLE_ID, Name = UserRoleRepository.MANAGER_ROLE_NAME});            

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

            // create dummy manager user
            // remove this after user registration implementation is done
            var managerUsers = new UserRepository(dbContext).getBy(x => x.UserName.Equals("manager"));
            if(managerUsers.Count == 0)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "manager",
                    Email = "dummy1@example.com"
                };

                new UserService().registerUser(user, "aB34567!");
            }

            var roleAdmin = userRoleRepo.getByID(UserRoleRepository.ADMIN_ROLE_ID);
            // attach admin role to user
            var serviceUser = new UserRepository(dbContext).getBy(x => x.UserName.Equals("service"))[0];
            if (serviceUser.Roles.FirstOrDefault(x => x.RoleId.Equals(UserRoleRepository.ADMIN_ROLE_ID)) == null)
            {
                serviceUser.Roles.Add(new IdentityUserRole() { RoleId = roleAdmin.Id, UserId = serviceUser.Id });
                new UserRepository(dbContext).update(serviceUser);
            }

            var managerRole = userRoleRepo.getByID(UserRoleRepository.MANAGER_ROLE_ID);
            // attach manager role to user
            var managerUser = new UserRepository(dbContext).getBy(x => x.UserName.Equals("manager"))[0];
            if(managerUser.Roles.FirstOrDefault(x => x.RoleId.Equals(UserRoleRepository.MANAGER_ROLE_ID)) == null)
            {
                managerUser.Roles.Add(new IdentityUserRole() { RoleId = managerRole.Id, UserId = managerUser.Id });
                new UserRepository(dbContext).update(managerUser);
            }

            dbContext.SaveChanges();
        }
    }
}