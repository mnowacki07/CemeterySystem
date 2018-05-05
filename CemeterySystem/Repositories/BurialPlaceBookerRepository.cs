using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class BurialPlaceBookerRepository : Repository<BurialPlaceBooker>
    {
        public BurialPlaceBookerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(BurialPlaceBooker objectToCreate)
        {
            this._dbContext.BurialPlaceBookers.Add(objectToCreate);
        }

        public override void delete(BurialPlaceBooker objectToDelete)
        {
            this._dbContext.Entry(objectToDelete).State = EntityState.Deleted;
        }

        public override List<BurialPlaceBooker> getAll()
        {
            return this._dbContext
                            .BurialPlaceBookers
                            .Include(x => x.BurialPlace)
                            .Include(x => x.FamilyMember)                            
                            .ToList();
        }

        public override List<BurialPlaceBooker> getBy(Func<BurialPlaceBooker, bool> whereClausule)
        {
            return this._dbContext
                            .BurialPlaceBookers
                            .Include(x => x.BurialPlace)
                            .Include(x => x.FamilyMember)
                            .Where(whereClausule)
                            .ToList();
        }

        public override BurialPlaceBooker getByID(string id)
        {
            return this._dbContext
                            .BurialPlaceBookers
                            .Include(x => x.BurialPlace)
                            .Include(x => x.FamilyMember)
                            .FirstOrDefault(x => x.BurialPlaceBookerID.ToString().Equals(id));
        }

        public override void update(BurialPlaceBooker objectToUpdate)
        {
            this._dbContext.BurialPlaceBookers.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = EntityState.Modified;
        }
    }
}