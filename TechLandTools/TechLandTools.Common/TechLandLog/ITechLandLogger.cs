using System;
using System.Collections.Generic;
using System.Text;

namespace TechLandTools.Common.TechLandLog
{
   
    public interface ITechLandLogger<TLoggerEntity>
         where TLoggerEntity : LogEntityBase
    {
        void LogInfo(TLoggerEntity entity);
        void LogInsert(string entityName, string entityId = "", string description = "");
        void LogDelete(string entityName, string entityId = "", string description = "");
        void LogUpdate(string entityName, string entityId = "", string description = "");
        void LogError(string entityName, string entityId, string errorMessage, string Operation);
        void LogLogin(string userName);
        void LogInfo(string operation, string logType, string entityName, string entityId = null, string description = "");
        void LogLogout();
    }
}
