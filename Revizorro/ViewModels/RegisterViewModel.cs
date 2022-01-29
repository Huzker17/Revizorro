using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Revizorro.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Недопустимая длина")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Пароль должен быть больше 6 символов")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "PasswordConfirmation")]
        public string ConfirmPassword { get; set; }
    }
}
