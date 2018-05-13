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
        public FuneralCompany getByID(Guid id)
        {
            try
            {
                FuneralCompany funeralCompany = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    funeralCompany = new FuneralCompanyRepository(dbContext).getByID(id.ToString());
                }
                return funeralCompany;
            }
            catch (Exception ex) { }
            return null;
        }

        public FuneralCompany getByID(String id)
        {
            try
            {
                FuneralCompany funeralCompany = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    funeralCompany = new FuneralCompanyRepository(dbContext).getByID(id.ToString());
                }
                return funeralCompany;
            }
            catch (Exception ex) { }
            return null;
        }

        public List<FuneralCompany> getAll()
        {
            try
            {
                List<FuneralCompany> listFuneralCompany = new List<FuneralCompany>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listFuneralCompany = new FuneralCompanyRepository(db).getAll();
                }
                return listFuneralCompany;
            }
            catch (Exception ex) { }
            return new List<FuneralCompany>();
        }

        public FuneralCompany create(FuneralCompany funeralCompany)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new FuneralCompanyRepository(dbContext).create(funeralCompany);
                    dbContext.SaveChanges();
                    return funeralCompany;
                }
            }
            catch (Exception ex) { }
            return null;
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

        internal void delete(FuneralCompany funeralCompany)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                new FuneralCompanyRepository(dbContext).delete(funeralCompany);
                dbContext.SaveChanges();
            }
        }
    }
}