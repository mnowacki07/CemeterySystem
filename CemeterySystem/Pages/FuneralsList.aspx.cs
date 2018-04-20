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
    public partial class FuneralsList : System.Web.UI.Page
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
                    this.bindFuneralList();
                }
            }
        }

        private class FuneralViewModel
        {
            public Funeral Funeral { get; private set; }
            public DeadPerson DeadPerson { get; private set; }

            public FuneralViewModel(Funeral funeral, DeadPerson deadPerson)
            {
                this.Funeral = funeral;
                this.DeadPerson = deadPerson;
            }
        }

        private void bindFuneralList()
        {
            try
            {
                List<Funeral> listFuneral = new FuneralService().getAll();
                List<Guid> listFuneralID = listFuneral.Select(x => x.FuneralID).ToList();
                List<DeadPerson> listDeadPerson = new DeadPersonService().getBy(x => listFuneralID.Contains(x.FuneralID));
                List<FuneralViewModel> listFuneralViewModel = new List<FuneralViewModel>();

                for (int i = 0; i < listFuneral.Count; i++)
                {
                    DeadPerson deadPerson = listDeadPerson.FirstOrDefault(x => x.FuneralID.Equals(listFuneral[i].FuneralID));
                    listFuneralViewModel.Add(new FuneralViewModel(listFuneral[i], deadPerson));
                }
                
                repFuneral.DataSource = listFuneralViewModel;
                repFuneral.DataBind();
            }
            catch (Exception ex) { }
        }
    }
}