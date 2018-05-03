using CemeterySystem.DBModels;
using CemeterySystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Services
{
    public class FamilyMemberService
    {
        public List<FamilyMember> getAll()
        {
            try
            {
                List<FamilyMember> listFamilyMember = new List<FamilyMember>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listFamilyMember = new FamilyMemberRepository(db).getAll();
                }
                return listFamilyMember;
            }
            catch (Exception ex) { }
            return new List<FamilyMember>();
        }

        public List<FamilyMember> getBy(Func<FamilyMember, bool> whereClausule)
        {
            try
            {
                List<FamilyMember> listFamilyMember = new List<FamilyMember>();
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    listFamilyMember = new FamilyMemberRepository(db).getBy(whereClausule);
                }
                return listFamilyMember;
            }
            catch (Exception ex) { }
            return new List<FamilyMember>();
        }
    }
}