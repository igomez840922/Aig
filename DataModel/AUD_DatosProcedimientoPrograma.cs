using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosProcedimientoPrograma:SystemId
    {

        // PROCEDIMIENTOS Y PROGRAMAS
        // Procedimiento para la elaboración de procedimientos (POE de POE’s)
        private enumAUD_TipoSeleccion elabProcPOE;
        public enumAUD_TipoSeleccion ElabProcPOE { get => elabProcPOE; set => SetProperty(ref elabProcPOE, value); }

        // Observaciones
        private string elabProcPOEDesc;
        [StringLength(500)]
        public string ElabProcPOEDesc { get => elabProcPOEDesc; set => SetProperty(ref elabProcPOEDesc, value); }


        // Programa de limpieza e higiene
        private enumAUD_TipoSeleccion limpiezaHigiene;
        public enumAUD_TipoSeleccion LimpiezaHigiene { get => limpiezaHigiene; set => SetProperty(ref limpiezaHigiene, value); }

        // Observaciones
        private string limpiezaHigieneDesc;
        [StringLength(500)]
        public string LimpiezaHigieneDesc { get => limpiezaHigieneDesc; set => SetProperty(ref limpiezaHigieneDesc, value); }

        // Programa que contemple exámenes médicos
        private enumAUD_TipoSeleccion examMedicos;
        public enumAUD_TipoSeleccion ExamMedicos { get => examMedicos; set => SetProperty(ref examMedicos, value); }

        // Observaciones
        private string examMedicosDesc;
        [StringLength(500)]
        public string ExamMedicosDesc { get => examMedicosDesc; set => SetProperty(ref examMedicosDesc, value); }

        // Procedimiento de higiene personal
        private enumAUD_TipoSeleccion higienePersonal;
        public enumAUD_TipoSeleccion HigienePersonal { get => higienePersonal; set => SetProperty(ref higienePersonal, value); }

        // Observaciones
        private string higienePersonalDesc;
        [StringLength(500)]
        public string HigienePersonalDesc { get => higienePersonalDesc; set => SetProperty(ref higienePersonalDesc, value); }


        // Programa para el control de la fauna nociva
        private enumAUD_TipoSeleccion controlFaunaNociva;
        public enumAUD_TipoSeleccion ControlFaunaNociva { get => controlFaunaNociva; set => SetProperty(ref controlFaunaNociva, value); }

        // Observaciones
        private string controlFaunaNocivaDesc;
        [StringLength(500)]
        public string ControlFaunaNocivaDesc { get => controlFaunaNocivaDesc; set => SetProperty(ref controlFaunaNocivaDesc, value); }

        // Procedimientos para el control de la temperatura y humedad
        private enumAUD_TipoSeleccion controlTempHumedad;
        public enumAUD_TipoSeleccion ControlTempHumedad { get => controlTempHumedad; set => SetProperty(ref controlTempHumedad, value); }

        // Observaciones
        private string controlTempHumedadDesc;
        [StringLength(500)]
        public string ControlTempHumedadDesc { get => controlTempHumedadDesc; set => SetProperty(ref controlTempHumedadDesc, value); }

        // Procedimiento para la calibración de equipo
        private enumAUD_TipoSeleccion calibracionEquipo;
        public enumAUD_TipoSeleccion CalibracionEquipo { get => calibracionEquipo; set => SetProperty(ref calibracionEquipo, value); }

        // Observaciones
        private string calibracionEquipoDesc;
        [StringLength(500)]
        public string CalibracionEquipoDesc { get => calibracionEquipoDesc; set => SetProperty(ref calibracionEquipoDesc, value); }

        // Procedimiento para la recepción de materia prima
        private enumAUD_TipoSeleccion recepMatPrima;
        public enumAUD_TipoSeleccion RecepMatPrima { get => recepMatPrima; set => SetProperty(ref recepMatPrima, value); }

        // Observaciones
        private string recepMatPrimaDesc;
        [StringLength(500)]
        public string RecepMatPrimaDesc { get => recepMatPrimaDesc; set => SetProperty(ref recepMatPrimaDesc, value); }

        // Procedimiento para la recepción de material de acondicionamiento
        private enumAUD_TipoSeleccion recepMaterialAcond;
        public enumAUD_TipoSeleccion RecepMaterialAcond { get => recepMaterialAcond; set => SetProperty(ref recepMaterialAcond, value); }

        // Observaciones
        private string recepMaterialAcondDesc;
        [StringLength(500)]
        public string RecepMaterialAcondDesc { get => recepMaterialAcondDesc; set => SetProperty(ref recepMaterialAcondDesc, value); }



        // Procedimiento para la recepción de productos terminados.
        private enumAUD_TipoSeleccion recepProdTerminados;
        public enumAUD_TipoSeleccion RecepProdTerminados { get => recepProdTerminados; set => SetProperty(ref recepProdTerminados, value); }

        // Observaciones
        private string recepProdTerminadosDesc;
        [StringLength(500)]
        public string RecepProdTerminadosDesc { get => recepProdTerminadosDesc; set => SetProperty(ref recepProdTerminadosDesc, value); }

        // Procedimiento para el muestreo de materia prima
        private enumAUD_TipoSeleccion muestreoMatPrima;
        public enumAUD_TipoSeleccion MuestreoMatPrima { get => muestreoMatPrima; set => SetProperty(ref muestreoMatPrima, value); }

        // Observaciones
        private string muestreoMatPrimaDesc;
        [StringLength(500)]
        public string MuestreoMatPrimaDesc { get => muestreoMatPrimaDesc; set => SetProperty(ref muestreoMatPrimaDesc, value); }

        // Procedimiento para el muestreo de materiales
        private enumAUD_TipoSeleccion muestreoMateriales;
        public enumAUD_TipoSeleccion MuestreoMateriales { get => muestreoMateriales; set => SetProperty(ref muestreoMateriales, value); }

        // Observaciones
        private string muestreoMaterialesDesc;
        [StringLength(500)]
        public string MuestreoMaterialesDesc { get => muestreoMaterialesDesc; set => SetProperty(ref muestreoMaterialesDesc, value); }

        // Procedimiento para el almacenamiento de productos terminados
        private enumAUD_TipoSeleccion almProdTerminados;
        public enumAUD_TipoSeleccion AlmProdTerminados { get => almProdTerminados; set => SetProperty(ref almProdTerminados, value); }

        // Observaciones
        private string almProdTerminadosDesc;
        [StringLength(500)]
        public string AlmProdTerminadosDesc { get => almProdTerminadosDesc; set => SetProperty(ref almProdTerminadosDesc, value); }

        // Procedimientos de Destrucción (material de acondicionamiento, productos)
        private enumAUD_TipoSeleccion procDestMateriales;
        public enumAUD_TipoSeleccion ProcDestMateriales { get => procDestMateriales; set => SetProperty(ref procDestMateriales, value); }

        // Observaciones
        private string procDestMaterialesDesc;
        [StringLength(500)]
        public string ProcDestMaterialesDesc { get => procDestMaterialesDesc; set => SetProperty(ref procDestMaterialesDesc, value); }

        // Cuando la documentación se mantiene por procesamiento electrónico de datos, el acceso está restringido por claves de acceso
        private enumAUD_TipoSeleccion procDatosElectronicos;
        public enumAUD_TipoSeleccion ProcDatosElectronicos { get => procDatosElectronicos; set => SetProperty(ref procDatosElectronicos, value); }

        // Observaciones
        private string procDatosElectronicosDesc;
        [StringLength(500)]
        public string ProcDatosElectronicosDesc { get => procDatosElectronicosDesc; set => SetProperty(ref procDatosElectronicosDesc, value); }

        // Fórmula Maestra
        private enumAUD_TipoSeleccion formulaMaestra;
        public enumAUD_TipoSeleccion FormulaMaestra { get => formulaMaestra; set => SetProperty(ref formulaMaestra, value); }

        // Observaciones
        private string formulaMaestraDesc;
        [StringLength(500)]
        public string FormulaMaestraDesc { get => formulaMaestraDesc; set => SetProperty(ref formulaMaestraDesc, value); }

        // Procedimiento para la numeración del lote
        private enumAUD_TipoSeleccion procNumeracionLote;
        public enumAUD_TipoSeleccion ProcNumeracionLote { get => procNumeracionLote; set => SetProperty(ref procNumeracionLote, value); }

        // Observaciones
        private string procNumeracionLoteDesc;
        [StringLength(500)]
        public string ProcNumeracionLoteDesc { get => procNumeracionLoteDesc; set => SetProperty(ref procNumeracionLoteDesc, value); }

        // Procedimientos para pruebas, ensayos de control
        private enumAUD_TipoSeleccion procPruebaEnsayoControl;
        public enumAUD_TipoSeleccion ProcPruebaEnsayoControl { get => procPruebaEnsayoControl; set => SetProperty(ref procPruebaEnsayoControl, value); }

        // Observaciones
        private string procPruebaEnsayoControlDesc;
        [StringLength(500)]
        public string ProcPruebaEnsayoControlDesc { get => procPruebaEnsayoControlDesc; set => SetProperty(ref procPruebaEnsayoControlDesc, value); }

        // Procedimientos para aprobación o rechazo de los materiales y productos
        private enumAUD_TipoSeleccion procAprobacionRechazoMatProd;
        public enumAUD_TipoSeleccion ProcAprobacionRechazoMatProd { get => procAprobacionRechazoMatProd; set => SetProperty(ref procAprobacionRechazoMatProd, value); }

        // Observaciones
        private string procAprobacionRechazoMatProdDesc;
        [StringLength(500)]
        public string ProcAprobacionRechazoMatProdDesc { get => procAprobacionRechazoMatProdDesc; set => SetProperty(ref procAprobacionRechazoMatProdDesc, value); }

    }

}
