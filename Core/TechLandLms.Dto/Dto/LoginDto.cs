using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.Secutirty;

namespace TechLandLms.Model.Dto
{
    public class AuthInfoModel: BaseAuthInfoDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ColumnInfo(IsDbColumn = false)]
        public string UserTitle => FirstName + " " + LastName;
    }

    public class SignInModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
