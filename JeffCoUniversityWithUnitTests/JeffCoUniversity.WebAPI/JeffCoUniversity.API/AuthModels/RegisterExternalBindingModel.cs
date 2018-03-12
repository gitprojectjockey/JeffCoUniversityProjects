using System.ComponentModel.DataAnnotations;

namespace JeffCoUniversity.API.AuthModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}