using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Ambient.Context.Interfaces;
using Context;
using Infrastructure.Interface;

namespace Infrastructure.Implementation
{

    public abstract class GenericRepository<T> : IGenericRepository<T>
          where T : Entity
    {
        protected readonly IAmbientDbContextLocator ContextLocator;


        protected GenericRepository(IAmbientDbContextLocator contextLocator)
        {
            ContextLocator = contextLocator;
        }

        public DbContext Context()
        {
            var context = ContextLocator.Get();
            return context;
        }

        public IDbSet<T> Set()
        {
            var context = Context();
            return context.Set<T>();
        }

        public virtual IQueryable<T> GetAllActive()
        {
            return Set().Where(x => x.IsDeleted == false);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Set();
        }

        public T GetById(int id)
        {
            return Set().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = Set().Where(predicate);
            return query;
        }

        public virtual T Add(T entity)
        {
            Set().Add(entity);
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            entity.IsDeleted = true;
            Context().Entry(entity).State = EntityState.Modified;
        }

        public void ForceDelete(int id)
        {
            var entity = GetById(id);
            Set().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Context().Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Context().SaveChanges();
        }

    }
}
