using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juan.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(40)]
        public string Surname { get; set; }
        [Required,EmailAddress,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required,MinLength(8)]
        public string Password { get; set; }
        [Required, MinLength(8),DataType(DataType.Password),Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

    }
}
