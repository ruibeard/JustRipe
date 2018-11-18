using System;
using System.Collections.Generic;
using SQLite.Net;
using System.Linq;
using System.Linq.Expressions;

namespace JustRipe.Data.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        private readonly SQLiteConnection connection;

        public Repository()
        {
            connection = SQLiteDatabase.Open();
        }

        public void Add(T entity)
        {
            connection.Insert(entity);
        }

        public void Delete(T entity)
        {
            using (var cnn = SQLiteDatabase.Open())
            {
                cnn.Delete(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return connection.Table<T>();
        }

        public T GetById(int id)
        {
            using (var cnn = SQLiteDatabase.Open())
            {
                return cnn.Find<T>(id);
            }
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            using (var cnn = SQLiteDatabase.Open())
            {
                return cnn.Table<T>().Where(predicate).AsQueryable();
            }
        }

        public void Update(T entity)
        {
            using (var cnn = SQLiteDatabase.Open())
            {
                cnn.Update(entity);
            }
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
