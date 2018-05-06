using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class ServicesRepository : Repository<Service>
    {
        public ServicesRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(Service objectToCreate)
        {
            this._dbContext.Services.Add(objectToCreate);
        }

        public override void delete(Service objectToDelete)
        {
            this._dbContext.Entry(objectToDelete).State = System.Data.Entity.EntityState.Deleted;
        }

        public override List<Service> getAll()
        {
            return this._dbContext
                        .Services
                        .ToList();
        }

        public override List<Service> getBy(Func<Service, bool> whereClausule)
        {
            return this._dbContext
                        .Services
                        .Where(whereClausule)
                        .ToList();
        }

        public override Service getByID(string id)
        {
            return this._dbContext
                        .Services
                        .FirstOrDefault(x => x.ServiceID.ToString().Equals(id));
        }

        public override void update(Service objectToUpdate)
        {
            this._dbContext.Services.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
        }
    }
}