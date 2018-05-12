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
    public partial class PaymentClassDetails : System.Web.UI.Page
    {
        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }

        public Guid PaymentClassID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["PaymentClassID"]);
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
                    this.loadPaymentClass();
                    btnDelete.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
        }

        private void loadPaymentClass()
        {
            PaymentClass paymentClass = new PaymentClassService().getByID(PaymentClassID.ToString());
            if(paymentClass != null)
            {
                txtName.Text = paymentClass.Name;
                txtDescription.Text = paymentClass.Description;
                txtPrice.Text = paymentClass.Price.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PaymentClass paymentClass = new PaymentClass()
            {
                PaymentClassID = Guid.NewGuid(),
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text, System.Globalization.CultureInfo.InvariantCulture)
            };

            if (IsCreateMode)
            {
                paymentClass = new PaymentClassService().create(paymentClass);
                Response.Redirect(string.Format("/Pages/PaymentClassDetails.aspx?PaymentClassID={0}", paymentClass.PaymentClassID.ToString()));
            }
            else
            {
                paymentClass.PaymentClassID = this.PaymentClassID;
                new PaymentClassService().update(paymentClass);
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            PaymentClass paymentClass = new PaymentClassService().getByID(PaymentClassID.ToString());
            if(paymentClass != null)
            {
                new PaymentClassService().delete(paymentClass);
            }
            Response.Redirect("/Pages/PaymentClassList.aspx");
        }


        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/PaymentClassList.aspx");
        }
    }
}