using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class EFEntityRepo<T, TContext> : IEntityRepository<T> where T : class, IEntity, new()
                                                               where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using (var _context = new TContext())
            {
                var added = _context.Entry(entity);
                added.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var _context = new TContext())
            {
                var deleted = _context.Entry(entity);
                deleted.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var _context = new TContext())
            {
                var updated = _context.Entry(entity);
                updated.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }



        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var _context = new TContext())
            {
                return _context.Set<T>().SingleOrDefault(filter);
            }
        }



        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var _context = new TContext())
            {
                return filter == null ? _context.Set<T>().ToList() : _context.Set<T>().Where(filter).ToList();
            }
        }

       
    }
}
