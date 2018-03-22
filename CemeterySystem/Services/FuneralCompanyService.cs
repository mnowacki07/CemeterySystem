using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class FuneralCompanyService
    {
        public FuneralCompany get()
        {
            try
            {
                FuneralCompany funeralCompany = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    funeralCompany = new FuneralCompanyRepository(dbContext).getFirst();
                }
                return funeralCompany;
            }
            catch (Exception ex) { }
            return null;
        }

        public void create(FuneralCompany funeralCompany)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var repo = new FuneralCompanyRepository(dbContext);
                    funeralCompany.FuneralCompanyID = Guid.NewGuid();
                    funeralCompany.Address.CustomAddressID = Guid.NewGuid();
                    funeralCompany.AddressID = funeralCompany.Address.CustomAddressID;

                    repo.create(funeralCompany);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public void update(FuneralCompany funeralCompany)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new FuneralCompanyRepository(dbContext).update(funeralCompany);
                    dbContext.SaveChanges();
                }                
            }
            catch (Exception ex) { }            
        }
    }
}