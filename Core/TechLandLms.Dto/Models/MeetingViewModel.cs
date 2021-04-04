using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandLms.Dto.Models
{
    public class MeetingViewModel
    {
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public DateTime? MeetingDate { get; set; }
        public int? MeetingCapacity { get; set; }
        public int? MeetingTypeId { get; set; }
        public int? Duration { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
