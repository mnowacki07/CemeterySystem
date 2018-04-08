using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class BurialPlaceService
    {
        public BurialPlace create(BurialPlace burialPlace)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new BurialPlaceRepository(dbContext).create(burialPlace);
                    dbContext.SaveChanges();
                    return burialPlace;
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(BurialPlace burialPlace)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new BurialPlaceRepository(dbContext).update(burialPlace);
                    dbContext.SaveChanges();                    
                }
            }
            catch (Exception ex) { }            
        }

        public List<BurialPlace> getAll()
        {
            try
            {
                List<BurialPlace> listBurialPlace = new List<BurialPlace>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listBurialPlace = new BurialPlaceRepository(dbContext).getAll();                                        
                }
                return listBurialPlace;
            }
            catch (Exception ex) { }
            return new List<BurialPlace>();
        }

        public List<BurialPlace> getBy(Func<BurialPlace, bool> whereClausule)
        {
            try
            {
                List<BurialPlace> listBurialPlace = new List<BurialPlace>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listBurialPlace = new BurialPlaceRepository(dbContext).getBy(whereClausule);
                }
                return listBurialPlace;
            }
            catch (Exception ex) { }
            return new List<BurialPlace>();
        }

        public BurialPlace getByID(string id)
        {
            try
            {
                BurialPlace burialPlace = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    burialPlace = new BurialPlaceRepository(dbContext).getByID(id);
                }
                return burialPlace;
            }
            catch (Exception ex) { }
            return null;
        }

        public void delete(BurialPlace burialPlace)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                new BurialPlaceRepository(dbContext).delete(burialPlace);
                dbContext.SaveChanges();
            }
        }
    }
}