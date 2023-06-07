using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.EfRepo
{
    public abstract class EfRepository<T> : IRepo<T> where T : class,IEntity,new()
    {
        private readonly SteamCloneContext _context;

        public EfRepository(SteamCloneContext context)
        {
            _context = context;
        }

        public virtual void Create(T entity)
        {
               _context.Set<T>().Add(entity);
               _context.SaveChanges();
        }

        public virtual async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            var item = _context.Set<T>().Find(entity);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                _context.SaveChanges();
            }
        }

        public virtual async Task DeleteAsync(T entity)
        {
            var item = await _context.Set<T>().FindAsync(entity);
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public virtual  ICollection<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual ICollection<T> GetAllWithPredicate(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().AsNoTracking().Where(filter).ToList();
        }

        public virtual async Task<ICollection<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }

        public virtual T GetById(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
