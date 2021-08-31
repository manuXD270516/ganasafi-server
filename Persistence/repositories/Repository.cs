using Application.interfaces;
using Application.parameters;
using Application.wrappers;
using Dapper.Contrib.Extensions;
using Domain;
using Persistence.options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Persistence.repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected IDbConnection DbConnection { get; private set; }
        private readonly DatabaseSettings _dbSettings;

        public Repository(DatabaseSettings dbSettings)
        {
            _dbSettings = dbSettings;
            DbConnection = new DbContext()
                .SetStrategy(_dbSettings.providerName)
                .GetDbContext(_dbSettings.connectionString);
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            DbConnection.Open();
            try
            {

                Type entityType = entity.GetType();
                if (entityType.IsSubclassOf(typeof(AuditableBaseEntity)))
                {
                    PropertyInfo stateProp = entityType.GetProperty("state");
                    stateProp.SetValue(entity, "A", null);

                    PropertyInfo registrationDateProp = entityType.GetProperty("registrationDate");
                    registrationDateProp.SetValue(entity, DateTime.UtcNow, null);

                    PropertyInfo modificationDateProp = entityType.GetProperty("modificationDate");
                    modificationDateProp.SetValue(entity, DateTime.UtcNow, null);

                    PropertyInfo registrationUserProp = entityType.GetProperty("registrationUser");
                    PropertyInfo modificationUserProp = entityType.GetProperty("modificationUser");
                    registrationUserProp.SetValue(entity, "root", null);
                    modificationUserProp.SetValue(entity, "root", null);

                    PropertyInfo tzLockProp = entityType.GetProperty("tzLock");
                    tzLockProp.SetValue(entity, 0, null);


                }

                var inserted = await DbConnection.InsertAsync(entity);

                return inserted;
            } finally { 
                DbConnection.Close(); 
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            DbConnection.Open();
            try
            {
                var entity = await DbConnection.GetAsync<TEntity>(id);

                if (entity == null) {
                    return false;
                }
                
                Type entityType = entity.GetType();
                if (entityType.IsSubclassOf(typeof(AuditableBaseEntity)))
                {
                    PropertyInfo stateProp = entityType.GetProperty("state");
                    stateProp.SetValue(entity, "I", null);

                    PropertyInfo modificationDateProp = entityType.GetProperty("modificationDate");
                    modificationDateProp.SetValue(entity, DateTime.UtcNow, null);

                    PropertyInfo modificationUserProp = entityType.GetProperty("modificationUser");
                    modificationUserProp.SetValue(entity, "root", null);

                    PropertyInfo tzLockProp = entityType.GetProperty("tzLock");
                    tzLockProp.SetValue(entity, 1, null); // modified in future
                }
                return await DbConnection.UpdateAsync(entity);
                //return await DbConnection.DeleteAsync(entity);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<IQueryable<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            RequestParameter pagination = null)
        {
            DbConnection.Open();
            try
            {
                var results = (await DbConnection.GetAllAsync<TEntity>())
                    .AsQueryable();

                if (pagination != null)
                {
                    int pageNumber = pagination.pageNumber, pageSize = pagination.pageSize;
                    results = results.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                }
                if (filter != null)
                {
                    results = results.Where(filter);
                }
                if (orderBy!= null)
                {
                    results = orderBy(results);
                }
                return results;
            }
            finally { DbConnection.Close(); }
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            DbConnection.Open();
            try
            {
                return await DbConnection.GetAsync<TEntity>(id);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            DbConnection.Open();
            try
            {
                Type entityType = entity.GetType();
                if (entityType.IsSubclassOf(typeof(AuditableBaseEntity))){

                    PropertyInfo modificationDateProp = entityType.GetProperty("modificationDate");
                    modificationDateProp.SetValue(entity, DateTime.UtcNow, null);

                    PropertyInfo modificationUserProp = entityType.GetProperty("modificationUser");
                    modificationUserProp.SetValue(entity, "root", null);

                }
                return await DbConnection.UpdateAsync(entity);
            }
            finally { DbConnection.Close(); }
        }
    }
}
