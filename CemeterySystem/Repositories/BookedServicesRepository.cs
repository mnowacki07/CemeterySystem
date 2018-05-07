using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class BookedServicesRepository : Repository<BookedService>
    {
        public BookedServicesRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(BookedService objectToCreate)
        {
            this._dbContext.BookedServices.Add(objectToCreate);
        }

        public override void delete(BookedService objectToDelete)
        {            
            this._dbContext.Entry(objectToDelete).State = System.Data.Entity.EntityState.Deleted;
        }

        public override List<BookedService> getAll()
        {
            return this._dbContext
                        .BookedServices
                        .Include(x => x.BurialPlace)
                        .Include(x => x.FamilyMember)
                        .ToList();
        }

        public override List<BookedService> getBy(Func<BookedService, bool> whereClausule)
        {
            return this._dbContext
                        .BookedServices
                        .Include(x => x.BurialPlace)
                        .Include(x => x.FamilyMember)
                        .Where(whereClausule)
                        .ToList();
        }

        public override BookedService getByID(string id)
        {
            return this._dbContext
                        .BookedServices
                        .Include(x => x.BurialPlace)
                        .Include(x => x.FamilyMember)
                        .FirstOrDefault(x => x.BookedServiceID.ToString().Equals(id));
        }

        public override void update(BookedService objectToUpdate)
        {
            this._dbContext.BookedServices.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
        }

        public void pay(BookedService bookedService)
        {
            this._dbContext.Configuration.ValidateOnSaveEnabled = false;
            this._dbContext.BookedServices.Attach(bookedService);
            this._dbContext.Entry(bookedService).Property(x => x.IsPaid).IsModified = true;
        }
    }
}