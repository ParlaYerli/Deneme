using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Business.EntityFramework
{
    public class EfEntityRepositoryBase<T, TContext> : IEntityRepository<T>
        where T : class,new()
        where TContext : DbContext, new()
    {
        public void CreateUser(T entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                       ? context.Set<T>().ToList()
                       : context.Set<T>().Where(filter).ToList();
            }
        }

        public T GetUser(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(filter);
            }
        }

        public T Login(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(filter);
            }
        }

        public void UpdateUser(T entity)
        {
            using (var context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
