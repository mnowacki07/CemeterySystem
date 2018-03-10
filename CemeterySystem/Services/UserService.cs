using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                return SignInManager.PasswordSignInAsync(username, password, true, shouldLockout: false).Result;
            }
            catch (Exception ex) { }
            return SignInStatus.Failure;
        }
    }
}