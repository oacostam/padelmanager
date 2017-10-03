using System.ComponentModel.DataAnnotations;

namespace PadelManager.UiMvc.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "El tamaño máximo es de 200 caracteres")]
        [Display(Name = "Dirección")]
        public string Address { get; set; }
    }
}
