using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CemeterySystem.App_Start;
using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using CemeterySystem.Services;

namespace CemeterySystem.Pages
{
    public partial class DeadPersonsDetails : System.Web.UI.Page
    {

        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }


        public Guid DeadPersonID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["DeadPersonID"]);
                }
                catch (Exception ex) { }
                return Guid.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.MANAGER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }
                else
                {
                    bindGenderDropdownList();

                    if (IsCreateMode)
                    {
                        btnDelete.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                        this.loadDeadPerson();
                    }
                }
            }
        }

        private void loadDeadPerson()
        {
            DeadPerson deadPerson = new DeadPersonService().getByID(DeadPersonID.ToString());

            if (deadPerson != null)
            {
                // txtFuneralDate.Text = deadPerson.FuneralShortDateFormatted;
                txtFirstName.Text = deadPerson.FirstName.ToString();

                txtLastName.Text = deadPerson.LastName.ToString();

                txtPesel.Text = deadPerson.PESEL.ToString();
            
                ddlGender.SelectedValue = deadPerson.Gender.ToString();



            }
            else
            {
                Response.Redirect("/Pages/FuneralsList.aspx");
            }
        }

        private void bindGenderDropdownList()
        {
            try
            {
                Utils.populateDropdownWithEnum(typeof(EnumGender), ddlGender);
            }
            catch (Exception ex) { }
        }


        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
           
            Response.Redirect("/Pages/DeadPersonsList.aspx");
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
    
        }

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/FuneralsList");
        }
    }
}