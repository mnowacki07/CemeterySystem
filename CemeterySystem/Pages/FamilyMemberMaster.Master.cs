using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class FamilyMemberMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lbtnSignOut_Click(object sender, EventArgs e)
        {
            new UserService().signOut(this.Context);
            Response.Redirect("/Pages/LoginPage.aspx");
        }
    }
}