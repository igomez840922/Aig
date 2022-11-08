using DataBindable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos del Regente
    /// </summary>
    public class AUD_DatosRegente : SystemId
    {
        //Regente - Nombre
        private string nombre;
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Numero de Registro de Identidad
        private string numregistroIdoneidad;
        [StringLength(250)]
        public string NumregistroIdoneidad { get => numregistroIdoneidad; set => SetProperty(ref numregistroIdoneidad, value); }

        //Regente de cedula ..... Al colocar el número de cédula debe validarse con el Web Service del Tribunal Electoral que se encuentra en el bus de integración de la AIG. Se debe alimentar de la solicitud de Licencia.
        private string cedula;
        [StringLength(250)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }
               
        //provincia
        private string provincia;
        [StringLength(250)]
        public string Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //distrito
        private string distrito;
        [StringLength(250)]
        public string Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        //distrito
        private string corregimiento;
        [StringLength(250)]
        public string Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }
                
        //ubicacion
        private string ubicacion;
        [StringLength(500)]
        public string Ubicacion { get => ubicacion; set => SetProperty(ref ubicacion, value); }

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
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        public string Email { get => email; set => SetProperty(ref email, value); }

        //El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022? Firma de Regente Farmacéutico
        private string firma;
        public string Firma { get => firma; set => SetProperty(ref firma, value); }
    }
}
