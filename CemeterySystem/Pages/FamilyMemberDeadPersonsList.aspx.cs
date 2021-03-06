﻿using CemeterySystem.DBModels;
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
    public partial class FamilyMemberDeadPersonsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (!this.User.Identity.IsAuthenticated || !this.User.IsInRole(UserRoleRepository.FAMILY_MEMBER_ROLE_NAME))
                {
                    Response.Redirect("/Pages/LoginPage.aspx");
                }

                this.bindDeadPersonList();
            }
        }

        private void bindDeadPersonList()
        {
            ApplicationUser user = new UserService().getCurrentUser(Context);

            if(user.FamilyMember != null)
            {
                List<DeadPerson> listDeadPerson = new DeadPersonService().getBy(x => x.FamilyMemberID.HasValue && x.FamilyMemberID.Equals(user.FamilyMember.FamilyMemberID));
                repDeadPersons.DataSource = listDeadPerson;
                repDeadPersons.DataBind();
            }            
        }
    }
}