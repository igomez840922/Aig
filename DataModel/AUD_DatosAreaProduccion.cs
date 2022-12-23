using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaProduccion:SystemId
    {
        public AUD_DatosAreaProduccion()
        {
            TipoLiquido = new AUD_DatosAreaProduccionTipo();
            TipoSemiSolido = new AUD_DatosAreaProduccionTipo();
            TipoSolido = new AUD_DatosAreaProduccionTipo();
        }


        // Orden lógico de las operaciones
        private enumAUD_TipoSeleccion ordenLogicoOpe;
        public enumAUD_TipoSeleccion OrdenLogicoOpe { get => ordenLogicoOpe; set => SetProperty(ref ordenLogicoOpe, value); }

        // Observaciones
        private string ordenLogicoOpeDesc;
        [StringLength(500)]
        public string OrdenLogicoOpeDesc { get => ordenLogicoOpeDesc; set => SetProperty(ref ordenLogicoOpeDesc, value); }

        // Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de Paredes
        private enumAUD_TipoSeleccion condAdecParedes;
        public enumAUD_TipoSeleccion CondAdecParedes { get => condAdecParedes; set => SetProperty(ref condAdecParedes, value); }

        // Observaciones
        private string condAdecParedesDesc;
        [StringLength(500)]
        public string CondAdecParedesDesc { get => condAdecParedesDesc; set => SetProperty(ref condAdecParedesDesc, value); }

        // Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de Pisos
        private enumAUD_TipoSeleccion condAdecPisos;
        public enumAUD_TipoSeleccion CondAdecPisos { get => condAdecPisos; set => SetProperty(ref condAdecPisos, value); }

        // Observaciones
        private string condAdecPisosDesc;
        [StringLength(500)]
        public string CondAdecPisosDesc { get => condAdecPisosDesc; set => SetProperty(ref condAdecPisosDesc, value); }

        // Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de Techos
        private enumAUD_TipoSeleccion condAdecTechos;
        public enumAUD_TipoSeleccion CondAdecTechos { get => condAdecTechos; set => SetProperty(ref condAdecTechos, value); }

        // Observaciones
        private string condAdecTechosDesc;
        [StringLength(500)]
        public string CondAdecTechosDesc { get => condAdecTechosDesc; set => SetProperty(ref condAdecTechosDesc, value); }

        // Vestidores, lavados, servicios sanitarios
        private enumAUD_TipoSeleccion vestLavServSanitarios;
        public enumAUD_TipoSeleccion VestLavServSanitarios { get => vestLavServSanitarios; set => SetProperty(ref vestLavServSanitarios, value); }

        // Observaciones
        private string vestLavServSanitariosDesc;
        [StringLength(500)]
        public string VestLavServSanitariosDesc { get => vestLavServSanitariosDesc; set => SetProperty(ref vestLavServSanitariosDesc, value); }

        // Implementos (mascarillas, gorros, guantes)
        private enumAUD_TipoSeleccion implementos;
        public enumAUD_TipoSeleccion Implementos { get => implementos; set => SetProperty(ref implementos, value); }

        // Observaciones
        private string implementosDesc;
        [StringLength(500)]
        public string ImplementosDesc { get => implementosDesc; set => SetProperty(ref implementosDesc, value); }

        // Los servicios sanitarios no comunican directamente con el área de producción
        private enumAUD_TipoSeleccion servSanitarioNoComAreaProd;
        public enumAUD_TipoSeleccion ServSanitarioNoComAreaProd { get => servSanitarioNoComAreaProd; set => SetProperty(ref servSanitarioNoComAreaProd, value); }

        // Observaciones
        private string servSanitarioNoComAreaProdDesc;
        [StringLength(500)]
        public string ServSanitarioNoComAreaProdDesc { get => servSanitarioNoComAreaProdDesc; set => SetProperty(ref servSanitarioNoComAreaProdDesc, value); }

        // Si almacenan piezas y herramientas en esta área, están colocadas en armarios reservados para este fin
        private enumAUD_TipoSeleccion piezasEnArmarios;
        public enumAUD_TipoSeleccion PiezasEnArmarios { get => piezasEnArmarios; set => SetProperty(ref piezasEnArmarios, value); }

        // Observaciones
        private string piezasEnArmariosDesc;
        [StringLength(500)]
        public string PiezasEnArmariosDesc { get => piezasEnArmariosDesc; set => SetProperty(ref piezasEnArmariosDesc, value); }

        // Letreros indicando el acceso restringido a personal autorizado
        private enumAUD_TipoSeleccion letreroAccesoRestring;
        public enumAUD_TipoSeleccion LetreroAccesoRestring { get => letreroAccesoRestring; set => SetProperty(ref letreroAccesoRestring, value); }

        // Observaciones
        private string letreroAccesoRestringDesc;
        [StringLength(500)]
        public string LetreroAccesoRestringDesc { get => letreroAccesoRestringDesc; set => SetProperty(ref letreroAccesoRestringDesc, value); }

        ////////////////////////////////////////////
        ////////////////////////////////////////////////
        ///

        // Observaciones
        private AUD_DatosAreaProduccionTipo tipoLiquido;
        public AUD_DatosAreaProduccionTipo TipoLiquido { get => tipoLiquido; set => SetProperty(ref tipoLiquido, value); }

        private AUD_DatosAreaProduccionTipo tipoSemiSolido;
        public AUD_DatosAreaProduccionTipo TipoSemiSolido { get => tipoSemiSolido; set => SetProperty(ref tipoSemiSolido, value); }
        
        private AUD_DatosAreaProduccionTipo tipoSolido;
        public AUD_DatosAreaProduccionTipo TipoSolido { get => tipoSolido; set => SetProperty(ref tipoSolido, value); }
        
    }

    public class AUD_DatosAreaProduccionTipo:SystemId
    {
        /////////////////////////////////////////////
        ////////////////////////////////////////////////

        // Cuenta con esclusas?
        private enumAUD_TipoSeleccion exclusas;
        public enumAUD_TipoSeleccion Exclusas { get => exclusas; set => SetProperty(ref exclusas, value); }
        // Observaciones
        private string exclusasDesc;
        public string ExclusasDesc { get => exclusasDesc; set => SetProperty(ref exclusasDesc, value); }

        //El laboratorio cuenta con áreas de tamaño, diseño y servicios (aire comprimido, agua, luz, ventilación, etc.) para efectuar los procesos de producción que corresponden? 
        private enumAUD_TipoSeleccion disenoTamanoProcesos;
        public enumAUD_TipoSeleccion DisenoTamanoProcesos { get => disenoTamanoProcesos; set => SetProperty(ref disenoTamanoProcesos, value); }
        // Observaciones
        private string disenoTamanoProcesosDesc;
        public string DisenoTamanoProcesosDesc { get => disenoTamanoProcesosDesc; set => SetProperty(ref disenoTamanoProcesosDesc, value); }

        //Están identificadas y separadas las áreas para la producción de sólidos, líquidos y semisólidos?
        private enumAUD_TipoSeleccion indentificadaSeparada;
        public enumAUD_TipoSeleccion IndentificadaSeparada { get => indentificadaSeparada; set => SetProperty(ref indentificadaSeparada, value); }
        // Observaciones
        private string indentificadaSeparadaDesc;
        public string IndentificadaSeparadaDesc { get => indentificadaSeparadaDesc; set => SetProperty(ref indentificadaSeparadaDesc, value); }

        //Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización? 
        private enumAUD_TipoSeleccion paredesPisosTechos;
        public enumAUD_TipoSeleccion ParedesPisosTechos { get => paredesPisosTechos; set => SetProperty(ref paredesPisosTechos, value); }
        // Observaciones
        private string paredesPisosTechosDesc;
        public string ParedesPisosTechosDesc { get => paredesPisosTechosDesc; set => SetProperty(ref paredesPisosTechosDesc, value); }

        //Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?
        private enumAUD_TipoSeleccion tuberiasPtosVentFacilLimpieza;
        public enumAUD_TipoSeleccion TuberiasPtosVentFacilLimpieza { get => tuberiasPtosVentFacilLimpieza; set => SetProperty(ref tuberiasPtosVentFacilLimpieza, value); }
        // Observaciones
        private string tuberiasPtosVentFacilLimpiezaDesc;
        public string TuberiasPtosVentFacilLimpiezaDesc { get => tuberiasPtosVentFacilLimpiezaDesc; set => SetProperty(ref tuberiasPtosVentFacilLimpiezaDesc, value); }

        //Están las tomas de gases y fluidos identificados y no son intercambiables?
        private enumAUD_TipoSeleccion tomasGasesIdentif;
        public enumAUD_TipoSeleccion TomasGasesIdentif { get => tomasGasesIdentif; set => SetProperty(ref tomasGasesIdentif, value); }
        // Observaciones
        private string tomasGasesIdentifDesc;
        public string TomasGasesIdentifDesc { get => tomasGasesIdentifDesc; set => SetProperty(ref tomasGasesIdentifDesc, value); }

        //Disponen de sistemas de inyección y extracción de aire?
        private enumAUD_TipoSeleccion sistInyExtAire;
        public enumAUD_TipoSeleccion SistInyExtAire { get => sistInyExtAire; set => SetProperty(ref sistInyExtAire, value); }
        // Observaciones
        private string sistInyExtAireDesc;
        public string SistInyExtAireDesc { get => sistInyExtAireDesc; set => SetProperty(ref sistInyExtAireDesc, value); }

        //Cuentan con equipo de control de aire, que permita el manejo de los diferenciales de presión de acuerdo a los requerimientos de cada área?
        private enumAUD_TipoSeleccion equipoControlAire;
        public enumAUD_TipoSeleccion EquipoControlAire { get => equipoControlAire; set => SetProperty(ref equipoControlAire, value); }
        // Observaciones
        private string equipoControlAireDesc;
        public string EquipoControlAireDesc { get => equipoControlAireDesc; set => SetProperty(ref equipoControlAireDesc, value); }

        //Las condiciones de temperatura y humedad relativa se ajustan a los requerimientos de los productos que en ella se realizan?
        private enumAUD_TipoSeleccion condHumTempAjustaReq;
        public enumAUD_TipoSeleccion CondHumTempAjustaReq { get => condHumTempAjustaReq; set => SetProperty(ref condHumTempAjustaReq, value); }
        // Observaciones
        private string condHumTempAjustaReqDesc;
        public string CondHumTempAjustaReqDesc { get => condHumTempAjustaReqDesc; set => SetProperty(ref condHumTempAjustaReqDesc, value); }

        //Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles? 
        private enumAUD_TipoSeleccion precNecMatFotosensible;
        public enumAUD_TipoSeleccion PrecNecMatFotosensible { get => precNecMatFotosensible; set => SetProperty(ref precNecMatFotosensible, value); }
        // Observaciones
        private string precNecMatFotosensibleDesc;
        public string PrecNecMatFotosensibleDesc { get => precNecMatFotosensibleDesc; set => SetProperty(ref precNecMatFotosensibleDesc, value); }

        //Están identificadas y separadas las áreas para el empaque primario de sólidos, líquidos y semisólidos? 
        private enumAUD_TipoSeleccion areaEmpaqueIdentSeparada;
        public enumAUD_TipoSeleccion AreaEmpaqueIdentSeparada { get => areaEmpaqueIdentSeparada; set => SetProperty(ref areaEmpaqueIdentSeparada, value); }
        // Observaciones
        private string areaEmpaqueIdentSeparadaDesc;
        public string AreaEmpaqueIdentSeparadaDesc { get => areaEmpaqueIdentSeparadaDesc; set => SetProperty(ref areaEmpaqueIdentSeparadaDesc, value); }

        //Están las tomas de gases y fluidos identificados? 
        private enumAUD_TipoSeleccion tomasGasesFluidosIdent;
        public enumAUD_TipoSeleccion TomasGasesFluidosIdent { get => tomasGasesFluidosIdent; set => SetProperty(ref tomasGasesFluidosIdent, value); }
        // Observaciones
        private string tomasGasesFluidosIdentDesc;
        public string TomasGasesFluidosIdentDesc { get => tomasGasesFluidosIdentDesc; set => SetProperty(ref tomasGasesFluidosIdentDesc, value); }

        //Las instalaciones tienen curvas sanitarias y servicios para el trabajo que allí se ejecuta? 
        private enumAUD_TipoSeleccion curvasSanitarias;
        public enumAUD_TipoSeleccion CurvasSanitarias { get => curvasSanitarias; set => SetProperty(ref curvasSanitarias, value); }
        // Observaciones
        private string curvasSanitariasDesc;
        public string CurvasSanitariasDesc { get => curvasSanitariasDesc; set => SetProperty(ref curvasSanitariasDesc, value); }

        //Existe un área exclusiva para el lavado de equipos móviles, recipientes y utensilios? 
        private enumAUD_TipoSeleccion areaLavadoEquipMoviles;
        public enumAUD_TipoSeleccion AreaLavadoEquipMoviles { get => areaLavadoEquipMoviles; set => SetProperty(ref areaLavadoEquipMoviles, value); }
        // Observaciones
        private string areaLavadoEquipMovilesDesc;
        public string AreaLavadoEquipMovilesDesc { get => areaLavadoEquipMovilesDesc; set => SetProperty(ref areaLavadoEquipMovilesDesc, value); }

        //Existe un área separada, identificada, limpia y ordenada para colocar equipo limpio que no se esté utilizando? 
        private enumAUD_TipoSeleccion areaEquiposLimpios;
        public enumAUD_TipoSeleccion AreaEquiposLimpios { get => areaEquiposLimpios; set => SetProperty(ref areaEquiposLimpios, value); }
        // Observaciones
        private string areaEquiposLimpiosDesc;
        public string AreaEquiposLimpiosDesc { get => areaEquiposLimpiosDesc; set => SetProperty(ref areaEquiposLimpiosDesc, value); }

        //Está el área de empaque secundario separada e identificada? 
        private enumAUD_TipoSeleccion areaEmpaqueSecundario;
        public enumAUD_TipoSeleccion AreaEmpaqueSecundario { get => areaEmpaqueSecundario; set => SetProperty(ref areaEmpaqueSecundario, value); }
        // Observaciones
        private string areaEmpaqueSecundarioDesc;
        public string AreaEmpaqueSecundarioDesc { get => areaEmpaqueSecundarioDesc; set => SetProperty(ref areaEmpaqueSecundarioDesc, value); }

        //El área tiene el tamaño de acuerdo con su capacidad y línea de producción, con el fin de evitar confusiones?
        private enumAUD_TipoSeleccion tamanoAdecuado;
        public enumAUD_TipoSeleccion TamanoAdecuado { get => tamanoAdecuado; set => SetProperty(ref tamanoAdecuado, value); }
        // Observaciones
        private string tamanoAdecuadoDesc;
        public string TamanoAdecuadoDesc { get => tamanoAdecuadoDesc; set => SetProperty(ref tamanoAdecuadoDesc, value); }

        //Tienen paredes, pisos y techos lisos de tal forma que permitan la fácil limpieza y sanitización?
        private enumAUD_TipoSeleccion facilLimpiezaSanitizacion;
        public enumAUD_TipoSeleccion FacilLimpiezaSanitizacion { get => facilLimpiezaSanitizacion; set => SetProperty(ref facilLimpiezaSanitizacion, value); }
        // Observaciones
        private string facilLimpiezaSanitizacionDesc;
        public string FacilLimpiezaSanitizacionDesc { get => facilLimpiezaSanitizacionDesc; set => SetProperty(ref facilLimpiezaSanitizacionDesc, value); }

        //Utilizan sistema para el tratamiento de agua?
        private enumAUD_TipoSeleccion sisTrataminetoAgua;
        public enumAUD_TipoSeleccion SisTrataminetoAgua { get => sisTrataminetoAgua; set => SetProperty(ref sisTrataminetoAgua, value); }
        // Observaciones
        private string sisTrataminetoAguaDesc;
        public string SisTrataminetoAguaDesc { get => sisTrataminetoAguaDesc; set => SetProperty(ref sisTrataminetoAguaDesc, value); }

    }

}
