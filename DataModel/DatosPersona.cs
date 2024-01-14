using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DatosPersona:SystemId
    {
        public DatosPersona()
        {
            FirmaData = Array.Empty<byte>();
        }
        // Nombre
        private string nombre;
        //[Required(ErrorMessage = "requerido")]
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

        //Area Evaluada
        private string areaEvaluada;
        public string AreaEvaluada { get => areaEvaluada; set => SetProperty(ref areaEvaluada, value); }
                
        //dirección del Area Administrativa
        private string dirAreaAdministrativa;
        public string DirAreaAdministrativa { get => dirAreaAdministrativa; set => SetProperty(ref dirAreaAdministrativa, value); }
                
        //Horario Regencia
        private string horario;
        public string Horario { get => horario; set => SetProperty(ref horario, value); }

        //Labora en otra empresa:: 
        private enumAUD_TipoSeleccion laboraOtraEmpresa;
        public enumAUD_TipoSeleccion LaboraOtraEmpresa { get => laboraOtraEmpresa; set => SetProperty(ref laboraOtraEmpresa, value); }
        private string laboraOtraEmpresaDesc;
        public string LaboraOtraEmpresaDesc { get => laboraOtraEmpresaDesc; set => SetProperty(ref laboraOtraEmpresaDesc, value); }

        private string laboraOtraEmpresaHora;
        public string LaboraOtraEmpresaHora { get => laboraOtraEmpresaHora; set => SetProperty(ref laboraOtraEmpresaHora, value); }

        private enumAUD_TipoSeleccion presenteEnLocal;
        public enumAUD_TipoSeleccion PresenteEnLocal { get => presenteEnLocal; set => SetProperty(ref presenteEnLocal, value); }

        //El regente está presente al momento de la inspección
        private enumAUD_TipoSeleccion presenteEnInspeccion;
        public enumAUD_TipoSeleccion PresenteEnInspeccion { get => presenteEnInspeccion; set => SetProperty(ref presenteEnInspeccion, value); }

        private string observacion;
        public string Observacion { get => observacion; set => SetProperty(ref observacion, value); }

        //Pais Residencia
        private string paisResidencia;
        public string PaisResidencia { get => paisResidencia; set => SetProperty(ref paisResidencia, value); }


        private enumAUD_TipoSeleccion realizaOtraFuncion;
        public enumAUD_TipoSeleccion RealizaOtraFuncion { get => realizaOtraFuncion; set => SetProperty(ref realizaOtraFuncion, value); }

        //Otras Funciones
        private string otrasFunciones;
        public string OtrasFunciones { get => otrasFunciones; set => SetProperty(ref otrasFunciones, value); }

        private byte[] firmaData;
        public byte[] FirmaData { get { return firmaData; } set { firmaData = value; if (firmaData?.Length > 0) { Firma = Encoding.UTF8.GetString(FirmaData); }; } }


    }
}
