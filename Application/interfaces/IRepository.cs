using Application.helpers;
using Application.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> FindAllAsync(
            Dictionary<string, int> additionalProps,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            RequestParameter pagination = null
        );
        Task<TEntity> FindByIdAsync(long id);
        Task<TEntity> FindFirstOrDefault(Expression<Func<TEntity, bool>> filter = null);
        Task<int> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(long id);

        
    }
}
