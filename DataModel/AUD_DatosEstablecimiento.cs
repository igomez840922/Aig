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
    /// Generalidades de los establecimientos
    /// </summary>
    public class AUD_DatosEstablecimiento: SystemId
    {
        ////Provincia
        //private long? provinciaEstablecId;
        //public long? ProvinciaEstablecId { get => provinciaEstablecId; set => SetProperty(ref provinciaEstablecId, value); }
        //private ProvinciaTB? provinciaEstablec;
        //public virtual ProvinciaTB? ProvinciaEstablec { get => provinciaEstablec; set => SetProperty(ref provinciaEstablec, value); }

        ////distrito
        //private long? distritoEstablecId;
        //public long? DistritoEstablecId { get => distritoEstablecId; set => SetProperty(ref distritoEstablecId, value); }
        //private DistritoTB? distritoEstablec;
        //public virtual DistritoTB? DistritoEstablec { get => distritoEstablec; set => SetProperty(ref distritoEstablec, value); }

        ////distrito
        //private long? corregimientoEstablecId;
        //public long? CorregimientoEstablecId { get => corregimientoEstablecId; set => SetProperty(ref corregimientoEstablecId, value); }
        //private CorregimientoTB? corregimientoEstablec;
        //public virtual CorregimientoTB? CorregimientoEstablec { get => corregimientoEstablec; set => SetProperty(ref corregimientoEstablec, value); }

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

        //telefono1
        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }
    }
}
