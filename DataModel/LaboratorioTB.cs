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
    public class LaboratorioTB:SystemId
    {
        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        private enum_LaboratoryType tipoLaboratorio;
        public enum_LaboratoryType TipoLaboratorio { get => tipoLaboratorio; set => SetProperty(ref tipoLaboratorio, value); }


        private enum_UbicationType tipoUbicacion;
        public enum_UbicationType TipoUbicacion { get => tipoUbicacion; set => SetProperty(ref tipoUbicacion, value); }

        //nombre de establecimiento
        private string pais;
        [StringLength(250)]
        public string Pais { get => pais; set => SetProperty(ref pais, value); }
                
        //Direccion
        private string direccion;
        public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

        //Telefono
        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        //Correo
        private string correo;
        [StringLength(250)]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }

        //antigua BD
        private int idEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int IdEmpresa { get => idEmpresa; set => SetProperty(ref idEmpresa, value); }


        private List<FMV_PmrProductoTB> lProductos;
        public virtual List<FMV_PmrProductoTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        private List<FMV_IpsTB> lIps;
        public virtual List<FMV_IpsTB> LIps { get => lIps; set => SetProperty(ref lIps, value); }

        private List<FMV_RfvTB> lRfv;
        public virtual List<FMV_RfvTB> LRfv { get => lRfv; set => SetProperty(ref lRfv, value); }

        private List<FMV_EsaviNotificacionTB> lEsaviNotificacion;
        public virtual List<FMV_EsaviNotificacionTB> LEsaviNotificacion { get => lEsaviNotificacion; set => SetProperty(ref lEsaviNotificacion, value); }

        private List<FMV_FfTB> lFf;
        public virtual List<FMV_FfTB> LFf { get => lFf; set => SetProperty(ref lFf, value); }

        private List<FMV_FtTB> lFt;
        public virtual List<FMV_FtTB> LFt { get => lFt; set => SetProperty(ref lFt, value); }

    }
}
