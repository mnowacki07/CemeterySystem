using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class DeadPersonRepository : Repository<DeadPerson>
    {
        public DeadPersonRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(DeadPerson objectToCreate)
        {
            this._dbContext.DeadPersons.Add(objectToCreate);
        }

        public override void delete(DeadPerson objectToDelete)
        {
            objectToDelete.IsDeleted = true;
            this.update(objectToDelete);
        }

        public override List<DeadPerson> getAll()
        {
            return this._dbContext
                    .DeadPersons
                    .Include(x => x.BurialPlace)
                    .Include(x => x.BurialPlace.PaymentClass)
                    .Include(x => x.FamilyMember)
                    .Include(x => x.Funeral)
                    .Include(x => x.Funeral.CemeteryStaffPerson)
                    .Include(x => x.Funeral.FuneralCompany)
                    .Where(x => !x.IsDeleted)
                    .ToList();
        }

        public override List<DeadPerson> getBy(Func<DeadPerson, bool> whereClausule)
        {
            return this._dbContext
                    .DeadPersons
                    .Include(x => x.BurialPlace)
                    .Include(x => x.BurialPlace.PaymentClass)
                    .Include(x => x.FamilyMember)
                    .Include(x => x.Funeral)
                    .Include(x => x.Funeral.CemeteryStaffPerson)
                    .Include(x => x.Funeral.FuneralCompany)
                    .Where(whereClausule)
                    .Where(x => !x.IsDeleted)
                    .ToList();
        }

        public override DeadPerson getByID(string id)
        {
            return this._dbContext
                    .DeadPersons
                    .Include(x => x.BurialPlace)
                    .Include(x => x.BurialPlace.PaymentClass)
                    .Include(x => x.FamilyMember)
                    .Include(x => x.Funeral)
                    .Include(x => x.Funeral.CemeteryStaffPerson)
                    .Include(x => x.Funeral.FuneralCompany)
                    .FirstOrDefault(x => !x.IsDeleted && x.DeadPersonID.ToString().Equals(id));
        }

        public override void update(DeadPerson objectToUpdate)
        {
            this._dbContext.DeadPersons.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = EntityState.Modified;
        }
    }
}