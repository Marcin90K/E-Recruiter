using Microsoft.EntityFrameworkCore;
using RecruitingSystem.Data.Contexts;
using RecruitingSystem.Data.Entities;
using RecruitingSystem.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecruitingSystem.Data.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        protected AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T GetSingleById(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingleBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public bool IfExists(Guid id)
        {
            return _context.Set<T>().Where(c => c.Id == id).Any();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
