using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{

    public abstract class GenericRepository<T> : IGenericRepository<T>
          where T : Entity
    {
        protected DbContext Entities;
        protected readonly IDbSet<T> Dbset;

        protected GenericRepository(DbContext context)
        {
            Entities = context;
            Dbset = context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return Dbset;
        }

        public T GetById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = Dbset.Where(predicate);
            return query;
        }

        public virtual T Add(T entity)
        {
            Dbset.Add(entity);
            Save();
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            entity.IsDeleted = true;
            Entities.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void ForceDelete(int id)
        {
            var entity = GetById(id);
            Dbset.Remove(entity);
            Save();
        }

        public virtual void Edit(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}
