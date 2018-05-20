﻿using CemeterySystem.DBModels;
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
    }
}