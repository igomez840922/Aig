using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "requerido")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "requerido")]
        public string Password { get; set; }
        [Required(ErrorMessage = "requerido")]
        [Compare(nameof(Password), ErrorMessage = "no coincide")]
        public string PasswordConfirm { get; set; }
    }
}
