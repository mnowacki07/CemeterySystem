using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class BurialPlaceBookerService
    {
        public BurialPlaceBooker createBookingForFamilyMember(ApplicationUser familyMemberUser, Guid burialPlaceID)
        {
            BurialPlaceBooker booker = null;
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    BurialPlaceBookerRepository repo = new BurialPlaceBookerRepository(db);
                    List<BurialPlaceBooker> bookers = repo.getBy(x => x.FamilyMemberID.HasValue && x.FamilyMemberID.Equals(familyMemberUser.FamilyMemberID));
                    booker = bookers.Count > 0 ? bookers[0] : new BurialPlaceBooker();
                    
                    booker.BurialPlaceID = burialPlaceID;
                    booker.FamilyMemberID = familyMemberUser.FamilyMemberID;      
                    
                    // update
                    if(bookers.Count > 0)
                    {
                        repo.update(booker);
                    }
                    // create new
                    else
                    {
                        booker.BurialPlaceBookerID = Guid.NewGuid();
                        repo.create(booker);
                    }

                    db.SaveChanges();
                }
            }
            catch(Exception ex) { }
            return booker;
        }

        public void cancelBooking(Guid familyMemberID)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    BurialPlaceBookerRepository repo = new BurialPlaceBookerRepository(db);

                    List<BurialPlaceBooker> bookers = repo.getBy(x => x.FamilyMemberID.HasValue && x.FamilyMemberID.Equals(familyMemberID));

                    foreach (var booker in bookers)
                    {
                        repo.delete(booker);
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex) { }
        }
    }
}