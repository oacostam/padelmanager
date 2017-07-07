using System;
using System.ComponentModel.DataAnnotations;

namespace PadelManager.Core.Common
{
    public abstract class AuditableEntity : Entity, IAuditableEntity
    {
        protected AuditableEntity()
        {
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }

        [ScaffoldColumn(false)]
        [Required]
        public DateTime CreatedDate { get; set; }


        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [Required]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; }
    }
}