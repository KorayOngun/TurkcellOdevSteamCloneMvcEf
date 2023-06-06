using SteamClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.IRepos
{
    public interface IRepo<T> where T : class, IEntity,new()
    {
        Task CreateAsync(T entity);
        void Create(T entity);
        Task DeleteAsync(T entity);
        void Delete(T entity);
        Task UpdateAsync(T entity);
        void Update(T entity);
        
        Task<ICollection<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> filter);
        Task<ICollection<T>> GetAllAsync();

        ICollection<T> GetAllWithPredicate(Expression<Func<T, bool>> filter);
        ICollection<T> GetAll();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);

    }
}
