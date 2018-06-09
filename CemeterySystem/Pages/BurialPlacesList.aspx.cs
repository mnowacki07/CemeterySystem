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
    public partial class BurialPlacesList : System.Web.UI.Page
    {
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
                    this.bindBurialPlaceList();
                }
            }
        }

        private class BurialPlaceViewModel
        {
            public BurialPlace BurialPlace { get; private set; }
            public DeadPerson DeadPerson { get; private set; }

            public string DeadPersonAnchor
            {
                get
                {
                    if(this.DeadPerson != null)
                    {
                        return string.Format("<a href=\"/Pages/DeadPersonsDetails?DeadPersonID={0}\">{1}</a>", this.DeadPerson.DeadPersonID.ToString(), this.DeadPerson.NameFormatted);
                    }
                    return "";
                }
            }

            public string FamilyMemberAnchor
            {
                get
                {
                    if(this.DeadPerson?.FamilyMember != null)
                    {
                        return string.Format("<a href=\"/Pages/FamilyMemberDetails?FamilyMemberID={0}\">{1}</a>", this.DeadPerson.FamilyMember.FamilyMemberID.ToString(), this.DeadPerson.FamilyMember.NameFormatted);
                    }
                    return "";
                }
            }

            public BurialPlaceViewModel(BurialPlace burialPlace, DeadPerson deadPerson)
            {
                this.BurialPlace = burialPlace;
                this.DeadPerson = deadPerson;
            }
        }

        private void bindBurialPlaceList()
        {
            try
            {
                List<BurialPlace> listBurialPlace = new BurialPlaceService().getAll();

                List<Guid> listBurialPlaceID = listBurialPlace
                                                .Select(x => x.BurialPlaceID)
                                                .ToList();

                List<DeadPerson> listDeadPerson = new DeadPersonService().getBy(x => x.BurialPlaceID != null && listBurialPlaceID.Contains(x.BurialPlaceID));

                List<BurialPlaceViewModel> listBurialPlaceViewModel = listBurialPlace
                                                                        .Select(x => new BurialPlaceViewModel(
                                                                            x, 
                                                                            listDeadPerson.Find(y => y.BurialPlaceID.Equals(x.BurialPlaceID))))
                                                                        .ToList();

                repBurialPlace.DataSource = listBurialPlaceViewModel;
                repBurialPlace.DataBind();
            }
            catch (Exception ex) { }
        }
    }
}