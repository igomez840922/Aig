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
        // Nombre del Paciente
        private string nombrePaciente;
        public string NombrePaciente { get => nombrePaciente; set => SetProperty(ref nombrePaciente, value); }

        // Iniciales del Paciente
        private string inicialesPaciente;
        public string InicialesPaciente { get => inicialesPaciente; set => SetProperty(ref inicialesPaciente, value); }

        // Sexo: Total=3. M, F, ND
        private enumSexo sexo;
        public enumSexo Sexo { get => sexo; set => SetProperty(ref sexo, value); }

        // Edad: int y string(No reportado)
        private int edad;
        public int Edad { get => edad; set => SetProperty(ref edad, value); }

        // Historia Clínica
        private string histClinica;
        public string HistClinica { get => histClinica; set => SetProperty(ref histClinica, value); }

        // Fecha de tratamiento inicial
        private DateTime? fechaTratInicial;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTratInicial { get => fechaTratInicial; set => SetProperty(ref fechaTratInicial, value); }

        // Fecha de tratamiento final
        private DateTime? fechaTratFinal;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTratFinal { get => fechaTratFinal; set => SetProperty(ref fechaTratFinal, value); }

        // Fecha de FT
        private DateTime? fechaFT;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaFT { get => fechaFT; set => SetProperty(ref fechaFT, value); }

        // Indicación
        private string indicacion;
        public string Indicacion { get => indicacion; set => SetProperty(ref indicacion, value); }

        // Dosis, Frecuencia, Vía de Administración
        private string viaAdministracion;
        public string ViaAdministracion { get => viaAdministracion; set => SetProperty(ref viaAdministracion, value); }

        // Concomitantes
        private string concomitantes;
        public string Concomitantes { get => concomitantes; set => SetProperty(ref concomitantes, value); }

    }
}
