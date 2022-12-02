using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TipoInstitucionTB : SystemId
    {
        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }


        //antigua BD
        private int iddb;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int Iddb { get => iddb; set => SetProperty(ref iddb, value); }


        private List<InstitucionDestinoTB> lInstituciones;
        public virtual List<InstitucionDestinoTB> LInstituciones { get => lInstituciones; set => SetProperty(ref lInstituciones, value); }

        private List<FMV_EsaviTB> lEsavi;
        public virtual List<FMV_EsaviTB> LEsavi { get => lEsavi; set => SetProperty(ref lEsavi, value); }

        private List<FMV_FfTB> lFf;
        public virtual List<FMV_FfTB> LFf { get => lFf; set => SetProperty(ref lFf, value); }

    }
}
