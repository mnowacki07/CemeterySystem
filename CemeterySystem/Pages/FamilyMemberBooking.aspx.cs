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
    public partial class FamilyMemberBooking : System.Web.UI.Page
    {
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
                    this.bindBooking();
                }
            }
        }

        private void bindBooking()
        {
            ApplicationUser user = new UserService().getCurrentUser(this.Context);

            if (user.FamilyMemberID.HasValue)
            {
                BurialPlace burialPlace = new BurialPlaceService().getByFamilyMemberID(user.FamilyMemberID.Value);

                // already has booking
                if (burialPlace != null)
                {
                    divBurialPlace.Visible = true;
                    divBurialPlaceList.Visible = false;
                    txtBurialPlaceFieldNumber.Text = burialPlace.FieldNumber;
                    txtBurialPlaceGraveNumber.Text = burialPlace.GraveNumber;
                }
                // new booking
                else
                {
                    divBurialPlace.Visible = false;
                    divBurialPlaceList.Visible = true;
                    List<BurialPlace> listBurialPlace = new BurialPlaceService().getForBooking();
                    repBurialPlace.DataSource = listBurialPlace;
                    repBurialPlace.DataBind();
                }
            }
            else
            {
                Response.Redirect("/Pages/DashboardFamilyMember");
            }
        }

        protected void btnCancelBooking_Click(object sender, EventArgs e)
        {
            ApplicationUser user = new UserService().getCurrentUser(this.Context);
            if (user.FamilyMemberID.HasValue)
            {
                new BurialPlaceBookerService().cancelBooking(user.FamilyMemberID.Value);
            }
            Response.Redirect("/Pages/FamilyMemberBooking");
        }

        protected void btnCreateBooking_Click(object sender, EventArgs e)
        {
            try
            {
                new BurialPlaceBookerService().createBookingForFamilyMember(new UserService().getCurrentUser(this.Context), Guid.Parse(hfBurialPlaceID.Value));
            }
            catch (Exception ex) { }
            Response.Redirect("/Pages/FamilyMemberBooking");
        }
    }
}