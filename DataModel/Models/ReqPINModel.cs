using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class ReqPINModel
    {

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "requerido")]
        public string Email { get; set; }


    }
}