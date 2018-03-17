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
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<FuneralCompany> FuneralCompanies { get; set; }
        public virtual DbSet<CemeteryStaffPerson> CemeteryStaffPersons { get; set; }
        public virtual DbSet<BurialPlace> BurialPlaces { get; set; }
        public virtual DbSet<BurialPlaceBooker> BurialPlaceBookers { get; set; }
        public virtual DbSet<Funeral> Funerals { get; set; }
        public virtual DbSet<DeadPerson> DeadPersons { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<PaymentClass> PaymentClassess { get; set; }

        public ApplicationDbContext() : base("defConnString", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}