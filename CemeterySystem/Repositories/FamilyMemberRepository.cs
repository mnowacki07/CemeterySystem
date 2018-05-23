using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CemeterySystem.Repositories
{
    public class FamilyMemberRepository : Repository<FamilyMember>
    {
        public FamilyMemberRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(FamilyMember objectToCreate)
        {
            this._dbContext.FamilyMembers.Add(objectToCreate);
        }

        public override void delete(FamilyMember objectToDelete)
        {
            this._dbContext.FamilyMembers.Attach(objectToDelete);
            this._dbContext.Entry(objectToDelete).State = EntityState.Deleted;
        }

        public override List<FamilyMember> getAll()
        {
            return this._dbContext
                    .FamilyMembers
                    .Include(x => x.Address)
                    .ToList();
        }

        public override List<FamilyMember> getBy(Func<FamilyMember, bool> whereClausule)
        {
            return this._dbContext
                    .FamilyMembers
                    .Include(x => x.Address)
                    .Where(whereClausule)
                    .ToList();
        }

        public override FamilyMember getByID(string id)
        {
            return this._dbContext
                    .FamilyMembers
                    .Include(x => x.Address)
                    .Where(x => x.FamilyMemberID.ToString().Equals(id))
                    .FirstOrDefault();
        }

        public override void update(FamilyMember objectToUpdate)
        {
            this._dbContext.FamilyMembers.Attach(objectToUpdate);
            this._dbContext.Entry(objectToUpdate).State = EntityState.Modified;
        }
    }
}