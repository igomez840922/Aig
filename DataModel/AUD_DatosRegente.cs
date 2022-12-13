using DataBindable;
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
    /// Datos del Regente
    /// </summary>
    public class AUD_DatosRegente : SystemId
    {
        //Regente - Nombre
        private string nombre;
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Numero de Registro de Identidad
        private string numRegistro;
        [StringLength(250)]
        public string NumRegistro { get => numRegistro; set => SetProperty(ref numRegistro, value); }

        //Regente de cedula ..... Al colocar el número de cédula debe validarse con el Web Service del Tribunal Electoral que se encuentra en el bus de integración de la AIG. Se debe alimentar de la solicitud de Licencia.
        private string cedula;
        [StringLength(250)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }

        //Regente de Cargo
        private string cargo;
        [StringLength(250)]
        public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }

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
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Email { get => email; set => SetProperty(ref email, value); }

        //El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022? Firma de Regente Farmacéutico
        private string firma;
        public string Firma { get => firma; set => SetProperty(ref firma, value); }


        //Horario Regencia
        private string horarioRegencia;
        public string HorarioRegencia { get => horarioRegencia; set => SetProperty(ref horarioRegencia, value); }

        //Labora en otra empresa:: 
        private enumAUD_TipoSeleccion laboraOtraEmpresa;
        public enumAUD_TipoSeleccion LaboraOtraEmpresa { get => laboraOtraEmpresa; set => SetProperty(ref laboraOtraEmpresa, value); }
        private string laboraOtraEmpresaDesc;
        public string LaboraOtraEmpresaDesc { get => laboraOtraEmpresaDesc; set => SetProperty(ref laboraOtraEmpresaDesc, value); }

        private string laboraOtraEmpresaHora;
        public string LaboraOtraEmpresaHora { get => laboraOtraEmpresaHora; set => SetProperty(ref laboraOtraEmpresaHora, value); }


        //El regente está presente al momento de la inspección
        private enumAUD_TipoSeleccion presenteEnInspeccion;
        public enumAUD_TipoSeleccion PresenteEnInspeccion { get => presenteEnInspeccion; set => SetProperty(ref presenteEnInspeccion, value); }

        private string observacion;
        public string Observacion { get => observacion; set => SetProperty(ref observacion, value); }

        //Pais Residencia
        private string paisResidencia;
        public string PaisResidencia { get => paisResidencia; set => SetProperty(ref paisResidencia, value); }

        //Otras Funciones
        private string otrasFunciones;
        public string OtrasFunciones { get => otrasFunciones; set => SetProperty(ref otrasFunciones, value); }

        private enumAUD_TipoSeleccion presenteEnLocal;
        public enumAUD_TipoSeleccion PresenteEnLocal { get => presenteEnLocal; set => SetProperty(ref presenteEnLocal, value); }

    }

}
