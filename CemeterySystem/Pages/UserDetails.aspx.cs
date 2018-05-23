using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using CemeterySystem.Services;
using Microsoft.AspNet.Identity.EntityFramework;
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
                    else
                    {
                        btnDelete.Visible = false;
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
            ApplicationUser user = new UserService().getByID(this.UserID.ToString());

            if(user == null)
            {
                Response.Redirect("/Pages/UsersList");
            }
            else
            {
                txtUsername.Text = user.UserName;
                txtEmail.Text = user.Email;
                ddlRole.SelectedValue = user.Roles.ToList()[0].RoleId;

                if(user.FamilyMember != null)
                {
                    txtFirstName.Text = user.FamilyMember.FirstName;
                    txtLastName.Text = user.FamilyMember.LastName;
                    txtRelationship.Text = user.FamilyMember.Relationship;
                    txtPhoneNumber.Text = user.FamilyMember.PhoneNumber;

                    if(user.FamilyMember.Address != null)
                    {
                        txtStreet.Text = user.FamilyMember.Address.Street;
                        txtHouseNumber.Text = user.FamilyMember.Address.HouseNumber;
                        txtFlatNumber.Text = user.FamilyMember.Address.FlatNumber;
                        txtTown.Text = user.FamilyMember.Address.Town;
                        txtPostCode.Text = user.FamilyMember.Address.PostCode;
                    }
                }
            }
        }

        private void bindUserRoleDDL()
        {
            ddlRole.Items.Clear();
            ddlRole.Items.Add(new ListItem(UserRoleRepository.FAMILY_MEMBER_ROLE_NAME, UserRoleRepository.FAMILY_MEMBER_ROLE_ID));
            ddlRole.Items.Add(new ListItem(UserRoleRepository.MANAGER_ROLE_NAME, UserRoleRepository.MANAGER_ROLE_ID));
            ddlRole.Items.Add(new ListItem(UserRoleRepository.ADMIN_ROLE_NAME, UserRoleRepository.ADMIN_ROLE_ID));

            if (!this.IsCreateMode)
            {
                ddlRole.Enabled = false;
            }
        }

        private void saveUser()
        {
            ApplicationUser user = null;

            #region GET USER

            if(this.IsCreateMode)
            {
                user = new ApplicationUser();
                user.Id = Guid.NewGuid().ToString();
            }
            else
            {
                user = new UserService().getByID(this.UserID.ToString());

                if(user == null)
                {
                    Response.Redirect("/Pages/UserList");
                }
            }

            #endregion

            #region SET BASIC DATA

            user.UserName = txtUsername.Text;
            user.Email = txtEmail.Text;

            #endregion

            #region SET FAMILY MEMBER

            if (ddlRole.SelectedValue.Equals(UserRoleRepository.FAMILY_MEMBER_ROLE_ID))
            {
                if (user.FamilyMember == null)
                {
                    user.FamilyMember = new FamilyMember()
                    {
                        FamilyMemberID = Guid.NewGuid()
                    };
                    user.FamilyMember.FamilyMemberID = user.FamilyMember.FamilyMemberID;
                }

                if (user.FamilyMember.Address == null)
                {
                    user.FamilyMember.Address = new Address()
                    {
                        CustomAddressID = Guid.NewGuid()
                    };
                    user.FamilyMember.AddressID = user.FamilyMember.Address.CustomAddressID;
                }

                user.FamilyMember.FirstName = txtFirstName.Text;
                user.FamilyMember.LastName = txtLastName.Text;
                user.FamilyMember.PhoneNumber = txtPhoneNumber.Text;
                user.FamilyMember.Relationship = txtRelationship.Text;
                user.FamilyMember.Address.Street = txtStreet.Text;
                user.FamilyMember.Address.HouseNumber = txtHouseNumber.Text;
                user.FamilyMember.Address.FlatNumber = txtFlatNumber.Text;
                user.FamilyMember.Address.Town = txtTown.Text;
                user.FamilyMember.Address.PostCode = txtPostCode.Text;
                user.FamilyMember.Address.PhoneNumber = txtPhoneNumber.Text;
            }

            #endregion

            #region SET ROLE

            if(this.IsCreateMode)
            {
                user.Roles.Add(new IdentityUserRole() { UserId = user.Id, RoleId = ddlRole.SelectedValue });
            }

            #endregion

            if (this.IsCreateMode)
            {
                var result = new UserService().registerUser(user, txtPassword.Text);

                if(result.Succeeded)
                {
                    Response.Redirect(string.Format("/Pages/UserDetails?UserID{0}", user.Id));
                }
                else
                {
                    Response.Redirect("/Pages/UsersList");
                }
            }
            else
            {
                new UserService().update(user, txtPassword.Text);
            }
        }

        protected void lbtnGoBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/UsersList");
        }

        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            this.saveUser();
        }

        protected void btnDelete_ServerClick(object sender, EventArgs e)
        {
            new UserService().delete(this.UserID);
            Response.Redirect("/Pages/UsersList");
        }
    }
}
