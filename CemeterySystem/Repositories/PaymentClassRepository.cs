using CemeterySystem.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Repositories
{
    public class PaymentClassRepository : Repository<PaymentClass>
    {
        public PaymentClassRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override void create(PaymentClass objectToCreate)
        {
            _dbContext.PaymentClassess.Add(objectToCreate);            
        }

        public override void delete(PaymentClass objectToDelete)
        {
            if(objectToDelete != null)
            {
                objectToDelete.IsDeleted = true;
                this.update(objectToDelete);
            }
        }

        public override List<PaymentClass> getAll()
        {
            return _dbContext
                    .PaymentClassess
                    .Where(x => !x.IsDeleted)
                    .ToList();
        }

        public override List<PaymentClass> getBy(Func<PaymentClass, bool> whereClausule)
        {
            return _dbContext.PaymentClassess.Where(x => !x.IsDeleted).Where(whereClausule).ToList();
        }

        public override PaymentClass getByID(string id)
        {
            return _dbContext.PaymentClassess.FirstOrDefault(x => !x.IsDeleted && x.PaymentClassID.ToString().Equals(id));
        }

        public override void update(PaymentClass objectToUpdate)
        {
            _dbContext.PaymentClassess.Attach(objectToUpdate);
            _dbContext.Entry(objectToUpdate).State = System.Data.Entity.EntityState.Modified;
        }
    }
}