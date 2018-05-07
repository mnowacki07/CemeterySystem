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
    public partial class BookedServiceList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.FAMILY_MEMBER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }
                else
                {
                    ApplicationUser user = new UserService().getCurrentUser(this.Context);

                    if (!user.FamilyMemberID.HasValue)
                    {
                        Response.Redirect("/Pages/LoginPage.aspx");
                    }
                    else
                    {
                        this.bindBookedServiceList(user);
                        this.bindServiceList();
                        this.bindDeadPersonForFamilyMember(user);
                    }
                }
            }
        }

        private class BookedServiceViewModel
        {
            public BookedService BookedService { get; private set; }
            public DeadPerson DeadPerson { get; private set; }

            public string DeadPersonNameFormatted
            {
                get
                {
                    return this.DeadPerson != null ? this.DeadPerson.NameFormatted : "";
                }
            }

            public string IsPaidFormatted
            {
                get
                {
                    return this.BookedService != null ? (this.BookedService.IsPaid ? "Tak" : "Nie") : "";
                }
            }

            public string IsFinishedFormatted
            {
                get
                {
                    return this.BookedService != null ? (this.BookedService.IsFinished ? "Tak" : "Nie") : "";
                }
            }

            public BookedServiceViewModel(BookedService bookedService, DeadPerson deadPerson)
            {
                this.BookedService = bookedService;
                this.DeadPerson = deadPerson;
            }
        }

        private void bindServiceList()
        {
            repServices.DataSource = new ServicesService().getAll();
            repServices.DataBind();
        }

        private void bindBookedServiceList(ApplicationUser user)
        {
            List<BookedService> listBookedService = new BookedServicesService().getByFamilyMemberID(user.FamilyMemberID.Value);
            List<Guid> listBurialPlaceID = listBookedService.Select(x => x.BurialPlace.BurialPlaceID).ToList();
            List<DeadPerson> listDeadPerson = new DeadPersonService().getBy(x => listBurialPlaceID.Contains(x.BurialPlaceID)).ToList();

            repBookedServices.DataSource = listBookedService.Select(x => new BookedServiceViewModel(x, listDeadPerson.FirstOrDefault(y => y.BurialPlaceID.Equals(x.BurialPlaceID))));
            repBookedServices.DataBind();
        }

        private void bindDeadPersonForFamilyMember(ApplicationUser user)
        {
            List<DeadPerson> listDeadPerson = new DeadPersonService().getBy(x => x.FamilyMemberID.HasValue && x.FamilyMemberID.Value.Equals(user.FamilyMemberID));
            ddlDeadPerson.Items.Clear();
            ddlDeadPerson.Items.AddRange(listDeadPerson.Select(x => new ListItem(x.NameFormatted, x.DeadPersonID.ToString())).ToArray());
        }

        protected void btnBookService_ServerClick(object sender, EventArgs e)
        {
            try
            {
                ApplicationUser user = new UserService().getCurrentUser(this.Context);

                Guid serviceID = Guid.Parse(hfServiceID.Value);
                Guid deadPersonID = Guid.Parse(ddlDeadPerson.SelectedValue);
                Guid familyMemberID = user.FamilyMemberID.Value;

                BookedService bookedService = new BookedServicesService().createForFamilyMember(serviceID, familyMemberID, deadPersonID);
            }
            catch (Exception ex) { }
            Response.Redirect("/Pages/BookedServiceList");
        }

        protected void btnPayForService_ServerClick(object sender, EventArgs e)
        {
            try
            {
                new BookedServicesService().pay(Guid.Parse(hfBookedServiceID.Value));
                this.bindBookedServiceList(new UserService().getCurrentUser(this.Context));
            }
            catch (Exception ex) { }
            Response.Redirect("/Pages/BookedServiceList");
        }

        protected void btnCancelBookedService_ServerClick(object sender, EventArgs e)
        {
            try
            {
                new BookedServicesService().delete(Guid.Parse(hfBookedServiceID.Value));
            }
            catch (Exception ex) { }
            Response.Redirect("/Pages/BookedServiceList");
        }
    }
}