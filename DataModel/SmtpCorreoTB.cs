using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class SmtpCorreoTB : SystemId
	{
		//nombre
		private string usuario;
		[StringLength(250)]
		[Required(ErrorMessage = "RequiredField")]
		public string Usuario { get => usuario; set => SetProperty(ref usuario, value); }

		//contraseña
		private string contrasena;
		[StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Contrasena { get => contrasena; set => SetProperty(ref contrasena, value); }

        //servidor smtp
        private string smtpServidor;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string SmtpServidor { get => smtpServidor; set => SetProperty(ref smtpServidor, value); }

        //puerto servidor smtp
        private int smtpPuerto;
        public int SmtpPuerto { get => smtpPuerto; set => SetProperty(ref smtpPuerto, value); }

        //cuenta de Correo
        private string correo;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }


    }
}
