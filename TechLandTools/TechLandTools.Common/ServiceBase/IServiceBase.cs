using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Data;
using TechLandTools.Common.DtoBase;
using TechLandTools.Common.EntityBase;
using TechLandTools.Common.TechLandLog;

namespace TechLandTools.Common
{
    public interface IServiceBase<T,TLogger>
    where T : BaseEntity
        where TLogger : LogEntityBase
    {
        ITechLandLogger<TLogger> TechLandLogger { get; }
        IAsyncRepository<T> EntityRepository { get; }
        IHttpContextAccessor HttpContextAccessor { get; }
        Task<T> LoadEntity(int entityId);
        Task<TDto> LoadEntity<TDto>(int entityId)
            where TDto : BaseDto;
        ValidationResult DoSubmit(T entity);
        Task DeleteEntity(int entityId);
        Task DeleteEntityAsync(T entity);
        Task<IEnumerable<TChild>> GetChildList<TChild>(int parentId)
            where TChild : BaseEntity;
        IEnumerable<T> GetEntityList();
        IEnumerable<T> GetEntityList(params Expression<Func<T, object>>[] includePropertires);
        Task<IEnumerable<TResult>> GetEntityList<TResult>();
        ValidationResult SubmitValidation(T entity);
        T GetEntity(int key);
        void DeleteEntity(T entity);
        Task DeleteEntitiesAsync(int[] ids);
        TableResponseModel<TDto> GetEntityListByState<TDto>(EntityState entityState)
            where TDto : BaseDto, new();
        TDto GetEntity<TDto>(string criteria)
              where TDto : BaseDto, new();

        bool AnyEntity(string criteria = "");
        void AfterSubmit(T entity);
        void BeforeSubmit(T entity);
        void LogError(string operation, string userName, string entityName, string entityId, string description);
    }
}
