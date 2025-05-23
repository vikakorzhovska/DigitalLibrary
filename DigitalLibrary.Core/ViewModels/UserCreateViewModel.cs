using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Core.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Імʼя користувача обовʼязкове")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Email обовʼязковий")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Пароль обовʼязковий")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль має бути не менше 6 символів")]
        public string Password { get; set; } = null!;
    }
}
