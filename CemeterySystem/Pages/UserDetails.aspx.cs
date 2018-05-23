using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CemeterySystem.Pages
{
    public partial class UserDetails : System.Web.UI.Page
    {
        public Guid UserID
        {
            get
            {
                try
                {
                    return Guid.Parse(this.Request.QueryString["UserID"]);
                }
                catch (Exception ex) { }
                return Guid.Empty;
            }
        }

        public bool IsCreateMode
        {
            get
            {
                return ("" + this.Request.QueryString["IsCreateMode"]).ToLower().Trim().Equals("true");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(this.User.Identity.IsAuthenticated && this.User.IsInRole(UserRoleRepository.MANAGER_ROLE_NAME))
                {
                    this.bindUserRoleDDL();

                    if(!IsCreateMode)
                    {
                        this.bindUser();
                    }
                }
                else
                {
                    this.Response.Redirect("/Pages/LoginPage");
                }
            }            
        }

        private void bindUser()
        {

        }

        private void bindUserRoleDDL()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.Add(new ListItem(UserRoleRepository.FAMILY_MEMBER_ROLE_NAME, UserRoleRepository.FAMILY_MEMBER_ROLE_ID));
            ddlRole.Items.Add(new ListItem(UserRoleRepository.MANAGER_ROLE_NAME, UserRoleRepository.MANAGER_ROLE_ID));
        }

        private void saveUser()
        {
            ApplicationUser user = new ApplicationUser();

            if(this.IsCreateMode)
            {
                user.Id = Guid.NewGuid().ToString();
            }
            else
            {
                user.Id = this.UserID.ToString();
            }

            user.UserName = txtUsername.Text;
            user.Email = txtEmail.Text;
            user.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole() { RoleId = ddlRole.SelectedValue, UserId = user.Id });
            
            if(ddlRole.SelectedValue.Equals(UserRoleRepository.FAMILY_MEMBER_ROLE_ID))
            {
                user.FamilyMemberID = Guid.NewGuid();
                Guid addressID = Guid.NewGuid();
                user.FamilyMember = new FamilyMember()
                {
                    FamilyMemberID = user.FamilyMemberID.Value,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    Relationship = txtRelationship.Text,
                    AddressID = addressID,
                    Address = new Address()
                    {
                        CustomAddressID = addressID,
                        Street = txtStreet.Text,
                        HouseNumber = txtHouseNumber.Text,
                        FlatNumber = txtFlatNumber.Text,
                        PostCode = txtPostCode.Text,
                        Town = txtTown.Text,
                        PhoneNumber = txtPhoneNumber.Text
                    }
                };
            }
        }
    }
}
