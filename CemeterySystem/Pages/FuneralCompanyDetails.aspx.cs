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
    public partial class FuneralCompanyDetails : System.Web.UI.Page
    {
        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }

        public Guid FuneralCompanyID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["FuneralCompanyID"]);
                }
                catch (Exception ex) { }
                return Guid.Empty;
            }
        }

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
                    if(IsCreateMode)
                    {
                        btnDelete.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;
                        this.loadFuneralCompanyInfo();
                    }
                }
            }
        }

        private void loadFuneralCompanyInfo()
        {
            FuneralCompany funeralCompany = new FuneralCompanyService().getByID(FuneralCompanyID);

            if(funeralCompany != null)
            {
                txtName.Text = funeralCompany.Name;
                txtLicenseNumber.Text = funeralCompany.LicenseNumber;

                if(funeralCompany.Address != null)
                {
                    txtStreet.Text = funeralCompany.Address.Street;
                    txtHouseNumber.Text = funeralCompany.Address.HouseNumber;
                    txtFlatNumber.Text = funeralCompany.Address.FlatNumber;
                    txtTown.Text = funeralCompany.Address.Town;
                    txtPostCode.Text = funeralCompany.Address.PostCode;
                    txtPhoneNumber.Text = funeralCompany.Address.PhoneNumber;
                }

            }
        }

        private void saveFuneralCompanyInfo()
        {
            FuneralCompany funeralCompany = null;

            if(IsCreateMode)
            {
                funeralCompany = new FuneralCompany();
                funeralCompany.FuneralCompanyID = Guid.NewGuid();
                funeralCompany.Address = new Address();
                funeralCompany.Address.CustomAddressID = Guid.NewGuid();
                funeralCompany.AddressID = funeralCompany.Address.CustomAddressID;
            }
            else
            {
                funeralCompany = new FuneralCompanyService().getByID(FuneralCompanyID);
            }

            funeralCompany.Name = txtName.Text;
            funeralCompany.LicenseNumber = txtLicenseNumber.Text;
            funeralCompany.Address.Street = txtStreet.Text;
            funeralCompany.Address.HouseNumber = txtHouseNumber.Text;
            funeralCompany.Address.FlatNumber = txtFlatNumber.Text;
            funeralCompany.Address.Town = txtTown.Text;
            funeralCompany.Address.PostCode = txtPostCode.Text;
            funeralCompany.Address.PhoneNumber = txtPhoneNumber.Text;

            if (IsCreateMode)
            {
                new FuneralCompanyService().create(funeralCompany);
                Response.Redirect(string.Format("/Pages/FuneralCompanyDetails?FuneralCompanyID={0}", funeralCompany.FuneralCompanyID.ToString()));
            }
            else
            {
                new FuneralCompanyService().update(funeralCompany);
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            this.saveFuneralCompanyInfo();
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            FuneralCompany funeralCompany = new FuneralCompanyService().getByID(FuneralCompanyID);
            if (funeralCompany != null)
            {
                new FuneralCompanyService().delete(funeralCompany);
            }
            Response.Redirect("/Pages/FuneralCompanyList.aspx");
        }
    }
}