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
            if(User == null) yield return new ValidationResult("Usuario no válido");
            if (Court == null) yield return new ValidationResult("Pista no válida");
            if(ReservationDate < DateTime.Now) yield return new ValidationResult("La fecha de la reserva no puede ser anterior a la fecha de hoy.");
            if(Starts > Ends) yield return new ValidationResult("La hora de inicio no puede ser posterior a la hora de fin");
        }
    }
}