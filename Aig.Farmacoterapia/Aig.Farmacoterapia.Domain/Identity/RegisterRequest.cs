using Aig.Farmacoterapia.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Identity
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; } = "";
        public bool ActivateUser { get; set; } = true;
        public bool AutoConfirmEmail { get; set; } = true;
        public string ProfilePicture { get; set; } = "";
        public RoleType Role { get; set; }
    }
}
