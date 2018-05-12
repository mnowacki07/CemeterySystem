using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class FamilyMemberPaymentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.User.Identity.IsAuthenticated && this.User.IsInRole(UserRoleRepository.FAMILY_MEMBER_ROLE_NAME))
                {
                    this.bindPayments();
                }
                else
                {
                    Response.Redirect("/Pages/LoginPage");                    
                }
            }
        }

        private void bindPayments()
        {
            ApplicationUser user = new UserService().getCurrentUser(this.Context);

            if(user.FamilyMember == null)
            {
                Response.Redirect("/Pages/DashboardFamilyMember");
            }
            else
            {                
                repPayments.DataSource = new DeadPersonService().getBy(x => x.FamilyMemberID.HasValue && x.FamilyMemberID.Equals(user.FamilyMemberID.Value));
                repPayments.DataBind();                
            }         
        }

        protected void lbtnProcessPayment_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser user = new UserService().getCurrentUser(this.Context);
                new DeadPersonService().processPayment(Guid.Parse(hfDeadPersonID.Value), user.FamilyMemberID.Value);
            }
            catch (Exception ex) { }
            this.bindPayments();
        }

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/DashboardFamilyMember");
        }
    }
}