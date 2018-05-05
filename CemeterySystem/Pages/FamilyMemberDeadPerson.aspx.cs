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
    public partial class FamilyMemberDeadPerson : System.Web.UI.Page
    {
        public Guid FamilyMemberDeadPersonID
        {
            get
            {
                try
                {
                    return Guid.Parse(Request.QueryString["FamilyMemberDeadPersonID"]);
                }
                catch (Exception ex) { }
                return Guid.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.FAMILY_MEMBER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }
                else
                {
                    this.bindFamilyMemberDeadPerson();
                }
            }
        }

        public void bindFamilyMemberDeadPerson()
        {
            DeadPerson deadPerson = new DeadPersonService().getByID(this.FamilyMemberDeadPersonID);

            if(deadPerson == null)
            {
                Response.Redirect("/Pages/FamilyMemberDeadPersonsList");
            }
            else
            {
                txtFirstName.Text = deadPerson.FirstName;
                txtLastName.Text = deadPerson.LastName;
                txtPESEL.Text = deadPerson.PESEL;
                txtFuneralDate.Text = deadPerson.Funeral?.FuneralShortDateFormatted;
                txtFuneralCompany.Text = deadPerson.Funeral?.FuneralCompany?.Name;
                txtFuneralStaffPerson.Text = deadPerson.Funeral?.CemeteryStaffPerson?.NameFormatted;
                txtBurialPlaceFieldNumber.Text = deadPerson.BurialPlace?.FieldNumber;
                txtBurialPlaceGraveNumber.Text = deadPerson.BurialPlace?.GraveNumber;
            }
        }
    }
}