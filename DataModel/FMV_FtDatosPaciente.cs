using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FtDatosPaciente : SystemId
    {
        private FMV_FtTB ft;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual FMV_FtTB Ft { get => ft; set => SetProperty(ref ft, value); }


        // Nombre del Paciente
        private string nombrePaciente;
        //[Required(ErrorMessage = "requerido")]
        [StringLength(300)]
        public string NombrePaciente { get => nombrePaciente; set => SetProperty(ref nombrePaciente, value); }

        // Iniciales del Paciente
        private string inicialesPaciente;
        [StringLength(250)]
        public string InicialesPaciente { get => inicialesPaciente; set => SetProperty(ref inicialesPaciente, value); }

        // Sexo: Total=3. M, F, ND
        private enumSexo sexo;
        public enumSexo Sexo { get => sexo; set => SetProperty(ref sexo, value); }

        // Edad: int y string(No reportado)
        private string edad;
        [StringLength(250)]
        public string Edad { get => edad; set => SetProperty(ref edad, value); }

        // Historia Clínica
        private string histClinica;
        [StringLength(500)]
        public string HistClinica { get => histClinica; set => SetProperty(ref histClinica, value); }

        // Fecha de tratamiento inicial
        private string fechaTratInicial;
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [StringLength(250)]
        public string FechaTratInicial { get => fechaTratInicial; set => SetProperty(ref fechaTratInicial, value); }

        // Fecha de tratamiento final
        private string fechaTratFinal;
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [StringLength(250)]
        public string FechaTratFinal { get => fechaTratFinal; set => SetProperty(ref fechaTratFinal, value); }

        // Fecha de FT
        private string fechaFT;
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [StringLength(250)]
        public string FechaFT { get => fechaFT; set => SetProperty(ref fechaFT, value); }

        // Indicación
        private string indicacion;
        [StringLength(500)]
        public string Indicacion { get => indicacion; set => SetProperty(ref indicacion, value); }

        // Dosis, Frecuencia, Vía de Administración
        private string viaAdministracion;
        [StringLength(300)]
        public string ViaAdministracion { get => viaAdministracion; set => SetProperty(ref viaAdministracion, value); }

        // Concomitantes
        private string concomitantes;
        public string Concomitantes { get => concomitantes; set => SetProperty(ref concomitantes, value); }

    }
}
