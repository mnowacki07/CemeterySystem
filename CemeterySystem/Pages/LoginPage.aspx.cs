﻿using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;
using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System.Web.Security;

namespace CemeterySystem.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if user is autthenticated and is in role as "cemetary manager" then redirect to his dashboard
            if (!IsPostBack)
            {
                if (this.User.Identity.IsAuthenticated && this.User.IsInRole(UserRoleRepository.MANAGER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/DashboardZarzadca.aspx");
                }
            }
        }

        protected void btnSignIn_ServerClick(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var signInResult = new UserService().signIn(username, password);

            switch(signInResult)
            {
                case SignInStatus.Success:
                    // if user is autthenticated and is in role as "cemetary manager" then redirect to his dashboard
                    ApplicationUser currentUser = new UserRepository(new ApplicationDbContext()).getByUsername(username);
                    if (currentUser.Roles.First(x => x.RoleId.Equals(UserRoleRepository.MANAGER_ROLE_ID)) != null)
                    {
                        Response.Redirect("/Pages/DashboardZarzadca.aspx");
                    }
                    break;
                case SignInStatus.Failure:

                    break;
                case SignInStatus.LockedOut:

                    break;
                case SignInStatus.RequiresVerification:

                    break;
            }
        }
    }
}