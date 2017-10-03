using System.ComponentModel.DataAnnotations;

namespace PadelManager.UiMvc.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Dirección de correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El tamaño máximo es de 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres de largo.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
        
    }
}