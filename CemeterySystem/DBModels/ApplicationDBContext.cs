using CemeterySystem.DBModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CemeterySystem.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public virtual DbSet<SpotModel> Spots { get; set; }

        public ApplicationDbContext() : base("defConnString", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}