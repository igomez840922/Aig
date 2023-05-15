using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class ChangePswModel
    {
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "requerido")]
        public string Id { get; set; }

        //public string userName { get; set; } = null;
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        //[Required(ErrorMessage = "RequiredField")]
        //public string UserName
        //{
        //    get { return userName; }
        //    set { userName = value; }
        //}


        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "requerido")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "requerido")]
        [Compare(nameof(Password), ErrorMessage = "la contraseña no coincide")]
        public string PasswordConfirm { get; set; }


    }
}