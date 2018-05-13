using CemeterySystem.App_Start;
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
    public partial class FuneralsDetails : System.Web.UI.Page
    {
        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }

        public Guid FuneralID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["FuneralID"]);
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
                    bindFuneralCompanyDropdownList();
                    bindStaffList();

                    if (IsCreateMode)
                    {
                        btnDelete.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                        this.loadFuneral();
                    }
                }
            }
        }

        private void loadFuneral()
        {
            Funeral funeral = new FuneralService().getByID(FuneralID.ToString());

            if (funeral != null)
            {
                txtFuneralDate.Text = funeral.FuneralShortDateFormatted;
                ddlFuneralCompany.SelectedValue = funeral.FuneralCompanyID.ToString();
                ddlStaffPerson.SelectedValue = funeral.CemeteryStaffPersonID.ToString();
                //txtName.Text = funeral.N; 



                //txtFieldNumber.Text = funeral.FieldNumber;
                //txtGraveNumber.Text = funeral.GraveNumber;
                //ddlType.SelectedValue = ((int)funeral.Type).ToString();
                //ddlStatus.SelectedValue = ((int)funeral.Status).ToString();
                //ddlPaymentClass.SelectedValue = funeral.PaymentClassID.ToString();
                //txtPaymentDate.Text = funeral.PaymentDateFormatted;
                //txtDescription.Text = funeral.Description;
            }
            else
            {
                Response.Redirect("/Pages/FuneralsList.aspx");
            }
        }

        private void bindFuneralCompanyDropdownList()
        {
            try
            {
                List<FuneralCompany> listCompany = new FuneralCompanyService().getAll();
                ddlFuneralCompany.Items.AddRange(listCompany.Select(x => new ListItem(x.Name, x.FuneralCompanyID.ToString())).ToArray());
            }
            catch (Exception ex) { }
        }

        private void bindStaffList()
        {
            try
            {
                List<CemeteryStaffPerson> staffList = new CemeteryStaffPersonService().getAll();
                ddlStaffPerson.Items.AddRange(staffList.Select(x => new ListItem(x.LastName, x.CemeteryStaffPersonID.ToString())).ToArray());
            }
            catch (Exception ex) { }
        }



        private void saveFuneral()
        {
            Funeral funeral = null;

            if (IsCreateMode)
            {
                funeral = new Funeral()
                {
                    FuneralID = Guid.NewGuid()
                };
            }
            else
            {
                funeral = new FuneralService().getByID(this.FuneralID.ToString());
            }

            FuneralCompany funeralCompany = new FuneralCompanyService().getByID(ddlFuneralCompany.SelectedValue);
            CemeteryStaffPerson cemeteryStaff = new CemeteryStaffPersonService().getByID(ddlStaffPerson.SelectedValue);
            funeral.FuneralDate = DateTime.ParseExact(txtFuneralDate.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            funeral.FuneralCompanyID = funeralCompany.FuneralCompanyID;
            funeral.CemeteryStaffPersonID = cemeteryStaff.CemeteryStaffPersonID;
            // FuneralCompany company = new FuneralCompanyService().getByID(ddlFuneralCompany.SelectedValue);







            if (IsCreateMode)
            {
                new FuneralService().create(funeral);
                Response.Redirect(string.Format("/Pages/FuneralsDetails?FuneralID={0}", funeral.FuneralID.ToString()));
            }
            else
            {
                new FuneralService().update(funeral);
            }
        }

       

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            Funeral funeral = new FuneralService().getByID(FuneralID.ToString());
            if (funeral != null)
            {
                new FuneralService().delete(funeral);
            }
            Response.Redirect("/Pages/FuneralsList.aspx");
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            saveFuneral();
        }

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/FuneralsList");
        }
    }
}