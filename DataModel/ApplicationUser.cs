﻿using Microsoft.AspNetCore.Identity;
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
        [Description("User")]
        None = 0,
        [Description("Admin")]
        Admin = 1,
        [Description("PosUser")]
        Manager = 2,
    }

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){

        }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        [Required(ErrorMessage = "RequiredField")]
        public override string Email {
            get { return base.Email; }
            set { base.Email = value; }
        }

        public enumUserRoleType UserRoleType { get; set; } = enumUserRoleType.None;
        
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

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "RequiredField")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        [Required(ErrorMessage = "RequiredField")]
        [Compare(nameof(Password), ErrorMessage = "ConfirmationPasswordNotMatch")]
        public string PasswordConfirm { get; set; }

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
