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
    }
}