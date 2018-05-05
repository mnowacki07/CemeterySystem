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
    public partial class DeadPersonsList : System.Web.UI.Page
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
                    this.bindDeadPersonList();
                }
            }
        }


        private class DeadPersonViewModel
        {
            public DeadPerson DeadPerson { get; private set; }

            public DeadPersonViewModel(DeadPerson deadPerson)
            {
                  this.DeadPerson = deadPerson;
            }
        }

        private void bindDeadPersonList()
        {
            try
            {
                List<DeadPerson> listDeadPerson = new DeadPersonService().getAll();
                List<Guid> listDeadPersonID = listDeadPerson.Select(x => x.DeadPersonID).ToList();
                List<DeadPersonViewModel> listDeadPersonViewModel = new List<DeadPersonViewModel>();

                for (int i = 0; i < listDeadPerson.Count; i++)
                {
                  listDeadPersonViewModel.Add(new DeadPersonViewModel(listDeadPerson[i]));
                }

                repDeadPerson.DataSource = listDeadPersonViewModel;
                repDeadPerson.DataBind();
            }
            catch (Exception ex) { }
        }
    }
}