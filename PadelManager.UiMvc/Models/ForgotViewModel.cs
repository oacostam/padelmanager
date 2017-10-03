using System.ComponentModel.DataAnnotations;

namespace PadelManager.UiMvc.Models
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}