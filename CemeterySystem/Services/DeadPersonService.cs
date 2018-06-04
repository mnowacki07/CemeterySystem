using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class DeadPersonService
    {
        public List<DeadPerson> getAll()
        {
            try
            {
                List<DeadPerson> listDeadPerson = new List<DeadPerson>();                
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listDeadPerson = new DeadPersonRepository(db).getAll();
                }
                return listDeadPerson;
            }
            catch (Exception ex) { }
            return new List<DeadPerson>();
        }

        public List<DeadPerson> getBy(Func<DeadPerson, bool> whereClausule)
        {
            try
            {
                List<DeadPerson> listDeadPerson = new List<DeadPerson>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listDeadPerson = new DeadPersonRepository(db).getBy(whereClausule);
                }
                return listDeadPerson;
            }
            catch (Exception ex) { }
            return new List<DeadPerson>();
        }

        public DeadPerson getByID(Guid id)
        {
            try
            {
                DeadPerson deadPerson = null;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    deadPerson = new DeadPersonRepository(db).getByID(id.ToString());
                }
                return deadPerson;
            }
            catch (Exception ex) { }
            return null;
        }

        public void processPayment(Guid deadPersonID, Guid familyMemberID)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            DeadPerson deadPerson = new DeadPersonRepository(db).getByID(deadPersonID.ToString());

                            if(deadPerson.FamilyMemberID.Value != familyMemberID)
                            {
                                throw new Exception("Family member is allowed to edit only dead person that is under him");
                            }

                            DateTime? nextPaymentDate = deadPerson.BurialPlace.FuturePaymentDate;

                            if(nextPaymentDate.HasValue)
                            {
                                deadPerson.BurialPlace.PaymentDate = nextPaymentDate.Value;
                            }
                            else
                            {
                                deadPerson.BurialPlace.PaymentDate = DateTime.Now.AddDays(deadPerson.BurialPlace.PaymentClass.ExtraDaysForPaymentMade);
                            }

                            new DeadPersonRepository(db).update(deadPerson);

                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        //
        //
        //
        //
        //

        public DeadPerson create(DeadPerson deadPerson)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new DeadPersonRepository(dbContext).create(deadPerson);
                    dbContext.SaveChanges();
                    return deadPerson;
                }
            }
            catch (Exception ex) { }
            return null;
        }



        internal void delete(DeadPerson deadPerson)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                new DeadPersonRepository(dbContext).delete(deadPerson);
                dbContext.SaveChanges();
            }
        }

        public void update(DeadPerson deadPerson)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new DeadPersonRepository(dbContext).update(deadPerson);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }




        public DeadPerson getByID(string id)
        {
            try
            {
                DeadPerson deadPerson = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    deadPerson = new DeadPersonRepository(dbContext).getByID(id);
                }
                return deadPerson;
            }
            catch (Exception ex) { }
            return null;
        }
    }
}
