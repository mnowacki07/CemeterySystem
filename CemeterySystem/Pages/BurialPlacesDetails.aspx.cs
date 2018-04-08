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
    public partial class BurialPlacesDetails : System.Web.UI.Page
    {
        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).Trim().ToLower().Equals("true");
            }
        }

        public Guid BurialPlaceID
        {
            get
            {
                try
                {
                    return Guid.Parse("" + this.Request.QueryString["BurialPlaceID"]);
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
                    bindPaymentClassDropdownList();
                    bindBurialPlaceTypeDropdownList();
                    bindBurialPlaceStatusDropdownList();

                    if (IsCreateMode)
                    {
                        btnDelete.Visible = false;
                    }
                    else
                    {
                        btnDelete.Visible = true;                        
                        this.loadBurialPlace();
                    }
                }
            }
        }

        private void loadBurialPlace()
        {
            BurialPlace burialPlace = new BurialPlaceService().getByID(BurialPlaceID.ToString());

            if (burialPlace != null)
            {
                txtFieldNumber.Text = burialPlace.FieldNumber;
                txtGraveNumber.Text = burialPlace.GraveNumber;
                ddlType.SelectedValue = ((int)burialPlace.Type).ToString();
                ddlStatus.SelectedValue = ((int)burialPlace.Status).ToString();
                ddlPaymentClass.SelectedValue = burialPlace.PaymentClassID.ToString();
                txtPaymentDate.Text = burialPlace.PaymentDateFormatted;
                txtDescription.Text = burialPlace.Description;
            }
            else
            {
                Response.Redirect("/Pages/BurialPlacesList.aspx");
            }
        }

        private void bindPaymentClassDropdownList()
        {
            try
            {
                List<PaymentClass> listPaymentClass = new PaymentClassService().getAll();
                ddlPaymentClass.Items.AddRange(listPaymentClass.Select(x => new ListItem(x.Name + " - " + x.PriceFormatted, x.PaymentClassID.ToString())).ToArray());
            }
            catch (Exception ex) { }
        }

        private void bindBurialPlaceTypeDropdownList()
        {
            try
            {
                Utils.populateDropdownWithEnum(typeof(EnumBurialPlaceType), ddlType);
            }
            catch (Exception ex) { }
        }

        private void bindBurialPlaceStatusDropdownList()
        {
            try
            {
                Utils.populateDropdownWithEnum(typeof(EnumBurialPlaceStatus), ddlStatus);
            }
            catch (Exception ex) { }
        }

        private void saveBurialPlace()
        {
            BurialPlace burialPlace = null;

            if(IsCreateMode)
            {
                burialPlace = new BurialPlace()
                {
                    BurialPlaceID = Guid.NewGuid()
                };
            }
            else
            {
                burialPlace = new BurialPlaceService().getByID(this.BurialPlaceID.ToString());
            }

            burialPlace.FieldNumber = txtFieldNumber.Text;
            burialPlace.GraveNumber = txtGraveNumber.Text;
            burialPlace.Type = (EnumBurialPlaceType) Convert.ToInt32(ddlType.SelectedValue);
            burialPlace.Status = (EnumBurialPlaceStatus)Convert.ToInt32(ddlStatus.SelectedValue);

            PaymentClass paymentClass = new PaymentClassService().getByID(ddlPaymentClass.SelectedValue);
            if (paymentClass != null)
            {
                burialPlace.PaymentClassID = paymentClass.PaymentClassID;
                burialPlace.PaymentClass = paymentClass;
            }

            if(string.IsNullOrEmpty(("" + txtPaymentDate.Text).Trim()))
            {
                burialPlace.PaymentDate = null;
            }
            else
            {
                try
                {
                    burialPlace.PaymentDate = DateTime.ParseExact(txtPaymentDate.Text.Trim(), "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch(Exception ex)
                {
                    burialPlace.PaymentDate = null;
                }
            }

            burialPlace.Description = txtDescription.Text;

            if (IsCreateMode)
            {
                new BurialPlaceService().create(burialPlace);
                Response.Redirect(string.Format("/Pages/BurialPlacesDetails?BurialPlaceID={0}", burialPlace.BurialPlaceID.ToString()));
            }
            else
            {
                new BurialPlaceService().update(burialPlace);
            }
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            BurialPlace burialPlace = new BurialPlaceService().getByID(BurialPlaceID.ToString());
            if (burialPlace != null)
            {
                new BurialPlaceService().delete(burialPlace);
            }
            Response.Redirect("/Pages/BurialPlacesList.aspx");
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            saveBurialPlace();
        }
    }
}