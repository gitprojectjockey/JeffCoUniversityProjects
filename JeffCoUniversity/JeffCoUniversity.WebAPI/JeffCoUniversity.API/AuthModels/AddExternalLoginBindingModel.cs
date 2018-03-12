using System.ComponentModel.DataAnnotations;

namespace JeffCoUniversity.API.AuthModels
{
    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}