using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAnuncioFarmacia: SystemId
    {
        // “El usuario que adquiera un medicamento de los regulados que se venden sin receta medica lo hace bajo su responsabilidad” Art. 151. De la Ley 1 del 10 de enero de 2001
        private enumAUD_TipoSeleccion ventaSinRecetaBajoResponsabilidad;
        public enumAUD_TipoSeleccion VentaSinRecetaBajoResponsabilidad { get => ventaSinRecetaBajoResponsabilidad; set => SetProperty(ref ventaSinRecetaBajoResponsabilidad, value); }

        //Prohibición a establecimiento farmacéuticos la venta de bebidas alcohólicas.  Art 1. Ley 17.  De 12 de septiembre de 2014
        private enumAUD_TipoSeleccion prohibVentaBebidaAlcoholica;
        public enumAUD_TipoSeleccion ProhibVentaBebidaAlcoholica { get => prohibVentaBebidaAlcoholica; set => SetProperty(ref prohibVentaBebidaAlcoholica, value); }

        //Prohibición de expendio, cobro y exposición de bebidas alcohólicas”.  Art 2. Ley 17. De 12 de septiembre de 2014
        private enumAUD_TipoSeleccion prohibExposicionBebidaAlcoholica;
        public enumAUD_TipoSeleccion ProhibExposicionBebidaAlcoholica { get => prohibExposicionBebidaAlcoholica; set => SetProperty(ref prohibExposicionBebidaAlcoholica, value); }

        //Tabla de Promedio y Precio Mínimo Unitario de la Canasta Básica de Medicamento. Resolución 774. De 7 de octubre de 2019
        private enumAUD_TipoSeleccion precioMinUnitCanastaBasic;
        public enumAUD_TipoSeleccion PrecioMinUnitCanastaBasic { get => precioMinUnitCanastaBasic; set => SetProperty(ref precioMinUnitCanastaBasic, value); }

    }
}
