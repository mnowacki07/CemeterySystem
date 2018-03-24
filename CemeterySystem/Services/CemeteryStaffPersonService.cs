using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class CemeteryStaffPersonService
    {
        public CemeteryStaffPerson create(CemeteryStaffPerson cemeteryStaffPerson)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new CemeteryStaffPersonRepository(dbContext).create(cemeteryStaffPerson);
                    dbContext.SaveChanges();
                    return cemeteryStaffPerson;
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(CemeteryStaffPerson cemeteryStaffPerson)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new CemeteryStaffPersonRepository(dbContext).update(cemeteryStaffPerson);
                    dbContext.SaveChanges();                    
                }
            }
            catch (Exception ex) { }            
        }

        public List<CemeteryStaffPerson> getAll()
        {
            try
            {
                List<CemeteryStaffPerson> listCemeteryStaffPerson = new List<CemeteryStaffPerson>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listCemeteryStaffPerson = new CemeteryStaffPersonRepository(dbContext).getAll();                                        
                }
                return listCemeteryStaffPerson;
            }
            catch (Exception ex) { }
            return new List<CemeteryStaffPerson>();
        }

        public List<CemeteryStaffPerson> getBy(Func<CemeteryStaffPerson, bool> whereClausule)
        {
            try
            {
                List<CemeteryStaffPerson> listCemeteryStaffPerson = new List<CemeteryStaffPerson>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listCemeteryStaffPerson = new CemeteryStaffPersonRepository(dbContext).getBy(whereClausule);
                }
                return listCemeteryStaffPerson;
            }
            catch (Exception ex) { }
            return new List<CemeteryStaffPerson>();
        }

        public CemeteryStaffPerson getByID(string id)
        {
            try
            {
                CemeteryStaffPerson cemeteryStaffPerson = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    cemeteryStaffPerson = new CemeteryStaffPersonRepository(dbContext).getByID(id);
                }
                return cemeteryStaffPerson;
            }
            catch (Exception ex) { }
            return null;
        }

        public void delete(CemeteryStaffPerson cemeteryStaffPerson)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                new CemeteryStaffPersonRepository(dbContext).delete(cemeteryStaffPerson);
                dbContext.SaveChanges();
            }
        }
    }
}