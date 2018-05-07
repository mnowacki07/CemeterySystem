using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class BookedServicesService
    {
        public List<BookedService> getByFamilyMemberID(Guid familyMemberID)
        {
            try
            {
                List<BookedService> listService = new List<BookedService>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listService = new BookedServicesRepository(db).getBy(x => x.FamilyMemberID.Equals(familyMemberID));
                }
                return listService;
            }
            catch(Exception ex) { }
            return new List<BookedService>();
        }

        public BookedService createForFamilyMember(Guid serviceID, Guid familyMemberID, Guid deadPersonID)
        {
            try
            {
                BookedService bookedService = null;

                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    Service service = new ServicesRepository(db).getByID(serviceID.ToString());
                    DeadPerson deadPerson = new DeadPersonRepository(db).getByID(deadPersonID.ToString());

                    bookedService = new BookedService
                    {
                        BookedServiceID = Guid.NewGuid(),
                        Name = service.Name,
                        Description = service.Description,
                        FamilyMemberID = familyMemberID,
                        PriceGross = service.PriceGross,
                        BurialPlaceID = deadPerson.BurialPlaceID,
                        IsFinished = false,
                        IsPaid = false,
                        CreationDateTime = DateTime.Now
                    };

                    new BookedServicesRepository(db).create(bookedService);
                    db.SaveChanges();
                }

                return bookedService;
            }
            catch (Exception ex) { }
            return null;
        }        

        public void pay(Guid bookedServiceID)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    BookedService bookedService = new BookedService()
                    {
                        BookedServiceID = bookedServiceID,
                        IsPaid = true
                    };

                    new BookedServicesRepository(db).pay(bookedService);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public void update(BookedService service)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    new BookedServicesRepository(db).update(service);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }

        public void delete(Guid bookedServiceID)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            BookedServicesRepository repo = new BookedServicesRepository(db);

                            BookedService bookedService = repo.getByID(bookedServiceID.ToString());

                            if (bookedService != null && !bookedService.IsPaid && !bookedService.IsFinished)
                            {
                                repo.delete(bookedService);
                                db.SaveChanges();
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
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
    }
}