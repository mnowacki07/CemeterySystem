using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class FamilyMemberDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Guid familyMemberID = Guid.Parse(this.Request.QueryString["FamilyMemberID"]);
                var user = new UserService().getByFamilyMemberID(familyMemberID);

                if(user != null)
                {
                    Response.Redirect(string.Format("/Pages/UserDetails?UserID={0}", user.Id));
                }
            }
            catch (Exception ex) { }
        }
    }
}