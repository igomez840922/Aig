using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperFabricanteCosmetMedTB : SystemId
    {
        public AUD_InspAperFabricanteCosmetMedTB()
        {
            DatosEstablecimiento = new AUD_GeneralesEmpresa();
            DatosRegente = new AUD_DatosRegente();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();
            
            DatosConclusiones = new AUD_DatosConclusiones();


            InicializaData();
        }

        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Establecimiento
        private AUD_GeneralesEmpresa datosEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa DatosEstablecimiento { get => datosEstablecimiento; set => SetProperty(ref datosEstablecimiento, value); }


        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos del Regente
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Productos que Fabrican
        private string tipoProductos;
        public string TipoProductos { get => tipoProductos; set => SetProperty(ref tipoProductos, value); }

        //DOCUMENTACIÓN

        //Organización y Personal
        private AUD_ContenidoTablas organizacionPersonal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas OrganizacionPersonal { get => organizacionPersonal; set => SetProperty(ref organizacionPersonal, value); }

        //Programas
        private AUD_ContenidoTablas programas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Programas { get => programas; set => SetProperty(ref programas, value); }

        //Producción y Análisis por Contrato
        private AUD_ContenidoTablas prodAnalisisContrato;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ProdAnalisisContrato { get => prodAnalisisContrato; set => SetProperty(ref prodAnalisisContrato, value); }

        //Reclamos y Productos retirados del mercado
        private AUD_ContenidoTablas reclamosProdRetirados;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ReclamosProdRetirados { get => reclamosProdRetirados; set => SetProperty(ref reclamosProdRetirados, value); }

        //Locales
        private AUD_ContenidoTablas locales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Locales { get => locales; set => SetProperty(ref locales, value); }

        //Área de Producción
        private AUD_ContenidoTablas areaProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaProduccion { get => areaProduccion; set => SetProperty(ref areaProduccion, value); }

        //Equipo
        private AUD_ContenidoTablas equipo;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Equipo { get => equipo; set => SetProperty(ref equipo, value); }

        //Laboratorio de Control de Calidad
        private AUD_ContenidoTablas laboratorioControlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas LaboratorioControlCalidad { get => laboratorioControlCalidad; set => SetProperty(ref laboratorioControlCalidad, value); }

        //AREA DE ALMACENAMIENTO

        //Laboratorio de Control de Calidad
        private AUD_ContenidoTablas areaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        //AREA DE Auxiliares

        //AreaAuxiliar
        private AUD_ContenidoTablas areaAuxiliar;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaAuxiliar { get => areaAuxiliar; set => SetProperty(ref areaAuxiliar, value); }


        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


        private void InicializaData()
        {
            OrganizacionPersonal = new AUD_ContenidoTablas() {
                Titulo = "Organización y Personal",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "¿El establecimiento se encuentra identificado exteriormente, mediante letrero?",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Organigramas (General y específicos)",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Descripción de puestos",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Responsable de investigación y desarrollo",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Responsable de producción",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Responsable de control de calidad",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Responsable de garantía de la calidad",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Inducción del personal",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            Programas = new AUD_ContenidoTablas()
            {
                Titulo = "Programas",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Programa de limpieza e higiene",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Programa que contemple exámenes médicos",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Programa para el control de la fauna nociva",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Cuando la documentación se mantiene por procesamiento electrónico de datos, el acceso está restringido por claves de acceso.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Fórmula maestra",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            ProdAnalisisContrato = new AUD_ContenidoTablas()
            {
                Titulo = "Producción y Análisis por Contrato",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Contrato por escrito que establezca las funciones y responsabilidades de cada parte",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Análisis por contrato: el contrato establece que la aprobación final del producto lo hará el contratante a través del responsable de Control de Calidad.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "El contrato establece donde se tomarán las muestras para su análisis.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Fabricación por contrato: realizada por un fabricante con Licencia de Operación.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            ReclamosProdRetirados = new AUD_ContenidoTablas()
            {
                Titulo = "Reclamos y Productos retirados del mercado",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Persona encargada",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            Locales = new AUD_ContenidoTablas()
            {
                Titulo = "Locales",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "El local está limpio y ordenado",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Instrucciones que no se debe permitir fumar, comer, beber, masticar o guardar plantas, comidas, bebidas, material de fumar y medicamentos personales",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Áreas externas limpias, ordenadas y libres de materiales extraños.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Condiciones adecuadas de:",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            IsHeader = true,
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Suministros eléctricos",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Iluminación",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Temperatura",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Humedad",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Ventilación",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Estado de conservación del edificio",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Señalización de las vías o rutas de evacuación",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Equipo para el control de incendios",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            AreaProduccion = new AUD_ContenidoTablas()
            {
                Titulo = "Área de Producción",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Orden lógico de las operaciones",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de:",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            IsHeader=true,
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Paredes",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Pisos",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Techos",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Vestidores, lavados, servicios sanitarios",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Implementos (mascarillas, gorros, guantes)",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Los servicios sanitarios no comunican directamente con el área de producción",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Si almacenan piezas y herramientas en esta área, están colocadas en armarios reservados para este fin.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Letreros indicando el acceso restringido a personal autorizado",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            Equipo = new AUD_ContenidoTablas()
            {
                Titulo = "Equipo",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Adecuadamente localizado",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Las tuberías fijas conectados al equipo están rotulados claramente indicando su contenido.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Las tuberías de servicios (agua, gases, otros), están identificados.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            LaboratorioControlCalidad = new AUD_ContenidoTablas()
            {
                Titulo = "Laboratorio de Control de Calidad",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Equipo e instrumentos de laboratorio de control son apropiados a los procedimientos de análisis que se realizarán.",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Área para almacenar los patrones",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Cuentan con especificaciones para:",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            IsHeader=true
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Materia prima",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Material de acondicionamiento",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Productos semi-elaborados y a granel",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                     new ContenidoTablas()
                        {
                            Titulo = "Productos terminados",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                }
            };
            AreaAlmacenamiento = new AUD_ContenidoTablas()
            {
                Titulo = "Áreas de Almacenamiento",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Cuenta con un área para",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "El área se encuentra",
                            IsHeader=true
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Limpia",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Seca",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Dentro de límites aceptables de temperatura",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Delimitada",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Identificada",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Ordenada",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Adecuada iluminación",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Adecuadas condiciones de pisos",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Adecuadas condiciones de paredes",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Adecuadas condiciones de techos",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Sistema para los controles ambientales de temperatura y humedad relativa",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Formatos para Registro de temperatura y humedad relativa",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Letreros visibles de los rangos de temperatura y humedad de almacenamiento (según lo estipulado por el fabricante)",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Recepción y despacho protegida de las inclemencias   del tiempo",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Áreas de cuarentena: identificadas y de acceso restringido",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Área para almacenar productos rechazados, retirados o devueltos",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Área para almacenar sustancias con riesgo a fuego o explosión",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Área de almacenamiento para Etiquetas, material impreso",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Existen advertencias o prohibiciones de",
                            IsHeader=true,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "No comer",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "No beber",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "No fumar",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "No guardar plantas comidas y bebidas",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Los servicios sanitarios no comunican directamente.",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Señalización de las vías o rutas de evacuación en casos de siniestro o catástrofe",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Equipo para el control de incendios",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                            Evaluacion2 = enumAUD_TipoSeleccion.NA,
                            Evaluacion3 = enumAUD_TipoSeleccion.NA,
                        },
                }
            };
            AreaAuxiliar = new AUD_ContenidoTablas()
            {
                Titulo = "Áreas Auxiliares",
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "Áreas de descanso y comedores separados de áreas técnicas",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Servicios sanitarios, lavamanos y en cantidad suficiente",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Casilleros para el personal ",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "Áreas de mantenimiento separadas de las áreas de producción",
                            Evaluacion = enumAUD_TipoSeleccion.NA,
                        },
                }
            };

        }


    }

}
