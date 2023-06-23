using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.Models
{
    public class RegisterModel
    {
        //[Required]
        //public string UserName { get; set; }
        //[Required]
        //public string Password { get; set; }
        //[Required]
        //[Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        //public string PasswordConfirm { get; set; }


        //public string userName { get; set; } = null;
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        [Required(ErrorMessage = "campo requerido")]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "campo requerido")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "campo requerido")]
        [Compare(nameof(Password), ErrorMessage = "la contraseña no coincide")]
        public string PasswordConfirm { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string PhoneNumber { get; set; }

        public enumUserRoleType UserRoleType { get; set; } = enumUserRoleType.SysUser;

        [StringLength(250)]
        [Required(ErrorMessage = "campo requerido")]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string SecondName { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "campo requerido")]
        public string SureName { get; set; }

        [StringLength(250)]
        public string SecondSurName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1} {2} {3}", FirstName, SecondName, SureName, SecondSurName); }
            set { }
        }

        //public long? UserProfileId { get; set; }
        //public virtual UserProfileTB? UserProfile { get; set; }
    }
}
