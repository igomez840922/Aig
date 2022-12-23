﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DatosPersona:SystemId
    {
        // Nombre
        private string nombre;
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Numero de Registro de Identidad
        private string numRegistro;
        public string NumRegistro { get => numRegistro; set => SetProperty(ref numRegistro, value); }

        //Regente de cedula ..... Al colocar el número de cédula debe validarse con el Web Service del Tribunal Electoral que se encuentra en el bus de integración de la AIG. Se debe alimentar de la solicitud de Licencia.
        private string cedula;
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }


        private string cargo;
        public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }


        //provincia
        private string provincia;
        public string Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //distrito
        private string distrito;
        public string Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        //distrito
        private string corregimiento;
        public string Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        //ubicacion
        private string ubicacion;
        public string Ubicacion { get => ubicacion; set => SetProperty(ref ubicacion, value); }

        //Solicitante Telefono Oficina
        private string telefonoOfic;
        public string TelefonoOfic { get => telefonoOfic; set => SetProperty(ref telefonoOfic, value); }

        //Solicitante Telefono Residencial
        private string telefonoResid;
        public string TelefonoResid { get => telefonoResid; set => SetProperty(ref telefonoResid, value); }

        //Solicitante Telefono Movil
        private string telefonoMovil;
        public string TelefonoMovil { get => telefonoMovil; set => SetProperty(ref telefonoMovil, value); }

        //correo electronico
        private string email;
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Email { get => email; set => SetProperty(ref email, value); }

        //El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022? Firma de Regente Farmacéutico
        private string firma;
        public string Firma { get => firma; set => SetProperty(ref firma, value); }

        //Profesion
        private string profesion;
        public string Profesion { get => profesion; set => SetProperty(ref profesion, value); }

        

    }
}
