using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamFarmacoConcominante : SystemId
    {

        private string nombre;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //private string nombreDci;
        //[Required(ErrorMessage = "requerido")]
        //[StringLength(250)]
        //public string NombreDci { get => nombreDci; set => SetProperty(ref nombreDci, value); }

        // Dosis, Frecuencia, Vía de Administración
        private string viaAdministracion;
        [StringLength(300)]
        public string ViaAdministracion { get => viaAdministracion; set => SetProperty(ref viaAdministracion, value); }

        // Fecha de Tratamiento. null
        private DateTime? fechaTratamiento;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTratamiento { get => fechaTratamiento; set => SetProperty(ref fechaTratamiento, value); }

        // Indicación. null
        private string indicacion;
        [StringLength(300)]
        public string Indicacion { get => indicacion; set => SetProperty(ref indicacion, value); }

    }
}
