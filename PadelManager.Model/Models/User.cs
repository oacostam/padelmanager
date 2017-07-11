#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PadelManager.Core.Common;

#endregion

namespace PadelManager.Core.Models
{
    public class User : AuditableEntity, IValidatableObject
    {

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}