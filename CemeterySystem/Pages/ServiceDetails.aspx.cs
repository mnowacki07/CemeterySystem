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
    public partial class ServiceDetails : System.Web.UI.Page
    {
        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).ToLower().Trim().Equals("true");
            }
        }

        public Guid ServiceID
        {
            get
            {
                try
                {
                    return Guid.Parse(this.Request.QueryString["ServiceID"]);
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
                else
                {
                    this.bindService();
                }
            }
        }

        private void bindService()
        {
            if(!IsCreateMode)
            {
                Service service = new ServicesService().getByID(this.ServiceID);

                if (service == null)
                {
                    Response.Redirect("/Pgaes/ServiceList.aspx");
                }
                else
                {
                    txtName.Text = service.Name;
                    txtDescription.Text = service.Description;
                    txtPriceGross.Text = service.PriceGross.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    btnDelete.Visible = true;
                }
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            try
            {
                new ServicesService().delete(this.ServiceID);
            }
            catch (Exception ex) { }
            Response.Redirect("/Pages/ServiceList.aspx");
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            Service service = new Service()
            {
                ServiceID = Guid.NewGuid(),
                Name = txtName.Text,
                Description = txtDescription.Text,
                PriceGross = decimal.Parse(txtPriceGross.Text, System.Globalization.CultureInfo.InvariantCulture)
            };

            if (IsCreateMode)
            {
                service = new ServicesService().create(service);
                Response.Redirect(string.Format("/Pages/ServiceDetails.aspx?ServiceID={0}", service.ServiceID.ToString()));
            }
            else
            {
                service.ServiceID = this.ServiceID;
                new ServicesService().update(service);
            }
        }        

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/ServiceList");
        }
    }
}