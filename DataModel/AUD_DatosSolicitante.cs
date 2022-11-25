﻿using DataBindable;
using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos del Solicitante
    /// </summary>
    public class AUD_DatosSolicitante: SystemId
    {
        //Solicitante - nombre
        private string nombre;
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Solicitante - cedula
        private string cedula;
        [StringLength(250)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }

        //Solicitante - Nacionalidad
        private string nacionalidad;
        [StringLength(250)]
        public string Nacionalidad { get => nacionalidad; set => SetProperty(ref nacionalidad, value); }

        //Solicitante Telefono Oficina
        private string telefonoOfic;
        [StringLength(250)]
        public string TelefonoOfic { get => telefonoOfic; set => SetProperty(ref telefonoOfic, value); }

        //Solicitante Telefono Residencial
        private string telefonoResid;
        [StringLength(250)]
        public string TelefonoResid { get => telefonoResid; set => SetProperty(ref telefonoResid, value); }

        //Solicitante Telefono Movil
        private string telefonoMovil;
        [StringLength(250)]
        public string TelefonoMovil { get => telefonoMovil; set => SetProperty(ref telefonoMovil, value); }

        //correo electronico
        private string email;
        [StringLength(250)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Email { get => email; set => SetProperty(ref email, value); }

        //Solicitante Profesion
        private string profesion;
        [StringLength(250)]
        public string Profesion { get => profesion; set => SetProperty(ref profesion, value); }

        //Solicitante Profesion
        private string direccion;
        public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

        //Pais Residencia
        private string paisResidencia;
        public string PaisResidencia { get => paisResidencia; set => SetProperty(ref paisResidencia, value); }

        //Provincia
        private string provincia;
        public string Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //Distrito
        private string distrito;
        public string Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        //Corregimiento
        private string corregimiento;
        public string Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        //tipo de solicitante
        private enumAUD_TipoSolicitante tipo;
        public enumAUD_TipoSolicitante Tipo { get => tipo; set => SetProperty(ref tipo, value); }


    }
}
