using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandLms.Core.Entities;
using TechLandLms.Model.Dto;
using TechLandLms.Services.Interfaces;
using TechLandTools.Common;
using TechLandTools.Common.Data;
using TechLandTools.Common.TechLandLog;

namespace TechLandLms.Services
{
    public class RoleFeatureService : ServiceBase<RoleFeature, LogInfo>, IRoleFeatureService
    {
        public RoleFeatureService(IAsyncRepository<RoleFeature> entityRepository, IHttpContextAccessor httpContextAccessor, IMapper mapper, ITechLandLogger<LogInfo> techLandLogger) : base(entityRepository, httpContextAccessor, mapper, techLandLogger)
        {

        }

        public IEnumerable<RoleFeatureNode> GetFeatureListWithRoleStatus(int roleId)
        {
            var features = EntityRepository.GetByCriteria<Feature>(n => true, f => f.ParentEntity, f => f.SubFeatureList, r => r.RoleFeatureList).ToList().Where(n => n.ParentFeatureId == null);
            var roleFeatures = EntityRepository.GetByCriteria<RoleFeature>(n => n.RoleId == roleId).ToList();

            //var result = EntityRepository.GetEntityListByDapper<RoleFeatureDto>($"select * from dbo.GetRoleFeatures({roleId})").ToList();
            IList<RoleFeatureNode> result = new List<RoleFeatureNode>();
            CreateFeatureList(features, roleFeatures,ref result);
            return result;
        }

        private void CreateFeatureList(IEnumerable<Feature> entities,IEnumerable<RoleFeature> roleFeatures,ref IList<RoleFeatureNode> result)
        {
            if (!entities.Any())
                return;
            result = new List<RoleFeatureNode>();
            foreach (var entity in entities)
            {
                var roleFeature = roleFeatures.FirstOrDefault(n => n.FeatureId == entity.Id);
                var newEntity = new RoleFeatureNode
                {
                    FeatureId = entity.Id,
                    FeatureName = entity.FeatureName,
                    FeatureTitle = entity.Title,
                    ParentFeatureId = entity.ParentFeatureId
                };
                if (roleFeature != null)
                {
                    newEntity.CanDelete = roleFeature.CanDelete;
                    newEntity.CanExecute = roleFeature.CanExecute;
                    newEntity.CanInsert = roleFeature.CanInsert;
                    newEntity.CanRead = roleFeature.CanRead; 
                    newEntity.CanUpdate = roleFeature.CanUpdate;
                    newEntity.RoleId = roleFeature.RoleId;

                }
                result.Add(newEntity);
                IList<RoleFeatureNode> subResult = new List<RoleFeatureNode>();
                CreateFeatureList(entity.SubFeatureList, roleFeatures, ref subResult);
                newEntity.SubFeatures = subResult;
            }
        }
        
    }
}
