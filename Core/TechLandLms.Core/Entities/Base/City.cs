using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class City: BaseEntity
    {
        public string CityName { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province ProvinceEntity { get; set; }
        public ICollection<AppUser> AppUserList { get; set; }
    }
}
