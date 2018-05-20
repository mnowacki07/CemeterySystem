using CemeterySystem.DBModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using static CemeterySystem.App_Start.IdentityConfig;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class UserRepository : Repository<ApplicationUser>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IdentityResult register(ApplicationUser objectToCreate)
        {
            try
            {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                ApplicationUserManager appUserManager = new ApplicationUserManager(userStore);
                var userManager = appUserManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                return userManager.Create(objectToCreate, objectToCreate.PasswordHash);
            }
            catch(Exception ex) { }
            return null;
        }

        public override void create(ApplicationUser objectToCreate)
        {
            throw new NotImplementedException();
        }

        public override void delete(ApplicationUser objectToDelete)
        {
            throw new NotImplementedException();
        }

        public override List<ApplicationUser> getAll()
        {
            return this._dbContext
                        .Users
                        .Include(x => x.Roles)
                        .Include(x => x.FamilyMember)
                        .Include(x => x.FamilyMember.Address)
                        .ToList();
        }

        public override List<ApplicationUser> getBy(Func<ApplicationUser, bool> whereClausule)
        {
            return this._dbContext
                        .Users
                        .Include(x => x.FamilyMember)
                        .Include(x => x.FamilyMember.Address)
                        .Where(whereClausule)
                        .ToList();
        }

        public override ApplicationUser getByID(string id)
        {
            return this._dbContext
                        .Users
                        .Include(x => x.FamilyMember)
                        .Include(x => x.FamilyMember.Address)
                        .FirstOrDefault(x => x.Id.Equals(id));
        }

        public ApplicationUser getByUsername(string username)
        {
            return this._dbContext
                        .Users
                        .Include(x => x.FamilyMember)
                        .Include(x => x.FamilyMember.Address)
                        .FirstOrDefault(x => x.UserName.Equals(username));
        }

        public override void update(ApplicationUser user)
        {
            this._dbContext.Users.Attach(user);
            this._dbContext.SaveChanges();
        }
    }
}