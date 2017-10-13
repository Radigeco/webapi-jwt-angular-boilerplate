﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Infrastructure.Interface;

namespace Infrastructure.Implementation
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

        public virtual IQueryable<T> GetAllActive()
        {
            return Dbset.Where(x => x.IsDeleted == false);
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
            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            entity.IsDeleted = true;
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public void ForceDelete(int id)
        {
            var entity = GetById(id);
            Dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Entities.SaveChanges();
        }
    }
}
