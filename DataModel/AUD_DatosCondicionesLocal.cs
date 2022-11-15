using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosCondicionesLocal : SystemId
    {
        public AUD_DatosCondicionesLocal()
        {
            AreasAdministrativa = new AUD_DatosAreaAdministrativa();
            AreasRecProducto = new AUD_DatosAreaRecProducto();
            AreaAlmacenamiento = new AUD_DatosAreaAlmacenamiento();
            AreaProductosRetirados = new AUD_DatosAreaProductosRetirados();
            AreaProductosCuarentena = new AUD_DatosAreaProductosCuarentena();
            AreaDespachoProductos= new AUD_DatosAreaDespachoProductos();
            AreaAlmacenamientoFrio = new AUD_DatosAreaAlmacenamientoFrio();
            AreaAlmacenamientoDesperdicio = new AUD_DatosAreaAlmacenamientoDesperdicio();
            AreaAlmacenamientoVolatil = new AUD_DatosAreaAlmacenamientoVolatil();
            AreaAlmacenamientoPlaguicida = new AUD_DatosAreaAlmacenamientoPlaguicida();
            AreaAlmacenamientoMateriaPrima=new AUD_DatosAreaAlmacenamientoMateriaPrima();
            AreaProdSujetosControl = new AUD_DatosAreaProdSujetosControl();
            AreaTransporte = new AUD_DatosAreaTransporte();
            AreaVehiculosMotorizado = new AUD_DatosAreaVehiculosMotorizado();

		}

        // CONDICIONES Y CARACTERÍSTICAS DEL LOCAL
        // ¿El local está ubicado en área residencial? (está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales)
        private enumAUD_TipoSeleccion localAreaResidencial;
        public enumAUD_TipoSeleccion LocalAreaResidencial { get => localAreaResidencial; set => SetProperty(ref localAreaResidencial, value); }

        // Observación ¿El local está ubicado en área residencial? (está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales)
        private string localAreaResidencialDesc;
        [StringLength(500)]
        public string LocalAreaResidencialDesc { get => localAreaResidencialDesc; set => SetProperty(ref localAreaResidencialDesc, value); }

        // Se encontraba el Regente Farmacéutico en el Local?
        private enumAUD_TipoSeleccion estabaRegFarmEnLocal;
        public enumAUD_TipoSeleccion EstabaRegFarmEnLocal { get => estabaRegFarmEnLocal; set => SetProperty(ref estabaRegFarmEnLocal, value); }

        // Observación ¿El local está ubicado en área residencial? (está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales)
        private string estabaRegFarmEnLocalDesc;
        [StringLength(500)]
        public string EstabaRegFarmEnLocalDesc { get => estabaRegFarmEnLocalDesc; set => SetProperty(ref estabaRegFarmEnLocalDesc, value); }

        // ¿El Regente Farmacéutico realiza otras funciones dentro de la empresa?
        private enumAUD_TipoSeleccion otrasFuncionesRegFarm;
        public enumAUD_TipoSeleccion OtrasFuncionesRegFarm { get => otrasFuncionesRegFarm; set => SetProperty(ref otrasFuncionesRegFarm, value); }

        // ¿El Regente Farmacéutico realiza otras funciones dentro de la empresa?
        private string otrasFuncionesRegFarmDesc;
        [StringLength(500)]
        public string OtrasFuncionesRegFarmDesc { get => otrasFuncionesRegFarmDesc; set => SetProperty(ref otrasFuncionesRegFarmDesc, value); }

        // ¿Existe letrero visible que identifique la empresa?
        private enumAUD_TipoSeleccion letreroVisible;
        public enumAUD_TipoSeleccion LetreroVisible { get => letreroVisible; set => SetProperty(ref letreroVisible, value); }

        // Observación ¿Existe letrero visible que identifique la empresa?
        private string letreroVisibleDesc;
        [StringLength(500)]
        public string LetreroVisibleDesc { get => letreroVisibleDesc; set => SetProperty(ref letreroVisibleDesc, value); }

        // Area Administrativa
        private AUD_DatosAreaAdministrativa areasAdministrativa;
        public AUD_DatosAreaAdministrativa AreasAdministrativa { get => areasAdministrativa; set => SetProperty(ref areasAdministrativa, value); }

        // Area recepcion de Productos
        private AUD_DatosAreaRecProducto areasRecProducto;
        public AUD_DatosAreaRecProducto AreasRecProducto { get => areasRecProducto; set => SetProperty(ref areasRecProducto, value); }

        // Area Almacenamientos de Productos
        private AUD_DatosAreaAlmacenamiento areaAlmacenamiento;
        public AUD_DatosAreaAlmacenamiento AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        // Area Productos Retirados
        private AUD_DatosAreaProductosRetirados areaProductosRetirados;
        public AUD_DatosAreaProductosRetirados AreaProductosRetirados { get => areaProductosRetirados; set => SetProperty(ref areaProductosRetirados, value); }

        private AUD_DatosAreaProductosCuarentena areaProductosCuarentena;
        public AUD_DatosAreaProductosCuarentena AreaProductosCuarentena { get => areaProductosCuarentena; set => SetProperty(ref areaProductosCuarentena, value); }

        private AUD_DatosAreaDespachoProductos areaDespachoProductos;
        public AUD_DatosAreaDespachoProductos AreaDespachoProductos { get => areaDespachoProductos; set => SetProperty(ref areaDespachoProductos, value); }

        private AUD_DatosAreaAlmacenamientoFrio areaAlmacenamientoFrio;
        public AUD_DatosAreaAlmacenamientoFrio AreaAlmacenamientoFrio { get => areaAlmacenamientoFrio; set => SetProperty(ref areaAlmacenamientoFrio, value); }

        private AUD_DatosAreaAlmacenamientoDesperdicio areaAlmacenamientoDesperdicio;
        public AUD_DatosAreaAlmacenamientoDesperdicio AreaAlmacenamientoDesperdicio { get => areaAlmacenamientoDesperdicio; set => SetProperty(ref areaAlmacenamientoDesperdicio, value); }

        private AUD_DatosAreaAlmacenamientoVolatil areaAlmacenamientoVolatil;
        public AUD_DatosAreaAlmacenamientoVolatil AreaAlmacenamientoVolatil { get => areaAlmacenamientoVolatil; set => SetProperty(ref areaAlmacenamientoVolatil, value); }
        
        private AUD_DatosAreaAlmacenamientoPlaguicida areaAlmacenamientoPlaguicida;
        public AUD_DatosAreaAlmacenamientoPlaguicida AreaAlmacenamientoPlaguicida { get => areaAlmacenamientoPlaguicida; set => SetProperty(ref areaAlmacenamientoPlaguicida, value); }

        private AUD_DatosAreaAlmacenamientoMateriaPrima areaAlmacenamientoMateriaPrima;
        public AUD_DatosAreaAlmacenamientoMateriaPrima AreaAlmacenamientoMateriaPrima { get => areaAlmacenamientoMateriaPrima; set => SetProperty(ref areaAlmacenamientoMateriaPrima, value); }

        private AUD_DatosAreaProdSujetosControl areaProdSujetosControl;
        public AUD_DatosAreaProdSujetosControl AreaProdSujetosControl { get => areaProdSujetosControl; set => SetProperty(ref areaProdSujetosControl, value); }

		private AUD_DatosAreaTransporte areaTransporte;
		public AUD_DatosAreaTransporte AreaTransporte { get => areaTransporte; set => SetProperty(ref areaTransporte, value); }

		private AUD_DatosAreaVehiculosMotorizado areaVehiculosMotorizado;
		public AUD_DatosAreaVehiculosMotorizado AreaVehiculosMotorizado { get => areaVehiculosMotorizado; set => SetProperty(ref areaVehiculosMotorizado, value); }


		//Conclusión de Inspección

	}
}
