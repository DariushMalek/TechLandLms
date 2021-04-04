
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Data;
using TechLandTools.Common.DtoBase;
using TechLandTools.Common.EntityBase;
using TechLandTools.Common.TechLandLog;

namespace TechLandTools.Common
{
    public class ServiceBase<T,TLogger> : IServiceBase<T,TLogger>
    where T : BaseEntity
          where TLogger : LogEntityBase
    {
        public ServiceBase(IAsyncRepository<T> entityRepository,
            IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<TLogger> techLandLogger)
        {
            EntityRepository = entityRepository;
            HttpContextAccessor = httpContextAccessor;
            Mapper = mapper;
            TechLandLogger = techLandLogger;
        }
        public ITechLandLogger<TLogger> TechLandLogger { get; }
        public IMapper Mapper { get; }
        public IAsyncRepository<T> EntityRepository { get; }

        public IHttpContextAccessor HttpContextAccessor { get; }
        public async Task<T> LoadEntity(int entityId)
        {
            return await EntityRepository.GetByIdAsync(entityId);
        }

        public async Task<TDto> LoadEntity<TDto>(int entityId)
            where TDto : BaseDto
        {
            var entity = await EntityRepository.GetByIdAsync(entityId, true);
            return Mapper.Map<TDto>(entity);
        }

    public virtual ValidationResult DoSubmit(T entity)
        {
            var tran = EntityRepository.BeginTransaction();
            var result = new ValidationResult();
            
            object entityId=0;
            try
            {
                result = SubmitValidation(entity);
                entityId = GetKeyValue(entity);
                if (result.State == ValidationResultState.IsValid)
                {
                    
                    BeforeSubmit(entity);
                    Submit(entity, entityId);
                    AfterSubmit(entity);
                    if (tran != null)
                    {
                        result.Entity = entity;
                        tran.Commit();
                    }
                }
                else
                {
                    TechLandLogger.LogError(entity.GetType().ToString(), entityId.ToString(), result.Exception?.Message, "Submit");
                }
            }catch(Exception e)
            {
                if (tran != null)
                {
                    tran.Rollback();
                }
                result = new ValidationResult(e.Message);
                TechLandLogger.LogError(entity.GetType().ToString(), entityId.ToString(), result.Exception?.Message, "Submit");
            }
            finally
            {
                
            }
            return result;
        }

        private void Submit(T entity, object entityId)
        {
            var jsonSetting = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            if (entityId.ToString() != "0")
            {
                EntityRepository.UpdateAsync(entity);
                var json = JsonConvert.SerializeObject(entity, jsonSetting);
                TechLandLogger.LogUpdate(entity.GetType().ToString(), entityId.ToString(), json);
            }
            else
            {
                var createDateProp = typeof(T).GetProperty("CreateDate");
                if (createDateProp != null)
                {
                    createDateProp.SetValue(entity, DateTime.Now);
                }
                var userIdProp = typeof(T).GetProperty("UserId");
                if (userIdProp != null && userIdProp.PropertyType==typeof(int) && HttpContextAccessor.HttpContext.User.Identity?.Name != null)
                {
                    var userId = int.Parse(HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(n => n.Type == "UserId").Value);
                    userIdProp.SetValue(entity, userId);
                }
                EntityRepository.Add(entity);
                var json = JsonConvert.SerializeObject(entity, jsonSetting);
                TechLandLogger.LogInsert(entity.GetType().ToString(), entityId.ToString(), json);
            }
        }

        private object GetKeyValue(T entity)
        {
            PropertyInfo[] properties = entity.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.CustomAttributes.Any(n => n.AttributeType == typeof(KeyAttribute))) // This property has a KeyAttribute
                {
                    // Do something, to read from the property:
                    object val = property.GetValue(entity);
                    return val;
                }
            }
            return null;
        }
        public virtual  ValidationResult SubmitValidation(T entity)
        {
            return new ValidationResult ();
        }

        public async Task DeleteEntity(int entityId)
        {
            var entity = await LoadEntity(entityId);
            await EntityRepository.DeleteAsync(entity);
            TechLandLogger.LogDelete(entity.GetType().ToString(), entityId.ToString());
        }

        public async Task DeleteEntityAsync(T entity)
        {
            await EntityRepository.DeleteAsync(entity);
            TechLandLogger.LogDelete(entity.GetType().ToString(), entity.Id.ToString());
        }

        public void DeleteEntity(T entity)
        {
            EntityRepository.Delete(entity);
            TechLandLogger.LogDelete(entity.GetType().ToString(), entity.Id.ToString());
        }

        public async Task<IEnumerable<TChild>> GetChildList<TChild>(int parentId)
            where TChild : BaseEntity
        {
            return await EntityRepository.GetChildList<TChild>(parentId);

        }

        public IEnumerable<T> GetEntityList()
        {
            return EntityRepository.ListAll();
        }
        public IEnumerable<T> GetEntityList(params Expression<Func<T, object>>[] includeProperties)
        {
            return EntityRepository.ListAll(includeProperties);
        }
        public async Task<IEnumerable<TResult>> GetEntityList<TResult>()
        {
            return await EntityRepository.ListAllAsync<TResult>();
        }

        public bool AnyEntity(string criteria = "")
        {
            if (!string.IsNullOrEmpty(criteria))
                criteria = $"where {criteria}";
            var tableName = EntityRepository.GetTableName();
            var query = $"select top 1 1 from {tableName} {criteria}";
            var result = EntityRepository.GetEntityListByDapper<T>(query).Any();
            return result;
        }

        public T GetEntity(int key)
        {
            return EntityRepository.GetByCriteria(n => n.Id == key, true).FirstOrDefault();
        }
        public TDto GetEntity<TDto>(string criteria)
            where TDto : BaseDto, new()
        {
            if (!string.IsNullOrEmpty(criteria))
                criteria = $"where {criteria}";
            var dbColumns = BaseDto.GetDbColumnsString<TDto>();
            var fromSection = $"from { EntityRepository.GetTableName()} {criteria}";
            var finalQuery = $"select {dbColumns} {fromSection} ";
            var entity = EntityRepository.GetEntityListByDapper<TDto>(finalQuery).FirstOrDefault();
            return entity;
        }

        public TableResponseModel<TDto> GetEntityListByState<TDto>(EntityState entityState)
            where TDto : BaseDto, new()
        {
            TDto instance = new TDto();
            var criteria = entityState.GetCriteriaAsSql<TDto>();
            var sorting= entityState.GetSortingAsSql<TDto>();
            var dbColumns = BaseDto.GetDbColumnsString<TDto>();
            var paging= entityState.GetPagingAsSql<TDto>();
            var tableName = instance.GetTableName() ?? EntityRepository.GetTableName();
            var fromSection = $"from {tableName} {criteria}";
            var queryForCount = $"select count(*) {fromSection}";
            var totalCount = GetCountByQuery(queryForCount);
            var finalQuery = $"select {dbColumns} {fromSection}  {sorting} {paging}";
            var items =  EntityRepository.GetEntityListByDapper<TDto>(finalQuery);
            var result = new TableResponseModel<TDto>();
            result.Items = items;
            result.Total = totalCount;
            return result;
            //paging implementation
        }

        private int GetCountByQuery(string sql)
        {
            return EntityRepository.GetEntityListByDapper<int>(sql).FirstOrDefault();
        }

        public virtual void AfterSubmit(T entity)
        {
            
        }

        public virtual void BeforeSubmit(T entity)
        {
            
        }

        public async Task DeleteEntitiesAsync(int[] ids)
        {
            var entities = EntityRepository.GetByCriteria(n=> ids.Contains(n.Id));
            await EntityRepository.DeleteRangeAsync(entities);
            TechLandLogger.LogDelete(typeof(T).ToString(), string.Join(",", ids.ToList()));
        }

        public void LogError(string operation, string userName, string entityName, string entityId, string description)
        {
            description = description.Replace("'", "''");
            var sql = $"exec dbo.LogError '{operation}', '{userName}', '{entityName}', '{entityId}', '{description}'";
            EntityRepository.ExecuteSql(sql);
        }
    }
}
