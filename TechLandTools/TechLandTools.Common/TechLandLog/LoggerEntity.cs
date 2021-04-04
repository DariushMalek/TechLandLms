using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TechLandTools.Common.TechLandLog
{
    public class LogEntityBase : BaseEntity
    {
        [NotMapped]
        public override int Id { get; set; }
        [Key]
        public long LogId { get; set; }
        public string Operation { get; set; }
        public string EntityName { get; set; }
        public string LogType { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? EventDate { get; set; }
        public string Description { get; set; }
        public string EntityId { get; set; }
    }
}
