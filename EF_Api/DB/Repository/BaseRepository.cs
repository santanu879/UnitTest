using EF_Api.DB.Interface;
using EF_Api.DB.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EF_Api.DB.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly bookStoresDBContext context;
        public BaseRepository(bookStoresDBContext bookStoreDBContext)
        {
            this.context = bookStoreDBContext;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
