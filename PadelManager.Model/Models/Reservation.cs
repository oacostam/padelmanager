using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PadelManager.Core.Common;

namespace PadelManager.Core.Models
{
    public class Reservation: AuditableEntity, IValidatableObject
    {

        [Required]
        public User User { get; set; }

        [Required]
        public Court Court { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [Required]
        public TimeSpan Starts { get; set; }

        [Required]
        public TimeSpan Ends { get; set; }
        
        public decimal? PayedAmmount { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}