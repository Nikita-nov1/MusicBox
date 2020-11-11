using System.ComponentModel.DataAnnotations;

namespace MusicBox.Models.User
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }
    }
}