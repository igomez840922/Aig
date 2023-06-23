using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public enum enumUserRoleType
    {
        [Description("Usuario del Sistema")]
        SysUser = 0,
        [Description("Administrador")]
        Admin = 1,
        //[Description("Usuario del Sistema")]
        //SysUser = 2,
        [Description("Secretaria - Departamento de Auditorías")]
        SecDepAudit = 3,
        [Description("Secretaria - Sección de Licencias")]
        SecSecLic = 4,
        [Description("Jefe - Departamento de Auditorías")]
        JefDepAudit = 5,
        [Description("Jefe - Sección de Auditorías")]
        JefSecAudit = 6,
        [Description("Jefe - Sección de Inspecciones")]
        JefSecInspec = 7,
        [Description("Jefe - Sección de Licencias")]
        JefSecLic = 8,
        [Description("Evaluador - Inscripción de Materia Prima")]
        EvaInsMP = 9,
        [Description("Consultor de Correspondencias")]
        ConsultCo = 10,
        [Description("Farmacéutico - Inspector")]
        FarmaInspector = 11,
        [Description("Técnico - Inspector")]
        TecInspector = 12,
    }

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){

        }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        [Required(ErrorMessage = "requerido")]
        public override string Email {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public enumUserRoleType UserRoleType { get; set; } = enumUserRoleType.SysUser;
        
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string UserRoleTypeDesc
        {
            get
            {
                try
                {
                    return DataModel.Helper.Helper.GetDescription<enumUserRoleType>(UserRoleType);

                    //switch ((enumUserType)Usertype)
                    //{
                    //    case enumUserType.Admin: return "Administrator";
                    //    case enumUserType.Doctor: return "Doctor";
                    //    case enumUserType.PhysicianDPT: return "Physician DPT";
                    //    case enumUserType.PhysicianOTR: return "Physician OTR";
                    //    case enumUserType.None: return "Guess";
                    //    default: return "";
                    //}
                }
                catch { }
                return "";
            }
            set { }
        }

        //[StringLength(250)]
        //[Required(ErrorMessage = "campo requerido")]
        //public string Email { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //[Required(ErrorMessage = "requerido")]
        //public string Password { get; set; }

        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //[Required(ErrorMessage = "requerido")]
        //[Compare(nameof(Password), ErrorMessage = "no coincide")]
        //public string PasswordConfirm { get; set; }

        public long? UserProfileId { get; set; }
        public virtual UserProfileTB? UserProfile { get; set; }


        /// <summary>
        /// 
        /// </summary>

        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "correo no válido")]
        //[RegularExpression(@"^\d*$", ErrorMessage = "solo dígitos")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]



    }
}
