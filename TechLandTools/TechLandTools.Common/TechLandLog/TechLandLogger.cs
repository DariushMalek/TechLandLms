using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Data;
using TechLandTools.Common.TechLandLog;

namespace TechLandTools.Common.TechLandLog
{
    public class TechLandLogger<TLoggerEntity> : ITechLandLogger<TLoggerEntity>
          where TLoggerEntity : LogEntityBase, new()
    {
        public IMapper Mapper { get; }
        public IAsyncRepository<TLoggerEntity> EntityRepository { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public TechLandLogger(IAsyncRepository<TLoggerEntity> entityRepository,
            IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            EntityRepository = entityRepository;
            HttpContextAccessor = httpContextAccessor;
            Mapper = mapper;
        }

        public void LogInfo(TLoggerEntity entity)
        {
            EntityRepository.Add(entity);
        }

        public void LogInfo(string operation,string logType, string entityName, string entityId = null, string description = "")
        {
            var entity = new TLoggerEntity()
            {
                Description = description,
                EntityId = entityId,
                EntityName = entityName,
                EventDate = DateTime.Now,
                LogType = operation,
                Operation = logType,
                UserName = HttpContextAccessor.HttpContext.User.Identity.Name
            };
            LogInfo(entity);
        }

        public void LogInsert(string entityName, string entityId = null, string description= "")
        {
            var entity = new TLoggerEntity()
            {
                Description = description,
                EntityId = entityId,
                EntityName = entityName,
                EventDate = DateTime.Now,
                LogType = "Op",
                Operation = "Insert",
                UserName = HttpContextAccessor.HttpContext.User.Identity.Name
            };
            EntityRepository.Add(entity);
        }

        public void LogDelete(string entityName, string entityId = null, string description = "")
        {
            var entity = new TLoggerEntity()
            {
                Description = description,
                EntityId = entityId,
                EntityName = entityName,
                EventDate = DateTime.Now,
                LogType = "Op",
                Operation = "Delete",
                UserName = HttpContextAccessor.HttpContext.User.Identity.Name
            };
            EntityRepository.Add(entity);
        }

        public void LogUpdate(string entityName, string entityId = null, string description = "")
        {
            var entity = new TLoggerEntity()
            {
                Description = description,
                EntityId = entityId,
                EntityName = entityName,
                EventDate = DateTime.Now,
                LogType = "Op",
                Operation = "Update",
                UserName = HttpContextAccessor.HttpContext.User.Identity.Name
            };
            EntityRepository.Add(entity);
        }

        public void LogError(string entityName, string entityId, string errorMessage, string Operation)
        {
            var entity = new TLoggerEntity()
            {
                Description = errorMessage,
                EntityId = entityId,
                EntityName = entityName,
                EventDate = DateTime.Now,
                LogType = "Error",
                Operation = Operation,
                UserName = HttpContextAccessor.HttpContext.User.Identity.Name
            };
            EntityRepository.Add(entity);
        }

        public void LogLogin(string userName)
        {
            var entity = new TLoggerEntity()
            {
                Description = "",
                EntityId = null,
                EntityName = "",
                EventDate = DateTime.Now,
                LogType = "Login",
                Operation = "Login",
                UserName = userName
            };
            EntityRepository.Add(entity);
        }

        public void LogLogout()
        {
            var entity = new TLoggerEntity()
            {
                Description = "",
                EntityId = null,
                EntityName = "",
                EventDate = DateTime.Now,
                LogType = "Logout",
                Operation = "Logout",
                UserName = HttpContextAccessor.HttpContext.User.Identity.Name
            };
            EntityRepository.Add(entity);
        }
    }
}
