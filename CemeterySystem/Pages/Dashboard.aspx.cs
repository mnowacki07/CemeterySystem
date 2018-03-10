using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Pages/LoginPage.aspx");
            }
            else
            {
                lblInfo.Text = "Jesteś zalogowany jako: " + this.User.Identity.Name;
            }
        }
    }
}