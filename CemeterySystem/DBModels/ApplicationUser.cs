using CemeterySystem.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CemeterySystem.DBModels
{
    public class ApplicationUser : IdentityUser
    {
        public Guid? FamilyMemberID { get; set; }
        [ForeignKey("FamilyMemberID")]
        public FamilyMember FamilyMember { get; set; }

        [NotMapped]
        public string RoleNameFormatted
        {
            get
            {
                if(this.Roles != null && this.Roles.Count > 0)
                {
                    return "" + UserRoleRepository.getRoleNameByRoleID(this.Roles.ToList()[0].RoleId);
                }
                return "";
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}