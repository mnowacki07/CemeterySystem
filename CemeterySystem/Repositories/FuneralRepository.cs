using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class FuneralRepository : Repository<Funeral>
    {
        public FuneralRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(Funeral objectToCreate)
        {
            this._dbContext
                .Funerals
                .Add(objectToCreate);
        }

        public override void delete(Funeral objectToDelete)
        {
            if (objectToDelete != null)
            {
               // objectToDelete.IsDeleted = true;
                this.update(objectToDelete);
            }
        }

        public override List<Funeral> getAll()
        {
            return this._dbContext
                            .Funerals
                            .Include(x => x.FuneralCompany)
                            .Include(x => x.CemeteryStaffPerson)
                           .Where(x => !x.IsDeleted)
                            .ToList();
        }

        public override List<Funeral> getBy(Func<Funeral, bool> whereClausule)
        {
            return this._dbContext
                        .Funerals
                        .Include(x => x.FuneralCompany)
                        .Include(x => x.CemeteryStaffPerson)
                        .Where(x => !x.IsDeleted)
                        .Where(whereClausule)
                        .ToList();
        }

        public override Funeral getByID(string id)
        {
            return this._dbContext
                        .Funerals
                         .Include(x => x.FuneralCompany)
                         .Include(x => x.CemeteryStaffPerson)
                       .FirstOrDefault(x => !x.IsDeleted && x.FuneralID.ToString().Equals(id)); 
                       
        }

        public override void update(Funeral objectToUpdate)
        {
            this._dbContext.Funerals.Attach(objectToUpdate);
            this._dbContext.FuneralCompanies.Attach(objectToUpdate.FuneralCompany);
            this._dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
            this._dbContext.CemeteryStaffPersons.Attach(objectToUpdate.CemeteryStaffPerson);
            this._dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
            this._dbContext.Entry(objectToUpdate.FuneralCompany).State = System.Data.Entity.EntityState.Modified;
            this._dbContext.Entry(objectToUpdate.CemeteryStaffPerson).State = System.Data.Entity.EntityState.Modified;
        }
    }
}