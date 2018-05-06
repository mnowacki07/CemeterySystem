using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class BookedServicesService
    {
        public List<BookedService> getAll()
        {
            try
            {
                List<BookedService> listService = new List<BookedService>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listService = new BookedServicesRepository(db).getAll();
                }
                return listService;
            }
            catch(Exception ex) { }
            return new List<BookedService>();
        }

        public BookedService create(BookedService service)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    service.BookedServiceID = Guid.NewGuid();
                    new BookedServicesRepository(db).create(service);
                    db.SaveChanges();
                }
                return service;
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(BookedService service)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    new BookedServicesRepository(db).update(service);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public void delete(BookedService service)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    new BookedServicesRepository(db).delete(service);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
}