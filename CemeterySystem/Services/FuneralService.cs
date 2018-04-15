using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class FuneralService
    {
        public Funeral getByID(Guid id)
        {
            try
            {
                Funeral funeral = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    funeral = new FuneralRepository(dbContext).getByID(id.ToString());
                }
                return funeral;
            }
            catch (Exception ex) { }
            return null;
        }

        public List<Funeral> getAll()
        {
            try
            {
                List<Funeral> listFuneral = new List<Funeral>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listFuneral = new FuneralRepository(db).getAll();
                }
                return listFuneral;
            }
            catch (Exception ex) { }
            return new List<Funeral>();
        }

        public Funeral create(Funeral funeral)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new FuneralRepository(dbContext).create(funeral);
                    dbContext.SaveChanges();
                    return funeral;
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(Funeral funeral)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new FuneralRepository(dbContext).update(funeral);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        internal void delete(Funeral funeral)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                new FuneralRepository(dbContext).delete(funeral);
                dbContext.SaveChanges();
            }
        }
    }

}
