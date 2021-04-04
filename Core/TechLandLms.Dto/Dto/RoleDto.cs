using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common.Annotations;
using TechLandTools.Common.DtoBase;

namespace TechLandLms.Model.Dto
{
    public class RoleDto : BaseDto
    {
        [ColumnInfo(Title = "کد نقش", Width = 100)]
        public int Id { get; set; }
        [ColumnInfo(Title = "نام لاتین نقش")]
        public string RoleName { get; set; }
        [ColumnInfo(Title = "عنوان نقش")]
        public string RoleTitle { get; set; }
    }
}
