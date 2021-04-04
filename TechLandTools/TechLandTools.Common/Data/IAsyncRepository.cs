using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TechLandTools.Common.Data
{
    public interface IAsyncRepository<T> 
        where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, bool includeAll = false);
        IQueryable<TResult> GetByCriteriaNoEntity<TResult>(Expression<Func<T, bool>> criteria);
        IQueryable<T> GetByCriteria(Expression<Func<T, bool>> criteria, bool includeAll = false);
        IQueryable<T> GetByCriteria(Expression<Func<T, bool>> criteria, params Expression<Func<T, object>>[] includePropertires);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);
        T Add(T entity);
        void UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<int> CountAsync(ISpecification<T> spec);
        IEnumerable<T> ListAll();
        IEnumerable<T> ListAll(params Expression<Func<T, object>>[] includePropertires);
        Task<T> GetSingleElement();
        Task<IEnumerable<TChild>> GetChildList<TChild>(int parentId)
            where TChild : BaseEntity;
        Task<IEnumerable<TResult>> ListAllAsync<TResult>();
        Task<IEnumerable<TResult>> ListAllAsync<TResult>(Expression<Func<T, bool>> criteria);
        bool AnyEntity(Expression<Func<T, bool>> criteria);
        void ExecuteSql(string sql);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
        IEnumerable<TD> GetEntityListByDapper<TD>(string sql,object param = null);
        IQueryable<T> GetByQuery(string sql);
        IQueryable<TEntity> GetByCriteria<TEntity>(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includePropertires)
            where TEntity : BaseEntity;
        IQueryable<TResult> GetByCriteria<TResult>(Expression<Func<TResult, bool>> criteria, object parameters);
        IQueryable<TResult> GetByCriteria<TBase, TResult>(Expression<Func<TBase, bool>> criteria);
        void Delete(T entity);
        string GetTableName();

        IDbContextTransaction BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        IDbContextTransaction CurrentTransaction();
    }
}
