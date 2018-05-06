using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class ServicesService
    {
        public List<Service> getAll()
        {
            try
            {
                List<Service> listService = new List<Service>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listService = new ServicesRepository(db).getAll();
                }
                return listService;
            }
            catch(Exception ex) { }
            return new List<Service>();
        }

        public Service getByID(Guid id)
        {
            try
            {
                Service service = null;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    service = new ServicesRepository(db).getByID(id.ToString());
                }
                return service;
            }
            catch (Exception ex) { }
            return null;
        }

        public Service create(Service service)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    service.ServiceID = Guid.NewGuid();
                    new ServicesRepository(db).create(service);
                    db.SaveChanges();
                }
                return service;
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(Service service)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    new ServicesRepository(db).update(service);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public void delete(Guid serviceID)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    ServicesRepository repo = new ServicesRepository(db);
                    Service service = repo.getByID(serviceID.ToString());

                    if(service == null)
                    {
                        return;
                    }

                    repo.delete(service);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
}