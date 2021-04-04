using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLandLms.Dto.Models
{
    public class RelatedProductViewModel
    {
        public string ProductTitle { get; set; }
        public decimal? Cost { get; set; }
        public DateTime? PublishDate { get; set; }
        public int CourseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
