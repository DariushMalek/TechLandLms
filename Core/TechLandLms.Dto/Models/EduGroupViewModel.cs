using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandLms.Dto.Models
{
    public class EduGroupViewModel
    {
        public string EduGroupTitle { get; set; }
        public int? MaxMemberCount { get; set; }
        public int OwnerId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
