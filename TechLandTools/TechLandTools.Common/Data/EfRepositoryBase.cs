using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechLandTools.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TechLandTools.Common.Helper;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TechLandTools.Common.Data
{
    public class EfRepositoryBase<T, TDBContext> : IAsyncRepository<T> 
        where T : BaseEntity
        where TDBContext : DbContext
    {
        protected readonly DbContext _dbContext;
        protected readonly IMapper _mapper;
        protected readonly DbSet<T> _dataset;
        public EfRepositoryBase(TDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dataset = _dbContext.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(int id, bool includeAll = false)
        {
            var query = _dataset.AsQueryable();
            if (includeAll)
            {
                var navigations = _dbContext.Model.FindEntityType(typeof(T))
                    .GetDerivedTypesInclusive()
                    .SelectMany(type => type.GetNavigations())
                    .Distinct();

                foreach (var property in navigations)
                    query = query.Include(property.Name);
            }
            return await query.SingleOrDefaultAsync(n => n.Id == id);
        }
        public IQueryable<T> AsNoTracking()
        {
            return _dataset.AsNoTracking();
        }
        public bool AnyEntity(Expression<Func<T, bool>> criteria)
        {
            return _dataset.Any(criteria);
        }
        public IQueryable<R> AsNoTracking<R>()
        {
            return _dataset.AsNoTracking().ProjectTo<R>(_mapper.ConfigurationProvider);
        }
        public IQueryable<R> OfType<R>()
        {
            return _dataset.OfType<R>();
        }
        public IQueryable<T> GetByCriteria(Expression<Func<T, bool>> criteria, bool includeAll = false)
        {
            var query = _dataset.AsQueryable();
            if (includeAll)
            {
                var navigations = _dbContext.Model.FindEntityType(typeof(T))
                    .GetDerivedTypesInclusive()
                    .SelectMany(type => type.GetNavigations())
                    .Distinct();

                foreach (var property in navigations)
                    query = query.Include(property.Name);
            }
            return query.Where(criteria);
        }
        public IQueryable<T> GetByCriteria(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includePropertires)
        {
            IQueryable<T> query = _dataset;
            foreach (var includeProperty in includePropertires)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(criteria);
        }

        public IQueryable<TResult> GetByCriteriaNoEntity<TResult>(Expression<Func<T, bool>> criteria)
        {
            return _dataset.Where(criteria).ProjectTo<TResult>(_mapper.ConfigurationProvider);
        }

        public IQueryable<TEntity> GetByCriteria<TEntity>(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includePropertires)
            where TEntity : BaseEntity

        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            foreach (var includeProperty in includePropertires)
            {
                query = query.Include(includeProperty);
            }
            return query.Where(criteria);
        }

        public IQueryable<TResult> GetByCriteria<TResult>(Expression<Func<TResult, bool>> criteria, object parameters)
        {
            return _dataset.ProjectTo<TResult>(_mapper.ConfigurationProvider, parameters).Where(criteria);
        }
        public IQueryable<TResult> GetByCriteria<TBase, TResult>(Expression<Func<TBase, bool>> criteria)
        {
            return _dataset.OfType<TBase>().Where(criteria).ProjectTo<TResult>(_mapper.ConfigurationProvider);
        }


        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dataset.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public IEnumerable<T> ListAll()
        {
            return _dataset.ToList();
        }
        public IEnumerable<T> ListAll(params Expression<Func<T, object>>[] includePropertires)
        {
            IQueryable<T> query = _dataset;
            foreach (var includeProperty in includePropertires)
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

        public async Task<IEnumerable<TResult>> ListAllAsync<TResult>(Expression<Func<T, bool>> criteria)
        {
            return await _dataset.Where(criteria).ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IEnumerable<TResult>> ListAllAsync<TResult>()
        {
            return await _dataset.ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync().ConfigureAwait(false);
        }
        public T Add(T entity)
        {
            try
            {
                _dataset.Add(entity);
                _dbContext.SaveChanges();

                return entity;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public void AddNoSaveChange(T entity)
        {
            _dataset.Add(entity);

        }
        public void UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void UpdateNoSaveChange(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

        }
        public async Task SaveChangeAcync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public async Task DeleteAsync(T entity)
        {
            try
            {
                _dataset.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public void Delete(T entity)
        {
            try
            {
                _dataset.Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _dataset.RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dataset.AsQueryable(), spec);
        }

        public async Task<T> GetSingleElement()
        {
            return await _dataset.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<TChild>> GetChildList<TChild>(int parentId)
            where TChild : BaseEntity
        {
            try
            {
                var childListTypeName = typeof(T).GetProperties().FirstOrDefault(n => n.PropertyType == typeof(IEnumerable<TChild>) || n.PropertyType == typeof(ICollection<TChild>))?.Name;
                var parent = await _dataset.Include(childListTypeName)
                    .SingleOrDefaultAsync(n => n.Id == parentId);
                var list = parent.GetType().GetProperties().FirstOrDefault(n => n.Name == childListTypeName)
                    ?.GetValue(parent);
                return (IEnumerable<TChild>)list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void ExecuteSql(string sql)
        {
            _dbContext.Database.ExecuteSqlRaw(sql);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
        {
            var query = _dbContext.Set<T>()
                .Include(_dbContext.GetIncludePaths(typeof(T)));
            if (predicate != null)
                query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public IEnumerable<TD> GetEntityListByDapper<TD>(string sql, object param = null)
        {
            IEnumerable<TD> result;
            result = _dbContext.Database.GetDbConnection().Query<TD>(sql, param).ToList();
            return result;
        }

        public IQueryable<T> GetByQuery(string sql)
        {
            return _dataset.FromSqlRaw(sql);
        }

        public string GetTableName()
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(T));
            var schema = entityType.GetSchema() ?? "dbo";
            var tableName = entityType.GetTableName();
            return schema + "." + tableName;
        }

        public IDbContextTransaction BeginTransaction()
        {
            if (_dbContext.Database.CurrentTransaction == null)
            {
                return _dbContext.Database.BeginTransaction();
            }
            else
            {
                return null;
            }
        }

        public IDbContextTransaction CurrentTransaction()
        {
            return _dbContext.Database.CurrentTransaction;
        }

        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }
    }
}
