using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Repositories
{
    public class UserRoleRepository : Repository<IdentityRole>
    {
        private RoleManager<IdentityRole> _roleManager = null;

        public UserRoleRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        private RoleManager<IdentityRole> RoleManager
        {
            get
            {
                if(_roleManager == null)
                {
                    _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this._dbContext));
                }

                return _roleManager;
            }
        }

        public override void create(IdentityRole objectToCreate)
        {
            try
            {
                var currentRole = RoleManager.FindById(objectToCreate.Id);
                if (currentRole == null)
                {
                    RoleManager.Create(objectToCreate);                    
                }                
            }
            catch (Exception ex) { }            
        }

        public override void delete(IdentityRole objectToDelete)
        {
            throw new NotImplementedException();
        }

        public override List<IdentityRole> getAll()
        {
            return RoleManager.Roles.ToList();
        }

        public override List<IdentityRole> getBy(Func<IdentityRole, bool> whereClausule)
        {
            return RoleManager.Roles.Where(whereClausule).ToList();
        }

        public override IdentityRole getByID(string id)
        {
            return RoleManager.Roles.FirstOrDefault(x => x.Id.Equals(id));
        }

        public override void update(IdentityRole objectToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}