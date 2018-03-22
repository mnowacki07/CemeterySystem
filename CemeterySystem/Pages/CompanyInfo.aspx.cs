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
    public partial class CompanyInfo : System.Web.UI.Page
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
                    this.loadCompanyInfo();
                }
            }
        }

        private void loadCompanyInfo()
        {
            FuneralCompany funeralCompany = new FuneralCompanyService().get();

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

        private void saveCompanyInfo()
        {
            FuneralCompany funeralCompany = new FuneralCompanyService().get();

            bool create = false;

            if(funeralCompany == null)
            {
                create = true;
                funeralCompany = new FuneralCompany();
            }

            if(funeralCompany.Address == null)
            {
                funeralCompany.Address = new Address();
            }

            funeralCompany.Name = txtName.Text;
            funeralCompany.LicenseNumber = txtLicenseNumber.Text;
            funeralCompany.Address.Street = txtStreet.Text;
            funeralCompany.Address.HouseNumber = txtHouseNumber.Text;
            funeralCompany.Address.FlatNumber = txtFlatNumber.Text;
            funeralCompany.Address.Town = txtTown.Text;
            funeralCompany.Address.PostCode = txtPostCode.Text;
            funeralCompany.Address.PhoneNumber = txtPhoneNumber.Text;

            if (create)
            {
                new FuneralCompanyService().create(funeralCompany);
            }
            else
            {
                new FuneralCompanyService().update(funeralCompany);
            }
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            this.saveCompanyInfo();
        }
    }
}