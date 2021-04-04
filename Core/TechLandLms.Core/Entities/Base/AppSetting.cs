using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class AppSetting : BaseEntity
    {
        public bool LoginIsActive { get; set; }
    }
}
