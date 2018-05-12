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
    public partial class CemeteryStaffPersonDetails : System.Web.UI.Page
    {
        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }

        public Guid CemeteryStaffPersonID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["CemeteryStaffPersonID"]);
                }
                catch (Exception ex) { }
                return Guid.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.MANAGER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }

                if(!IsCreateMode)
                {
                    this.loadCemeteryStaffPerson();
                    btnDelete.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
        }

        private void loadCemeteryStaffPerson()
        {
            CemeteryStaffPerson cemeteryStaffPerson = new CemeteryStaffPersonService().getByID(CemeteryStaffPersonID.ToString());
            if(cemeteryStaffPerson != null)
            {
                txtFirstName.Text = cemeteryStaffPerson.FirstName;
                txtLastName.Text = cemeteryStaffPerson.LastName;
                txtPosition.Text = cemeteryStaffPerson.Position;
                txtPESEL.Text = cemeteryStaffPerson.PESEL;                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CemeteryStaffPerson cemeteryStaffPerson = new CemeteryStaffPerson()
            {
                CemeteryStaffPersonID = Guid.NewGuid(),
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                PESEL = txtPESEL.Text,
                Position = txtPosition.Text
            };

            if (IsCreateMode)
            {
                cemeteryStaffPerson = new CemeteryStaffPersonService().create(cemeteryStaffPerson);
                Response.Redirect(string.Format("/Pages/CemeteryStaffPersonDetails.aspx?CemeteryStaffPersonID={0}", cemeteryStaffPerson.CemeteryStaffPersonID.ToString()));
            }
            else
            {
                cemeteryStaffPerson.CemeteryStaffPersonID = this.CemeteryStaffPersonID;
                new CemeteryStaffPersonService().update(cemeteryStaffPerson);
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            CemeteryStaffPerson cemeteryStaffPerson = new CemeteryStaffPersonService().getByID(CemeteryStaffPersonID.ToString());
            if(cemeteryStaffPerson != null)
            {
                new CemeteryStaffPersonService().delete(cemeteryStaffPerson);
            }
            Response.Redirect("/Pages/CemeteryStaffPersonList.aspx");
        }

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/CemeteryStaffPersonList");
        }
    }
}