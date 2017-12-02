using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Context;

namespace Infrastructure.Interface
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> GetAllActive();
        IQueryable<T> GetAll();
        T GetById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Delete(int id);
        void ForceDelete(int id);
        void Edit(T entity);
        void Save();
        IDbSet<T> Set();
        DbContext Context();
    }
}