using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PadelManager.Core.Common;

namespace PadelManager.Core.Models
{
    public class Court: AuditableEntity, IValidatableObject
    {
       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();

        public TimeSpan OpeningTime { get; set; } = TimeSpan.MinValue;

        public TimeSpan ClosingTime { get; set; } = TimeSpan.MinValue;
   

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("El nombre de la pista no puede estar vacío.", new []{nameof(Name)});
            }
            if (OpeningTime == TimeSpan.MinValue)
            {
                yield return new ValidationResult("El horario de apertura no puede estar vacío.", new[] { nameof(OpeningTime) });
            }
            if (ClosingTime == TimeSpan.MinValue)
            {
                yield return new ValidationResult("El horario de cierre no puede estar vacío.", new[] { nameof(ClosingTime) });
            }
            if (ClosingTime <= OpeningTime)
            {
                yield return new ValidationResult("El horario de cierre debe ser posterior al de apertura.", new[] { nameof(ClosingTime), nameof(ClosingTime) });
            }
            if (ClosingTime - OpeningTime < new TimeSpan(0, 1, 0))
            {
                yield return new ValidationResult("La pista debe abrir al menos una hora.", new[] { nameof(ClosingTime), nameof(ClosingTime) });
            }
        }
    }
}
