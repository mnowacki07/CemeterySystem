using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class BurialPlaceRepository : Repository<BurialPlace>
    {
        public BurialPlaceRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(BurialPlace objectToCreate)
        {
            this._dbContext.BurialPlaces.Add(objectToCreate);
        }

        public override void delete(BurialPlace objectToDelete)
        {
            if (objectToDelete != null)
            {
                objectToDelete.IsDeleted = true;
                this.update(objectToDelete);
            }
        }

        public override List<BurialPlace> getAll()
        {
            return this._dbContext
                        .BurialPlaces
                        .Include(x => x.PaymentClass)
                        .Where(x => !x.IsDeleted)
                        .ToList();
        }

        public override List<BurialPlace> getBy(Func<BurialPlace, bool> whereClausule)
        {
            return this._dbContext
                        .BurialPlaces
                        .Include(x => x.PaymentClass)
                        .Where(x => !x.IsDeleted)
                        .Where(whereClausule)
                        .ToList();
        }

        public override BurialPlace getByID(string id)
        {
            return this._dbContext
                        .BurialPlaces
                        .Include(x => x.PaymentClass)
                        .FirstOrDefault(x => !x.IsDeleted && x.BurialPlaceID.ToString().Equals(id));
        }

        public override void update(BurialPlace objectToUpdate)
        {
            this._dbContext.BurialPlaces.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = EntityState.Modified;
        }
    }
}