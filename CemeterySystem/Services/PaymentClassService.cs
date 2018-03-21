using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class PaymentClassService
    {
        public PaymentClass create(PaymentClass paymentClass)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new PaymentClassRepository(dbContext).create(paymentClass);
                    dbContext.SaveChanges();
                    return paymentClass;
                }
            }
            catch (Exception ex) { }
            return null;
        }

        public void update(PaymentClass paymentClass)
        {
            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    new PaymentClassRepository(dbContext).update(paymentClass);
                    dbContext.SaveChanges();                    
                }
            }
            catch (Exception ex) { }            
        }

        public List<PaymentClass> getAll()
        {
            try
            {
                List<PaymentClass> listPaymentClass = new List<PaymentClass>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listPaymentClass = new PaymentClassRepository(dbContext).getAll();                                        
                }
                return listPaymentClass;
            }
            catch (Exception ex) { }
            return new List<PaymentClass>();
        }

        public List<PaymentClass> getBy(Func<PaymentClass, bool> whereClausule)
        {
            try
            {
                List<PaymentClass> listPaymentClass = new List<PaymentClass>();
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    listPaymentClass = new PaymentClassRepository(dbContext).getBy(whereClausule);
                }
                return listPaymentClass;
            }
            catch (Exception ex) { }
            return new List<PaymentClass>();
        }

        public PaymentClass getByID(string id)
        {
            try
            {
                PaymentClass paymentClass = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    paymentClass = new PaymentClassRepository(dbContext).getByID(id);
                }
                return paymentClass;
            }
            catch (Exception ex) { }
            return null;
        }

        public void delete(PaymentClass paymentClass)
        {
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                new PaymentClassRepository(dbContext).delete(paymentClass);
                dbContext.SaveChanges();
            }
        }
    }
}