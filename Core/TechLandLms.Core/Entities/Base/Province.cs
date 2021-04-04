using System;
using System.Collections.Generic;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Province: BaseEntity
    {
        public string ProvinceName { get; set; }
        public ICollection<City> CityList { get; set; }
    }
}
