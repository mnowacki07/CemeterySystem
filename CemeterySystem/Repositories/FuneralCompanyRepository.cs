using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class FuneralCompanyRepository : Repository<FuneralCompany>
    {
        public FuneralCompanyRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(FuneralCompany objectToCreate)
        {
            this._dbContext
                .FuneralCompanies
                .Add(objectToCreate);
        }

        public override void delete(FuneralCompany objectToDelete)
        {
            if (objectToDelete != null)
            {
                objectToDelete.IsDeleted = true;
                this.update(objectToDelete);
            }
        }

        public override List<FuneralCompany> getAll()
        {
            return this._dbContext
                            .FuneralCompanies
                            .Include(x => x.Address)
                            .Where(x => !x.IsDeleted)
                            .ToList();
        }

        public override List<FuneralCompany> getBy(Func<FuneralCompany, bool> whereClausule)
        {
            return this._dbContext
                        .FuneralCompanies
                        .Include(x => x.Address)
                        .Where(x => !x.IsDeleted)
                        .Where(whereClausule)
                        .ToList();
        }

        public override FuneralCompany getByID(string id)
        {
            return this._dbContext
                        .FuneralCompanies
                        .Include(x => x.Address)
                        .FirstOrDefault(x => !x.IsDeleted && x.FuneralCompanyID.ToString().Equals(id));
        }

        public override void update(FuneralCompany objectToUpdate)
        {
            this._dbContext.FuneralCompanies.Attach(objectToUpdate);
            this._dbContext.Addresses.Attach(objectToUpdate.Address);
            this._dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
            this._dbContext.Entry(objectToUpdate.Address).State = System.Data.Entity.EntityState.Modified;
        }
    }
}