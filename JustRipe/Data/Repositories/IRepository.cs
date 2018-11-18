using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JustRipe.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        IEnumerable<T> GetAll();

        T GetById(int id);

        void Delete(T entity);

        void Update(T entity);

        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);

        void Dispose();
    }
}
