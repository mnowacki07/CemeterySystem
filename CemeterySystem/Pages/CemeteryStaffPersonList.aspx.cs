using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using CemeterySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class CemeteryStaffPersonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.MANAGER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }
                else
                {
                    this.bindCemeteryStaffPersonList();
                }
            }
        }

        private void bindCemeteryStaffPersonList()
        {
            try
            {
                List<CemeteryStaffPerson> listCemeteryStaffPerson = new CemeteryStaffPersonService().getAll();
                repCemetereyStaffPerson.DataSource = listCemeteryStaffPerson;
                repCemetereyStaffPerson.DataBind();
            }
            catch (Exception ex) { }
        }
    }
}