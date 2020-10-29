using System;
using System.ComponentModel.DataAnnotations;

namespace MusicBox.Models.User
{
    public class GetUserViewModel
    {
        [Display(Name = "Логин")]
        public string UserName { get; set; }
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [Display(Name = "Имя")]
        public string LastName { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        public DateTime? DateBorn { get; set; }

        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }




    }
}