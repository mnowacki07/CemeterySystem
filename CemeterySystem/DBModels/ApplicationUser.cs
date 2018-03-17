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

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}