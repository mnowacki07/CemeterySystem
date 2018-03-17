using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CemeterySystem.Repositories
{
    public abstract class Repository<T>
    {
        protected ApplicationDbContext _dbContext = null;

        public Repository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public abstract List<T> getAll();
        public abstract List<T> getBy(Func<T, bool> whereClausule);
        public abstract T getByID(string id);        
        public abstract void create(T objectToCreate);
        public abstract void update(T objectToUpdate);
        public abstract void delete(T objectToDelete);
    }
}