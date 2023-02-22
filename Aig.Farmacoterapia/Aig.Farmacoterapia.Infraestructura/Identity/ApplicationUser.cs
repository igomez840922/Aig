using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Extensions;
using Aig.Farmacoterapia.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Aig.Farmacoterapia.Infrastructure.Identity
{
    public class ApplicationUser: IdentityUser, IEntity
    {
        public ApplicationUser():base()
        {
            UserName= string.Empty; 
        }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordConfirm { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } = string.Empty;
        public string FullName{
            get { return string.Format("{0} {1}", FirstName, LastName); }
            set { }
        }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public bool IsActive { get; set; } = true;
        public RoleType Role { get; set; }

        [NotMapped]
        public string UserRoleDescription
        {
            get
            {
                try
                {
                    return Role.ToDescriptionString();
                }
                catch { }
                return string.Empty;
            }
            set { }
        }

        private ICollection<AigEstudioEvaluador> _estudioEvaluador;
        [JsonIgnore]
        public virtual ICollection<AigEstudioEvaluador> EstudioEvaluador => _estudioEvaluador ??= new HashSet<AigEstudioEvaluador>();
    }
}
