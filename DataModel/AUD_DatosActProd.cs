using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosActProd:SystemId
    {
        public AUD_DatosActProd()
        {
            LActividades = new List<ActividadEstablecimientoTB>();
            LProductos = new List<ProductoEstablecimientoTB>();
        }

        //Actividades
        private List<ActividadEstablecimientoTB> lActividades;
        public List<ActividadEstablecimientoTB> LActividades { get => lActividades; set => SetProperty(ref lActividades, value); }

        //Productos
        private List<ProductoEstablecimientoTB> lProductos;
        public List<ProductoEstablecimientoTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        private string otrosActividad;
        public string OtrosActividad { get => otrosActividad; set => SetProperty(ref otrosActividad, value); }


        private string otrosProductos;
        public string OtrosProductos { get => otrosProductos; set => SetProperty(ref otrosProductos, value); }

            
    }
}
