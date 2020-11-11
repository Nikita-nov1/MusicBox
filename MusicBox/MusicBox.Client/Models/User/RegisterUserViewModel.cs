using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MusicBox.Models.User
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "Ваше имя на сайте")]
        public string UserName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DateBorn { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public HttpPostedFileBase Image { get; set; }
    }
}