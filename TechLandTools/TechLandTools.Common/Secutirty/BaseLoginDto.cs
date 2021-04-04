using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.DtoBase;

namespace TechLandTools.Common.Secutirty
{
    public class BaseAuthInfoDto : BaseDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        [ColumnInfo(IsDbColumn = false)]
        public string AccessToken { get; set; }
        [ColumnInfo(IsDbColumn = false)]
        public string RefreshToken { get; set; }
        public bool? IsAdmin { get; set; }
        [ColumnInfo(IsDbColumn = false)]
        public string UserRole { get; set; }
        [ColumnInfo(IsDbColumn = false)]
        public DateTime? ExpiresIn { get; set; }
    }
}
