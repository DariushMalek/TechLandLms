using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechLandTools.Common;

namespace TechLandLms.Core.Entities
{
    public class Constant : BaseEntity
    {
        public string ConstantName { get; set; }
        public string ConstantTitle { get; set; }
        public string ConstantType { get; set; }
        public ICollection<Course> CourseList { get; set; }
        public ICollection<Meeting> MeetingList { get; set; }
    }
}
