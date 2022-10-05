using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class UserProfileTB : SystemId
    {
        public UserProfileTB()
        {
        }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string StatusDesc
        {
            get
            {
                try
                {
                    if (Disabled)
                    {
                        return "Disabled";
                    }
                }
                catch { }
                return "Enabled";
            }
            set { }
        }

        /// <summary>
        /// /Common Data
        /// </summary>


        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string FirstName { get; set; }

        [StringLength(250)]
        public string SecondName { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string SureName { get; set; }

        [StringLength(250)]
        public string SecondSurName { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1} {2} {3}", FirstName, SecondName, SureName, SecondSurName); }
            set { }
        }

        [StringLength(250)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string Languanje { get; set; } = "en-US";

        string logoBase64;
        public string LogoBase64 { get => logoBase64; set => SetProperty(ref logoBase64, value); }

        bool acceptTerms;
        public bool AcceptTerms { get => acceptTerms; set => SetProperty(ref acceptTerms, value); }

        private ApplicationUser appUser;
        [JsonIgnore]
        public virtual ApplicationUser AppUser { get => appUser; set => SetProperty(ref appUser, value); }

        

    }
}
