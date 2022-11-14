using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Identity
{
    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
#pragma warning disable CS8618 // Non-nullable property 'Email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Email { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Email' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        [Required]
#pragma warning disable CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Password { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Password' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        [Required]
        [Compare(nameof(Password))]
#pragma warning disable CS8618 // Non-nullable property 'ConfirmPassword' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string ConfirmPassword { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'ConfirmPassword' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        [Required]
#pragma warning disable CS8618 // Non-nullable property 'Token' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Token { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Token' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
