using System.ComponentModel.DataAnnotations;

namespace SaborExpress.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Provide your name")]
        [Display(Name ="User")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Provide your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
