using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity.Owin;

namespace CemeterySystem.Pages
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("/Pages/Dashboard.aspx");
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
                    Response.Redirect("/Pages/DashboardZarzadca.aspx");
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