using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Repositories
{
    public class CemeteryStaffPersonRepository : Repository<CemeteryStaffPerson>
    {
        public CemeteryStaffPersonRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(CemeteryStaffPerson objectToCreate)
        {
            this._dbContext.CemeteryStaffPersons.Add(objectToCreate);
        }

        public override void delete(CemeteryStaffPerson objectToDelete)
        {
            objectToDelete.IsDeleted = true;
            this.update(objectToDelete);
        }

        public override List<CemeteryStaffPerson> getAll()
        {
            return this._dbContext
                    .CemeteryStaffPersons
                    .Where(x => !x.IsDeleted)
                    .ToList();
        }

        public override List<CemeteryStaffPerson> getBy(Func<CemeteryStaffPerson, bool> whereClausule)
        {
            return this._dbContext
                    .CemeteryStaffPersons
                    .Where(whereClausule)
                    .ToList();
        }

        public override CemeteryStaffPerson getByID(string id)
        {
            return this._dbContext
                    .CemeteryStaffPersons
                    .FirstOrDefault(x => x.CemeteryStaffPersonID.ToString().Equals(id));
        }

        public override void update(CemeteryStaffPerson objectToUpdate)
        {
            this._dbContext.CemeteryStaffPersons.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
        }
    }
}