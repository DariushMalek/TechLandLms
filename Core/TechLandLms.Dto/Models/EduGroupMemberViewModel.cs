using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandLms.Dto.Models
{
    public class EduGroupMemberViewModel
    {
        public bool? IsActive { get; set; }
        public int MemberId { get; set; }
        public int EduGroupId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
