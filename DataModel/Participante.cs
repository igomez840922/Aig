﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Participante : SystemId
    {
        //Inspector 1 Nombre
        private string nombreCompleto;
        [Required(ErrorMessage = "RequiredField")]
        [StringLength(250)]
        public string NombreCompleto { get => nombreCompleto; set => SetProperty(ref nombreCompleto, value); }

        //cedula 1 registro
        private string cedulaIdentificacion;
        [StringLength(250)]
        public string CedulaIdentificacion { get => cedulaIdentificacion; set => SetProperty(ref cedulaIdentificacion, value); }

        //Inspector 1 registro
        private string registroNumero;
        [StringLength(250)]
        public string RegistroNumero { get => registroNumero; set => SetProperty(ref registroNumero, value); }

        //Inspector 1 cargo
        private string cargo;
        [StringLength(250)]
        public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }

        //Inspector 1 firma
        private string firma;
        public string Firma { get => firma; set => SetProperty(ref firma, value); }

       
    }
}