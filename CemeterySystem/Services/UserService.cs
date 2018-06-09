using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.Entity;
using static CemeterySystem.App_Start.IdentityConfig;

namespace CemeterySystem.Services
{
    public class UserService
    {
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public IdentityResult registerUser(ApplicationUser user, string password)
        {
            try
            {
                UserRepository repo = new UserRepository(new ApplicationDbContext());
                user.PasswordHash = password;
                return repo.register(user);
            }
            catch (Exception ex) { }
            return null;
        }

        public SignInStatus signIn(string username, string password)
        {
            try
            {
                return SignInManager.PasswordSignInAsync(username, password, true, false).Result;
            }
            catch (Exception ex) { }
            return SignInStatus.Failure;
        }

        public void signOut(HttpContext context)
        {
            try
            {
                context.Request.GetOwinContext().Authentication.SignOut();
                context.Response.Cookies.Clear();
                FormsAuthentication.SignOut();
                context.Session.Clear();
            }
            catch (Exception ex) { }
        }

        public ApplicationUser getCurrentUser(HttpContext context)
        {
            try
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    ApplicationUser user = null;

                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        user = new UserRepository(db).getByUsername(context.User.Identity.Name);
                    }

                    return user;
                }
            }
            catch(Exception ex) { }
            return null;
        }

        public ApplicationUser getByID(string id)
        {
            try
            {
                ApplicationUser user = null;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    user = new UserRepository(db).getByID(id);
                }
                return user;
            }
            catch (Exception ex) { }
            return null;
        }

        public ApplicationUser getByFamilyMemberID(Guid familyMemberID)
        {
            try
            {
                ApplicationUser user = null;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var list = new UserRepository(db).getBy(x => x.FamilyMemberID.HasValue && x.FamilyMemberID.Value.Equals(familyMemberID));
                    user = list.Count > 0 ? list[0] : null;
                }
                return user;
            }
            catch (Exception ex) { }
            return null;
        }

        public List<ApplicationUser> getAll()
        {
            try
            {
                List<ApplicationUser> users = new List<ApplicationUser>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    users = new UserRepository(db).getAll();                       
                }
                return users;
            }
            catch (Exception ex) { }
            return new List<ApplicationUser>();
        }

        public void update(ApplicationUser user, string password)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    // user transaction because repo may process multiple actions on db
                    // changing user data and changing password
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            new UserRepository(db).update(user, password);

                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch(Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex) { }            
        }

        public List<ApplicationUser> getBy(Func<ApplicationUser, bool> whereClausule)
        {
            try
            {
                List<ApplicationUser> listUser = new List<ApplicationUser>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listUser = new UserRepository(dbContext).getBy(whereClausule);
                }
                return listUser;
            }
            catch (Exception ex) { }
            return new List<ApplicationUser>();
        }


        public void delete(Guid userID)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    new UserRepository(db).delete(new ApplicationUser() { Id = userID.ToString() });
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
}