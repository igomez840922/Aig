using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspGuiaBPM_BpaTB : SystemId
    {
        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private DatosPersona datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos del Regente
        private DatosPersona datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Otros Funcionarios
        private AUD_OtrosFuncionarios otrosFuncionarios;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_OtrosFuncionarios OtrosFuncionarios { get => otrosFuncionarios; set => SetProperty(ref otrosFuncionarios, value); }

        // Actividad comercial aprobada
        private string actComercialAprobada;
        public string ActComercialAprobada { get => actComercialAprobada; set => SetProperty(ref actComercialAprobada, value); }

        // Fecha de la última Inspeccion
        private DateTime? fechaUltimaInspeccion;
        public DateTime? FechaUltimaInspeccion { get => fechaUltimaInspeccion; set => SetProperty(ref fechaUltimaInspeccion, value); }

        //Propósito de la Inspección de Buenas Prácticas de Almacenamiento y Distribución
        private AUD_PropositosInspeccion propositoInsp;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_PropositosInspeccion PropositoInsp { get => propositoInsp; set => SetProperty(ref propositoInsp, value); }

        // Horarios verificados durante la inspección Horario Establecimiento Farmaceutico
        private string horarioEstFarmaceutico;
        public string HorarioEstFarmaceutico { get => horarioEstFarmaceutico; set => SetProperty(ref horarioEstFarmaceutico, value); }

        // Horarios verificados durante la inspección Horario Regencia Farmaceutica
        private string horarioRegFarmaceutica;
        public string HorarioRegFarmaceutica { get => horarioRegFarmaceutica; set => SetProperty(ref horarioRegFarmaceutica, value); }



        //1. DISPOSICIONES GENERALES DEL ESTABLECIMIENTO FARMACÉUTICO
        private AUD_ContenidoGenerico dispGenerlestablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DispGenerlestablecimiento { get => dispGenerlestablecimiento; set => SetProperty(ref dispGenerlestablecimiento, value); }

        //2. AREAS DEL ESTABLECIMIENTO
        private AUD_ContenidoGenerico areasEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreasEstablecimiento { get => areasEstablecimiento; set => SetProperty(ref areasEstablecimiento, value); }

        //3. DISTRIBUCIÓN
        private AUD_ContenidoGenerico distribucion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Distribucion { get => distribucion; set => SetProperty(ref distribucion, value); }

        //4. DEL TRANSPORTE PARA LOS PRODUCTOS FARMACÉUTICOS
        private AUD_ContenidoGenerico transProdFarmaceuticos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico TransProdFarmaceuticos { get => transProdFarmaceuticos; set => SetProperty(ref transProdFarmaceuticos, value); }

        //5. AUTO-INSPECCIÓN
        private AUD_ContenidoGenerico autoInspec;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AutoInspec { get => autoInspec; set => SetProperty(ref autoInspec, value); }

        public void Inicializa_DispGenerlestablecimiento()
        {
            DispGenerlestablecimiento = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                        {
                           Titulo = "1.1. Generalidades",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=1,
                            Titulo = "El establecimiento farmacéutico cuenta con licencia de operación vigente expedida por la Dirección Nacional de Farmacia y Drogas",
                            Criterio = "Crítico",
                            Capitulo="385, 386",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=2,
                            Titulo = "Las actividades que realiza el establecimiento son las autorizadas en la licencia de operación",
                            Criterio = "Crítico",
                            Capitulo="385, 386",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=3,
                            Titulo = "El Regente Farmacéutico o un Farmacéutico están presente al momento de la Inspección",
                            Criterio = "Crítico",
                            Articulo="Ley 24 Art. 16 ",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=4,
                            Titulo = "El establecimiento farmacéutico dispone de medidas preventivas en el que otorga el equipo de protección al personal a fin de garantizar la salud ocupacional del trabajador.",
                            Criterio = "Mayor",
                            Capitulo="411",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=5,
                            Titulo = "El establecimiento posee Licencia Especial de Sustancias Controladas (LESC). Cuando aplique.",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 14 Art. 5",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=6,
                            Titulo = "La Licencia Especial de Sustancias Controladas (LESC), está vigente.",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 14 Art. 8 y Art. 31",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=7,
                            Titulo = "Se evidencia que el establecimiento farmacéutico está operando en un área aprobada para la actividad comercial (prohibidas áreas residenciales o residencias habitadas).",
                            Criterio = "Crítico",
                            Capitulo="467",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=8,
                            Titulo = "La autoridad tiene libre acceso al establecimiento",
                            Criterio = "Crítico",
                            Capitulo="467",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=9,
                            Titulo = "El establecimiento mantiene un registro de las importaciones oficialmente aprobadas por la Dirección Nacional de Farmacia y Drogas (productos terminados, materia prima) y los documentos autorizados para tal fin",
                            Criterio = "Mayor",
                            Capitulo="",
                            Articulo="Ley No.1 art 68",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=10,
                            Titulo = "Se puede comprobar que los productos que maneja y cuya competencia corresponde a la Dirección Nacional de Farmacia y Drogas, son los autorizados en la Licencia de Operación.",
                            Criterio = "Crítico",
                            Capitulo="599, 386, 668",
                            Articulo="Ley 1 Art. 172, Ley 24 Art. 12",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "1.2. Documentación",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=11,
                            Titulo = "La documentación que maneja el establecimiento farmacéutico se mantiene en archivos físicos o digitales dentro del establecimiento y permanecen en custodia.",
                            Criterio = "Crítico",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=12,
                             Titulo = "Cuenta con Manual de Cargos y Funciones",
                            Criterio = "Mayor",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=13,
                            Titulo = "Cuenta el establecimiento farmacéutico con organigrama",
                            Criterio = "Mayor",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=14,
                            Titulo = "Cuenta el establecimiento farmacéutico con Manual de Procedimientos",
                            Criterio = "Crítico",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=15,
                            Titulo = "Cuenta con personal responsable del sistema de Gestión de la Calidad",
                            Criterio = "Crítico",
                            Capitulo="412",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=16,
                            Titulo = "El establecimiento farmacéutico cuenta con plan de capacitación en temas de Buenas prácticas de Almacenamiento de medicamentos y otros productos para la salud humana.",
                            Criterio = "Mayor",
                            Capitulo="413",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=17,
                            Titulo = "El personal dedicado a la manipulación de productos que requieren condiciones especiales de seguridad o de conservación, recibe capacitación específica.",
                            Criterio = "Mayor",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=18,
                            Titulo = "El establecimiento farmacéutico presenta evidencias que desarrolla actividades de capacitación sobre condiciones de almacenamiento de los productos para la salud humana.",
                            Criterio = "Mayor",
                            Capitulo="413",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=19,
                            Titulo = "El establecimiento farmacéutico cuenta con procedimientos de limpieza de las áreas.  En el mismo se indica con qué frecuencia se realiza la limpieza",
                            Criterio = "Mayor",
                            Capitulo="417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=20,
                            Titulo = "Existe evidencia del cumplimiento del procedimiento de limpieza de las áreas  ",
                            Criterio = "Crítico",
                            Capitulo="417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=21,
                            Titulo = "El establecimiento farmacéutico dispone de un procedimiento y programa para el control de la fauna nociva. ",
                            Criterio = "Mayor",
                            Capitulo="417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=22,
                            Titulo = "El establecimiento farmacéutico dispone de los registros respectivos para el control de la fauna nociva",
                            Criterio = "Crítico",
                            Capitulo="403, 417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=23,
                            Titulo = "Los productos utilizados para el control de fauna nociva cuentan con las autorizaciones correspondientes",
                            Criterio = "Crítico",
                            Capitulo="417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=24,
                            Titulo = "El establecimiento cuenta con programas de mantenimiento preventivo a sus estructuras y cuentan con registros de verificación",
                            Criterio = "Crítico",
                            Capitulo="417",
                            Articulo="Ley 1 Art. 97",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=25,
                            Titulo = "El establecimiento cuenta con programas de mantenimiento preventivo de sus equipos y cuentan con registros de verificación.",
                            Criterio = "Crítico",
                            Capitulo="425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=26,
                            Titulo = "Presenta evidencia que demuestre que ha gestionado con la entidad competente lo concerniente a Salud Ocupacional.",
                            Criterio = "Mayor",
                            Capitulo="411",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=27,
                            Titulo = "El establecimiento cuenta con procedimientos para la recepción de productos, que incluya el muestreo de los productos recibidos.",
                            Criterio = "Crítico",
                            Capitulo="403, 422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=28,
                            Titulo = "El muestreo de los productos recibidos es realizado por personal capacitado",
                            Criterio = "Mayor",
                            Capitulo="422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=29,
                            Titulo = "El establecimiento cuenta con procedimientos para el despacho de productos.",
                            Criterio = "Crítico",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=30,
                            Titulo = "El establecimiento farmacéutico cuenta con procedimientos operativos sobre el manejo de los productos farmacéuticos de cadena de frío. ",
                            Criterio = "Crítico",
                            Capitulo="455\r\n454\r\n",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=31,
                            Titulo = "Cuentan con alguna prueba de que realizan la entrega de evidencia al cliente de que el producto está cumpliendo con la cadena de frío.",
                            Criterio = "Crítico",
                            Capitulo="454, 455",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=32,
                            Titulo = "El establecimiento cuenta con procedimientos operativos de distribución de cada lote de materia prima, excipientes y productos terminados listos para su distribución",
                            Criterio = "Crítico",
                            Capitulo="440",
                            Articulo="Ley 1 Art. 78",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=33,
                            Titulo = "Los registros de distribución contienen la siguiente información:\r\n-Nombre, presentación y forma farmacéutica\r\n-Número de lote\r\n-Nombre y dirección del consignatario (incluyendo los productos de exportación)\r\n-Fecha y cantidad despachada\r\n-Número de factura o documentación de embarque según sea el caso\r\n-Nombre del laboratorio fabricante\r\nSea en carpeta o archivos electrónicos. \r\n",
                            Criterio = "Crítico",
                            Capitulo="403, 441",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=34,
                            Titulo = "Los registros de distribución se mantienen actualizados",
                            Criterio = "Crítico",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=35,
                            Titulo = "El Establecimiento Farmacéutico cuenta con procedimientos operativos para retirar y reemplazar los productos de los comercios a los que distribuyen.",
                            Criterio = "Crítico",
                            Capitulo="403, 457",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=36,
                            Titulo = "Existe un procedimiento que describe el manejo de quejas y reclamos sobre productos que presenten algún defecto. \r\nQue incluye:\r\n-la coordinación del retiro del producto del mercado,\r\n-las recomendaciones de medidas a tomar,\r\n-comunicación a las autoridades correspondientes.\r\n",
                            Criterio = "Crítico",
                            Capitulo="403, 433, 456, 457",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=37,
                            Titulo = "El establecimiento posee un registro de quejas y reclamos, la investigación de estas; y la comunicación a las autoridades correspondientes.",
                            Criterio = "Crítico",
                            Capitulo="456, 459",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=38,
                            Titulo = "El sistema de quejas y reclamos contempla la comunicación al distribuidor o laboratorio fabricante sobre la medida que se adopte.",
                            Criterio = "Crítico",
                            Capitulo="456, 459",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=39,
                            Titulo = "Al Regente Farmacéutico se le informa sobre la investigación o retiro de producto del mercado",
                            Criterio = "Mayor",
                            Capitulo="456",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                },

            };
        }
        public void Inicializa_AreasEstablecimiento()
        {
            AreasEstablecimiento = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.1. Instalaciones",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "El establecimiento farmacéutico cuenta con las siguientes características",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=40,
                            Titulo = "- está identificado",
                            Criterio = "Menor",
                            Capitulo="414",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=41,
                            Titulo = "- se controla el acceso ",
                            Criterio = "Crítico",
                            Capitulo="414",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=42,
                             Titulo = "- está construido de material sólido",
                            Criterio = "Mayor",
                            Capitulo="414",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=43,
                            Titulo = "- el área donde se sitúa el local, evita riesgo mínimo de provocar cualquier contaminación a los productos",
                            Criterio = "Crítico",
                            Capitulo="415",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=44,
                            Titulo = "El diseño minimiza riesgo de error y permite limpieza y mantenimiento efectivo",
                            Criterio = "Mayor",
                            Capitulo="414",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=45,
                            Titulo = "El área está limpia de tal forma que no existe acumulación de polvo",
                            Criterio = "Mayor",
                            Capitulo="414",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=46,
                            Titulo = "Cuenta con control de fauna nociva para evitar la entrada de insectos u otros animales",
                            Criterio = "Mayor",
                            Capitulo="416, 417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=47,
                            Titulo = "Se cuenta con un sistema contra incendios (verificar su vigencia si aplica).",
                            Criterio = "Crítico",
                            Capitulo="416",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=48,
                            Titulo = "Los suministros eléctricos, de iluminación y de ventilación son adecuados",
                            Criterio = "Crítico",
                            Capitulo="417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=49,
                            Titulo = "El establecimiento dispone de áreas para alimentación separadas de los productos.",
                            Criterio = "Mayor",
                            Capitulo="418",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=50,
                            Titulo = "Cuentan con vestidores separados del área del almacén",
                            Criterio = "Mayor",
                            Capitulo="418",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=51,
                            Titulo = "Baños con lavamanos, jabón, papel toalla, espejo.  Separados del área del almacén",
                            Criterio = "Crítico",
                            Capitulo="418",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=52,
                             Titulo = "El establecimiento dispone de áreas destinadas exclusivamente al almacenamiento de materiales y productos para la limpieza.  ",
                            Criterio = "Menor",
                            Capitulo="418, 426",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=53,
                            Titulo = "El establecimiento cuenta con un programa para el manejo de los desperdicios que se generen diariamente",
                            Criterio = "Mayor",
                            Capitulo="437 417",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=54,
                             Titulo = "Cuentan con kits para contención de derrames de productos que por su naturaleza presentan peligro para el personal",
                            Criterio = "Mayor",
                            Capitulo="418",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.2. Área de Recepción y Despacho",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=55,
                            Titulo = "El área de recepción de productos está ubicada en áreas protegidas de las inclemencias de tiempos.",
                            Criterio = "Crítico",
                            Capitulo="419, 428",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=56,
                            Titulo = "El área de recepción está organizada",
                            Criterio = "Mayor",
                            Capitulo="420, 423, 429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=57,
                            Titulo = "El área de recepción está identificada ",
                            Criterio = "Mayor",
                            Capitulo="420, 423, 429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=58,
                            Titulo = "El área de recepción está delimitada",
                            Criterio = "Mayor",
                            Capitulo="419, 423, 429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=59,
                            Titulo = "El área de recepción de productos cuenta con rampa para descarga de materiales.  Cuando aplique",
                            Criterio = "Menor",
                            Capitulo="419, 428",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=60,
                            Titulo = "El área de recepción de productos está diseñada y equipada para permitir la limpieza de los productos, si fuese necesaria antes del almacenamiento",
                            Criterio = "Mayor",
                            Capitulo="419, 428",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=61,
                            Titulo = "El área de recepción de productos se mantiene limpia, ordenada y libre de materiales extraños",
                            Criterio = "Mayor",
                            Capitulo="420, 429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=62,
                            Titulo = "Los productos en proceso de recepción están colocados sobre tarimas u otro mobiliario",
                            Criterio = "Mayor",
                            Capitulo="421, 430",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=63,
                            Titulo = "Los productos en proceso de recepción están colocados separados del techo",
                            Criterio = "Mayor",
                            Capitulo="421, 430",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=64,
                            Titulo = "Los productos en proceso de recepción están colocados de tal forma que facilita el mantenimiento y limpieza del área",
                            Criterio = "Menor",
                            Capitulo="421, 430",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=65,
                            Titulo = "Los productos que ingresan al establecimiento farmacéutico luego que se autoriza su importación cumplen con los requisitos descritos en los documentos presentados (facturas, certificados de análisis, liquidaciones).",
                            Criterio = "Mayor",
                            Capitulo="",
                            Articulo="Ley No. 1 art 86",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=66,
                            Titulo = "El Establecimiento Farmacéutico presenta evidencias de que supervisa o verifica que el producto cumple con las especificaciones consignadas en el certificado de Registro Sanitario expedido por la Dirección Nacional de Farmacia y Drogas.",
                            Criterio = "Mayor",
                            Capitulo="",
                            Articulo="Ley No. 1 art 89",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=67,
                            Titulo = "Se identifican los productos en estatus de Cuarentena ",
                            Criterio = "Mayor",
                            Capitulo="422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=68,
                            Titulo = "Se da prioridad de ingreso a productos controlados o que requieren cadena de frío",
                            Criterio = "Crítico",
                            Capitulo="422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=69,
                            Titulo = "En caso de productos de cadena de frío, se revisan los datos de temperatura del transporte para asegurarse que se han mantenido las condiciones requeridas",
                            Criterio = "Crítico",
                            Capitulo="422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=70,
                            Titulo = "Al ingresar materia prima se verifica el certificado de análisis del fabricante ",
                            Criterio = "Crítico",
                            Capitulo="422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=71,
                            Titulo = "Si la materia prima no tiene el certificado de análisis del fabricante, el importador realiza los análisis correspondientes",
                            Criterio = "Crítico",
                            Capitulo="422",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=72,
                            Titulo = "Debe existir una efectiva separación entre las áreas de recepción y despacho que permita su individualización, de modo que se eviten confusiones.",
                            Criterio = "Mayor",
                            Capitulo="431",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=73,
                            Titulo = "El área de despacho está identificada ",
                            Criterio = "Menor",
                            Capitulo="423, 429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=74,
                            Titulo = "El área de despacho está delimitada",
                            Criterio = "Mayor",
                            Capitulo="423, 429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=75,
                            Titulo = "El área de despacho de productos está ubicada en áreas protegidas de las inclemencias de tiempos",
                            Criterio = "Crítico",
                            Capitulo="428",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=76,
                            Titulo = "El área de despacho de productos cuenta con rampa para la carga de materiales.  Cuando aplique.",
                            Criterio = "Menor",
                            Capitulo="428",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=77,
                            Titulo = "El área de despacho de productos se mantiene limpia, ordenada y libre de materiales extraños",
                            Criterio = "Mayor",
                            Capitulo="429",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=78,
                            Titulo = "Los productos dispuestos para el despacho están colocados sobre tarimas u otro mobiliario",
                            Criterio = "Mayor",
                            Capitulo="421, 430",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=79,
                            Titulo = "Los productos dispuestos para el despacho están colocados de tal forma que facilita el mantenimiento y limpieza del área",
                            Criterio = "Menor",
                            Capitulo="421",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.3. Área de Almacén",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=80,
                             Titulo = "El área de almacenamiento cuenta con las siguientes características:",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=81,
                            Titulo = "identificada",
                            Criterio = "Mayor",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=82,
                             Titulo = "organizada",
                            Criterio = "Mayor",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=83,
                             Titulo = "limpia",
                            Criterio = "Crítico",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=84,
                             Titulo = "delimitada",
                            Criterio = "Crítico",
                            Capitulo="423, 424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=85,
                           Titulo = "seca",
                            Criterio = "Mayor",
                            Capitulo="423, 424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=86,
                            Titulo = "superficies de fácil limpieza sin roturas y/o desprendimiento de polvo",
                            Criterio = "Crítico",
                            Capitulo="417, 423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=87,
                            Titulo = "El establecimiento utiliza el sistema FIFO/FEFO para el almacenamiento",
                            Criterio = "Mayor",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=88,
                            Titulo = "Se identifican los rangos permitidos de Temperatura y Humedad Relativa. En caso afirmativo agregar dichos valores en las observaciones.",
                            Criterio = "Crítico",
                            Capitulo="423, 424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=89,
                            Titulo = "Se mantienen controles de temperatura y humedad ",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=90,
                             Titulo = "Se registran los controles cronológicos de temperatura y humedad en el área. ",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=91,
                            Titulo = "El establecimiento ha realizado mapeo de temperatura",
                            Criterio = "Mayor",
                            Capitulo="424, 453",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=92,
                            Titulo = "La temperatura de las áreas de almacenamiento y frigoríficos es monitoreada por equipos registradores calibrados",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=93,
                            Titulo = "La calibración de los equipos se realiza al menos una vez al año",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=94,
                            Titulo = "Los registros de temperatura son verificados por personal responsable mínimo 3 veces al día",
                            Criterio = "Mayor",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=95,
                             Titulo = "El área de almacenamiento con temperatura controlada posee sistema de alarma",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=96,
                             Titulo = "En caso de falla en el sistema de alarma se verifica diariamente los registros de temperaturas máximas y mínimas, hasta que se restablezca el sistema.",
                            Criterio = "Mayor",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=97,
                            Titulo = "Se investigan las desviaciones de los parámetros establecidos de temperatura y humedad relativa, y se registra la subsanación",
                            Criterio = "Mayor",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=98,
                            Titulo = "En las áreas de almacenamiento está prohibido fumar, comer, guardar comidas o cualquier otro objeto que pueda afectar la calidad de los productos.",
                            Criterio = "Crítico",
                            Capitulo="418",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=99,
                            Titulo = "El establecimiento implementa medidas a fin de controlar que el personal cumpla con estas prohibiciones",
                            Criterio = "Mayor",
                            Capitulo="418",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=100,
                             Titulo = "Las áreas de almacenamiento son exclusivamente para el almacenaje de medicamentos y otros productos para la salud humana, y estos no están mezclados o juntos con otros productos (alimentos, hidrocarburos, plaguicidas, otros) que pudieran afectar adversamente a los mismos.",
                            Criterio = "Crítico",
                            Capitulo="426",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=101,
                            Titulo = "El establecimiento cuenta con señalización de rutas de evacuación.",
                            Criterio = "Mayor",
                            Capitulo="411",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=102,
                             Titulo = "El área permite el almacenamiento ordenado de los productos, facilita el manejo y circulación del personal en el área.",
                            Criterio = "Crítico",
                            Capitulo="414, 418, 424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                         Numero=103,
                              Titulo = "Las áreas de almacenamiento están organizadas, identificadas y delimitadas.",
                            Criterio = "Mayor",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                          Numero=104,
                             Titulo = "Las áreas de almacenamiento están limpias",
                            Criterio = "Crítico",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=105,
                            Titulo = "Las áreas de almacenamiento están secas",
                            Criterio = "Crítico",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=106,
                            Titulo = "Las áreas de almacenamiento están dentro de los límites de temperatura y humedad relativa que estipula el laboratorio fabricante para los productos farmacéuticos. En caso afirmativo agregar dichos valores en las observaciones.",
                            Criterio = "Crítico",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=107,
                            Titulo = "Se identifican los rangos permitidos de Temperatura y Humedad Relativa. En caso afirmativo agregar dichos valores en las observaciones.",
                            Criterio = "Mayor",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=108,
                            Titulo = "Existen etiquetas que demuestran la vigencia de la calibración de los instrumentos para el monitoreo de la T° y HR del área de almacenamiento.",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=109,
                            Titulo = "El establecimiento farmacéutico utiliza un sistema interno de codificación que permita la localización de los productos del fabricante en el mercado",
                            Criterio = "Crítico",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=110,
                            Titulo = "Todos los productos se encuentran almacenados sobre tarimas, armarrápidos, andamios y las condiciones de estos son apropiados    ",
                            Criterio = "Crítico",
                            Capitulo="414, 421",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=111,
                            Titulo = "Los productos farmacéuticos y otros productos para la salud humana están estibados o acomodados manteniendo un pie de distancia de las paredes y separadas del techo.      ",
                            Criterio = "Mayor",
                            Capitulo="414, 421",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                          Titulo = "2.4. Almacenamiento de Productos de Cadena de Frío.  Cuando aplique.",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=112,
                            Titulo = "Existen áreas destinadas al almacenamiento de productos de cadena de frío.",
                            Criterio = "Crítico",
                            Capitulo="424, 425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=113,
                            Titulo = "Las áreas destinadas al almacenamiento de productos de cadena de frío están claramente identificadas.  ",
                            Criterio = "Mayor",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=114,
                            Titulo = "Se registran controles cronológicos de la temperatura en el área de refrigeración. ",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=115,
                           Titulo = "Existen etiquetas que demuestran la vigencia de la calibración de los instrumentos del área de refrigeración.",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=116,
                            Titulo = "Cuentan con el equipo necesario para la conservación de la temperatura de este tipo de productos.",
                            Criterio = "Crítico",
                            Capitulo="424, 425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=117,
                           Titulo = "Los equipos cuentan con espacio suficiente para almacenamiento ordenado y seguro y permite la circulación de aire entre los productos",
                            Criterio = "Mayor",
                            Capitulo="425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=118,
                            Titulo = "Al personal que labora en el cuarto frío se le dota de equipo necesario para sus labores.",
                            Criterio = "Crítico",
                            Capitulo="411",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=119,
                            Titulo = "Cuenta con sistema de respaldo en caso de falta de fluido eléctrico.",
                            Criterio = "Crítico",
                            Capitulo="417, 425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=120,
                            Titulo = "Se evita la sobrecarga de energía eléctrica",
                            Criterio = "Crítico",
                            Capitulo="425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=121,
                            Titulo = "Los equipos frigoríficos destinados al almacenamiento de productos farmacéuticos son de uso exclusivo, se mantienen secos y en estrictas condiciones de higiene.",
                            Criterio = "Crítico",
                            Capitulo="425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=122,
                            Titulo = "Cuenta con el área y materiales apropiados para la preparación de pedidos que requieran cadena de frío.",
                            Criterio = "Mayor",
                            Capitulo="425",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.5. Almacenamiento de Estupefacientes o psicotrópicos.  Cuando aplique. ",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=123,
                           Titulo = "Dentro del almacén existe un área delimitada e identificada para el almacenamiento de sustancias controladas",
                            Criterio = "Crítico",
                            Capitulo="50",
                            Articulo="Ley 14 Art. 16",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=124,
                            Titulo = "Esta área permanece bajo llave y la misma está bajo la responsabilidad del Regente Farmacéutico.",
                            Criterio = "Crítico",
                            Capitulo="80, 81, 82",
                            Articulo="Ley 14 Art. 16",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=125,
                            Titulo = "Todas las sustancias controladas están colocadas en el área destinada para tal fin. ",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 14 Art. 30",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=126,
                           Titulo = "Se mantiene un registro para el manejo de las sustancias controladas.",
                            Criterio = "Crítico",
                            Capitulo="50",
                            Articulo="Ley 14 Art. 12, 30-32",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=127,
                            Titulo = "Se lleva un registro de las sustancias controladas que se van a destruir.",
                            Criterio = "Mayor",
                            Capitulo="49, 62",
                            Articulo="Ley 14 Art. 12, 30-32",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=128,
                            Titulo = "Las sustancias controladas que se encuentran almacenadas poseen registro sanitario o en situaciones excepcionales han sido autorizadas por DNFD.",
                            Criterio = "Crítico",
                            Capitulo="11",
                            Articulo="Ley 1 Art. 40",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=129,
                            Titulo = "Durante la inspección se observan vales de sustancias controladas, estos se encuentran o están totalmente en blanco, pero firmados por el regente.",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 14 Art. 31",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=130,
                           Titulo = "Las cantidades físicas de las sustancias controladas que se encuentran en el establecimiento en comparación con los registros (libros o sistemas automatizados), coinciden.",
                            Criterio = "Crítico",
                            Capitulo="33",
                            Articulo="Ley 14 Art. 31",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=131,
                             Titulo = "El establecimiento cumple con la prohibición de alguna forma de publicidad y propaganda acerca de las sustancias controladas.",
                            Criterio = "Mayor",
                            Capitulo="",
                            Articulo="Ley 14 Art. 52",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=132,
                             Titulo = "El establecimiento cumple con la prohibición del manejo de muestras médicas de productos con contenido psicotrópico y estupefaciente.",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 14 Art. 26",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.6. Productos inflamables",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=133,
                             Titulo = "Dentro del almacén existe un área separada e identificada para el almacenamiento de sustancias o productos inflamables. ",
                            Criterio = "Crítico",
                            Capitulo="427",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=134,
                             Titulo = "El área cuenta con kit de derrame y control de incendios",
                            Criterio = "Crítico",
                            Capitulo="427",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=135,
                             Titulo = "El almacén para inflamables cuenta con equipo e implementos para la prevención de incendios.",
                            Criterio = "Crítico",
                            Capitulo="427",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=136,
                             Titulo = "El área debe contar con adecuada ventilación, que impida la concentración de olores.",
                            Criterio = "Crítico",
                            Capitulo="427",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.7. Plaguicidas",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=137,
                             Titulo = "Se almacenan en áreas separadas, segregadas, delimitadas e identificadas",
                            Criterio = "Crítico",
                            Capitulo="200, 426",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=138,
                             Titulo = "Los Plaguicidas de uso doméstico y de salud pública se almacenan de manera que no contaminan los productos farmacéuticos y se almacenan sobre tarimas y el área está ventilada",
                            Criterio = "",
                            Capitulo="199, 426",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.8. Cosméticos",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=139,
                             Titulo = "La siguiente información obligatoria está incluida en las etiquetas de los productos cosméticos, tanto en la etiqueta del empaque primario o del secundario, de tenerlo: \r\n-Nombre del producto.\r\n-Contenido en peso o volumen. \r\n-Nombre del fabricante o distribuidor. \r\n-País de origen (puede estar incluido en el N° de lote)\r\n-Número de lote. \r\n-Condiciones de almacenamiento (si se requieren). \r\n-Información de seguridad o representación gráfica de uso del producto, conforme aplique.\r\n",
                            Criterio = "Mayor",
                            Capitulo="237, 240",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                          Numero=140,
                             Titulo = "Uno de los idiomas de la información de la etiqueta, es español o inglés (verificar aleatoriamente)",
                            Criterio = "Crítico",
                            Capitulo="236",
                            Articulo="Ley N° 1 Art. 32",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                          Numero=141,
                            Titulo = "Los productos cosméticos solo declaran propiedades comprobables y autorizadas en el Registro Sanitario.",
                            Criterio = "Crítico",
                            Capitulo="241",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.9. Materia prima para la fabricación de productos regulados por la Dirección Nacional de Farmacia y Drogas",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=142,
                           Titulo = "Maneja materia prima para la fabricación de productos regulados por la Dirección Nacional de Farmacia y Drogas",
                            Criterio = "Informativo",
                            Capitulo="386",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=143,
                          Titulo = "Todas las materias primas que maneja el establecimiento y que son empleadas en la industria de medicamentos, cosméticos, desinfectantes, plaguicidas u otros productos regulados por la Dirección Nacional de Farmacia y Drogas, cuentan con su certificado de inscripción vigente.",
                            Criterio = "Crítico",
                            Capitulo="601, 386",
                            Articulo="Ley N° 1 Art. 78",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=144,
                           Titulo = "Dentro del almacén existe un área delimitada e identificada para el almacenamiento de materias primas  ",
                            Criterio = "Mayor",
                            Capitulo="401, 423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                          Numero=145,
                           Titulo = "El almacén de materias primas reúne las condiciones adecuadas para el almacenamiento de este tipo de sustancias",
                            Criterio = "Crítico",
                            Capitulo="414, 417, 424",
                            Articulo="Ley N° 1 Art. 67",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.10. Productos retirados del mercado",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=146,
                           Titulo = "En el establecimiento farmacéutico los productos retirados del mercado están almacenados separadamente en un área segura e identificada.",
                            Criterio = "Crítico",
                            Capitulo="432",
                            Articulo="Ley N° 1 Art. 73",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=147,
                           Titulo = "Se lleva un registro de los productos retirados del mercado que se van a destruir",
                            Criterio = "Mayor",
                            Capitulo="432",
                            Articulo="Ley N° 1 Art. 67",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=148,
                          Titulo = "Existen registros de distribución accesibles a la(s) persona(s) responsables del retiro de los productos.",
                            Criterio = "Mayor",
                            Capitulo="460",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=149,
                           Titulo = "Se registran los avances del proceso de retiro de productos.",
                            Criterio = "Mayor",
                            Capitulo="461",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=150,
                           Titulo = "Se elabora un informe final de los productos retirados del mercado en el que se incluya un balance entre las cantidades de los productos entregados y los recuperados.",
                            Criterio = "Mayor",
                            Capitulo="461",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=151,
                           Titulo = "2.11. Productos devueltos del mercado",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=152,
                            Titulo = "En el establecimiento farmacéutico los productos devueltos y retirados del mercado están almacenados separadamente en un área delimitada e identificada",
                            Criterio = "Crítico",
                            Capitulo="433",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=153,
                            Titulo = "Cuenta con procedimientos que establezcan que todo producto que se haya devuelto a las instalaciones del distribuidor solo podrá ser distribuido nuevamente si se confirma que: \r\n1. El producto reúna todas las condiciones legales para su comercialización. \r\n2. El motivo de la devolución se encuentra registrado y sustentado. \r\n3. El empaque del producto no esté deteriorado, no se encuentra vencido, ni ha sido sujeto a retiro de mercado, prohibición, sanción de la Autoridad, etc. 4. En el caso de tratarse de productos de cadena de frío debe asegurarse, mediante documentación y registros emitidos por equipos registradores de temperatura calibrados, que el producto se ha conservado dentro de los límites aceptables de temperatura establecidos por el fabricante, en todo momento. \r\n5. En el caso de tratarse de sustancias controladas debe asegurarse, mediante documentación y registros, que el producto ha conservado toda la trazabilidad de los controles que aplican para este tipo de productos. \r\n6. Para todos los casos debe asegurarse, mediante documentación y registros, que el producto se ha conservado dentro de los límites aceptables de temperatura y humedad relativa establecidos por el fabricante, de acuerdo con su condición, en todo momento.\r\n",
                            Criterio = "Crítico",
                            Capitulo="403",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=154,
                            Titulo = "Se lleva un registro de los productos que se van a destruir o reexportar",
                            Criterio = "Crítico",
                            Capitulo="435, 438",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=155,
                            Titulo = "El establecimiento farmacéutico cuenta con procedimientos que orienten el manejo de la disposición final de desechos farmacéuticos.",
                            Criterio = "Mayor",
                            Capitulo="403",
                            Articulo="D.E. 249 Art. 6",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=156,
                           Titulo = "Se lleva un registro de los procesos de destrucción ya realizados, incluyendo productos en ensayos clínicos.",
                            Criterio = "Crítico",
                            Capitulo="432, 435, 438",
                            Articulo="Ley N° 1 Art. 67, D.E. 249 Art. 6 ",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "2.12. Productos Falsificados o Ilícitos",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=157,
                            Titulo = "Cuentan con procedimientos que establezca que en caso de que se sospeche o se conozca de productos falsificados o ilícitos, informan inmediatamente a la Dirección Nacional de Farmacia y Drogas.",
                            Criterio = "Crítico",
                            Capitulo="436",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=158,
                            Titulo = "El procedimiento incluye la instrucción que se debe colocar y almacenar en una zona controlada y apartada de los demás productos y confeccionar un informe con los datos y cantidades del producto presuntamente falsificado o ilícito.",
                            Criterio = "Crítico",
                            Capitulo="436",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                }

            };
        }
        public void Inicializa_Distribucion()
        {
            Distribucion = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                        {
                            Titulo = "3.1. Especificaciones para Productos a Distribuir",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=159,
                           Titulo = "Las etiquetas o rótulos, que se colocan en los envases están claros (legible, limpios).  No se observa Re etiquetado o sobre etiquetado",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 1 Art. 32",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=160,
                            Titulo = "Las etiquetas o rótulos de los productos cumplen con las normas de etiquetado y con lo establecido en el Certificado de Registro Sanitario, incluyendo lote y fecha de vencimiento.\r\n\r\n",
                            Criterio = "Crítico",
                            Capitulo="34, 439",
                            Articulo="Ley 1 Art. 172 numeral 4",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=161,
                            Titulo = "Los productos que maneja el establecimiento se encuentran con fecha de vencimiento vigente.",
                            Criterio = "Crítico",
                            Capitulo="439",
                            Articulo="Ley 1 Art. 172 numeral 4",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=162,
                            Titulo = "Los envases comerciales tienen una etiqueta adherida con el nombre de la empresa distribuidora de los productos, antes de su comercialización",
                            Criterio = "Mayor",
                            Capitulo="",
                            Articulo="Ley 1 Art. 72",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=163,
                            Titulo = "El establecimiento maneja muestras médicas y/o muestras gratuitas aprobadas por la Dirección Nacional de Farmacia y Drogas.",
                            Criterio = "Crítico",
                            Capitulo="669",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=164,
                            Titulo = "Las muestras médicas promocionales corresponden a productos farmacéuticos que posean Registro Sanitario en el país",
                            Criterio = "Crítico",
                            Capitulo="670",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=165,
                            Titulo = "Las muestras médicas promocionales señalan la leyenda “Muestra médica, prohibida su venta” o frase similar",
                            Criterio = "Mayor",
                            Capitulo="41, 667",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=166,
                            Titulo = "Las muestras gratuitas de los productos cosméticos que tienen carácter promocional indican “Prohibida su venta” y que es “Muestra gratuita” o similar",
                            Criterio = "Mayor",
                            Capitulo="239",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=167,
                             Titulo = "Cumple el establecimiento con la prohibición de poseer productos farmacéuticos de procedencia injustificada",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 1 Art. 172, numeral 7 Ley 14 Art. 31, numeral 4 ",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "3.2. Registros de Distribución",
                            Criterio = "",
                            Capitulo="",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                            IsHeader=true,
                        },
                    new ContenidoPreguntas()
                        {
                            Numero=168,
                           Titulo = "Dispone de un sistema interno de codificación que permita la localización de los productos en el mercado.",
                            Criterio = "Crítico",
                            Capitulo="423",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                           Numero=169,
                            Titulo = "Presenta las evidencias de que el establecimiento farmacéutico distribuye productos a establecimientos que están debidamente autorizados por la Dirección Nacional de Farmacia y Drogas.",
                            Criterio = "Crítico",
                            Capitulo="",
                            Articulo="Ley 24 Art. 29",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                }

            };
        }
        public void Inicializa_TransProdFarmaceuticos()
        {
            TransProdFarmaceuticos = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                        {
                            Numero=170,
                           Titulo = "El establecimiento cuenta con un procedimiento para el transporte de los productos, que incluya el investigar y corregir las desviaciones de temperatura y otros parámetros que puedan afectar la calidad del producto",
                            Criterio = "Crítico",
                            Capitulo="403, 443, 444",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=171,
                           Titulo = "El procedimiento para el transporte de los productos farmacéuticos incluye la prohibición del traslado de medicamentos y otros productos para la salud humana, en conjunto con plaguicidas de cualquier tipo o productos químicos de toxicidad comprobada",
                            Criterio = "Crítico",
                            Capitulo="444",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                             Numero=172,
                            Titulo = "El procedimiento para el transporte de los productos farmacéuticos incluye medidas para evitar que personas no autorizadas ingresen y/o manipulen los vehículos y/o equipos",
                            Criterio = "Mayor",
                            Capitulo="442, 444",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=173,
                           Titulo = "Los vehículos empleados en el traslado de los productos farmacéuticos cumplen con condiciones adecuadas para el traslado de los productos, incluyendo un sistema que permita verificar los parámetros de temperatura y humedad relativa",
                            Criterio = "Crítico",
                            Capitulo="442",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=174,
                           Titulo = "Los vehículos empleados en el traslado de los Productos radioactivos, sustancias peligrosas que presentan riesgos especiales de incendio o explosión (por ejemplo, líquidos combustibles, sólidos y gases a presión) son transportados cumpliendo con la normativa de la autoridad competente.",
                            Criterio = "Crítico",
                            Capitulo="112, 452",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=175,
                           Titulo = "En caso de que el transporte sea realizado por terceros, existe un contrato que detalle los deberes y responsabilidades del contratista y contratante. ",
                            Criterio = "Crítico",
                            Capitulo="448",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=176,
                           Titulo = "El contratante verifica que el transporte cumpla con los requisitos establecidos en la normativa.",
                            Criterio = "Mayor",
                            Capitulo="448",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=177,
                           Titulo = "Los vehículos tienen una capacidad suficiente para permitir un almacenamiento de las diversas categorías de productos farmacéuticos durante su transporte",
                            Criterio = "Crítico",
                            Capitulo="443",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=178,
                           Titulo = "Existen registros que permitan evidenciar que los vehículos para el traslado de productos mantienen los parámetros de temperatura y humedad relativa.  ",
                            Criterio = "Crítico",
                            Capitulo="442, 449",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=179,
                           Titulo = "Los vehículos empleados en el traslado de los productos farmacéuticos están protegidos de la luz directa, según las especificaciones estipuladas por el fabricante. ",
                            Criterio = "Crítico",
                            Capitulo="445, 449",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=180,
                           Titulo = "Los vehículos empleados en el traslado de los productos farmacéuticos están limpios",
                            Criterio = "Crítico",
                            Capitulo="443",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=181,
                            Titulo = "Los bultos que contienen productos farmacéuticos se colocan sobre tarimas, estibados y asegurados correctamente dentro de los vehículos.",
                            Criterio = "Mayor",
                            Capitulo="444",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=182,
                           Titulo = "La ubicación de los productos farmacéuticos dentro de los vehículos se hace respetando las indicaciones de manejo detalladas en cada caja por el laboratorio fabricante (ejemplo: flechas que indican el sentido en que debe colocarse la caja, frágil, protéjase de la lluvia, etc.) y cualquier otra información sobre las condiciones de almacenamiento ",
                            Criterio = "Mayor",
                            Capitulo="444",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=183,
                           Titulo = "Los productos farmacéuticos que requieren de refrigeración son trasladados considerando las medidas específicas para hacerlo, sin romper la cadena de frío. ",
                            Criterio = "Crítico",
                            Capitulo="444",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                              Numero=184,
                            Titulo = "Cuentan con el equipo necesario para el almacenamiento y transporte de este tipo de productos (coolers, paquete de gel, termómetros portátiles)",
                            Criterio = "Crítico",
                            Capitulo="424",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=185,
                           Titulo = "Los productos farmacéuticos retirados durante el tránsito son separados, empaquetados de manera segura y claramente etiquetados.",
                            Criterio = "Crítico",
                            Capitulo="432, 443, 449",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=186,
                           Titulo = "Cuenta con procedimientos escritos para el funcionamiento y el mantenimiento de todos los vehículos",
                            Criterio = "Crítico",
                            Capitulo="446",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=187,
                           Titulo = "El equipo utilizado para vigilar la temperatura durante el transporte se somete a mantenimiento y calibración, al menos una vez al año.",
                            Criterio = "Crítico",
                            Capitulo="447",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=188,
                           Titulo = "Los vehículos motorizados están identificados como transporte de medicamentos y otros productos para la salud humana.   \r\nSe acepta la identificación con el nombre de la empresa que cuente con licencia de operación ante la Dirección Nacional de Farmacia y Drogas.\r\n",
                            Criterio = "Mayor",
                            Capitulo="450",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=189,
                           Titulo = "El embalaje mantiene la temperatura y humedad establecida por el fabricante y es monitoreada y registrada al momento de la preparación y entrega del pedido.   Existen registro que evidencien esta actividad.",
                            Criterio = "Crítico",
                            Capitulo="450",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                               Numero=190,
                           Titulo = "Los contenedores están en buen estado y ofrecen una protección adecuada contra las influencias externas, incluida la contaminación.",
                            Criterio = "Crítico",
                            Capitulo="451",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=191,
                            Titulo = "Los contenedores deben llevar etiquetas sobre:\r\n-condiciones de manejo y almacenamiento,\r\nprecauciones \r\n",
                            Criterio = "Mayor",
                            Capitulo="451",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=192,
                            Titulo = "Los contenedores deben hacer posible identificar su contenido y su origen",
                            Criterio = "Mayor",
                            Capitulo="451",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=193,
                           Titulo = "El establecimiento verifica que el transporte de los medicamentos que requieran condiciones especiales, como las de estupefacientes o las sustancias psicotrópicas, es seguro.",
                            Criterio = "Crítico",
                            Capitulo="452",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=194,
                            Titulo = "Para los medicamentos termolábiles utilizan equipos cualificados (por ejemplo, embalajes térmicos y contenedores y vehículos con control de temperatura).",
                            Criterio = "Crítico",
                            Capitulo="453",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=195,
                            Titulo = "La calibración de los equipos para el control de la temperatura se realiza al menos una vez al año.",
                            Criterio = "Crítico",
                            Capitulo="453",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=196,
                            Titulo = "Existen registro que evidencia que se ha realizado mapeo de temperaturas.",
                            Criterio = "Mayor",
                            Capitulo="453",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=197,
                           Titulo = "Cuenta con procedimiento que establece las medidas a tomar si hay desviaciones de la temperatura que puedan afectar el medicamento",
                            Criterio = "Crítico",
                            Capitulo="453",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=198,
                            Titulo = "Se le facilita al cliente información que demuestra que se ha cumplido con las condiciones de temperatura de almacenamiento de los medicamentos",
                            Criterio = "Crítico",
                            Capitulo="454",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                Numero=199,
                            Titulo = "Cuentan con procedimiento sobre montaje de las cajas aislantes y la reutilización de los paquetes refrigerantes",
                            Criterio = "Mayor",
                            Capitulo="454",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=200,
                           Titulo = "El personal recibe capacitación sobre los procedimientos de montaje de las cajas aislantes y la reutilización de los paquetes refrigerantes",
                            Criterio = "Crítico",
                            Capitulo="454",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=201,
                            Titulo = "Existe control en la reutilización de los paquetes refrigerantes con el fin de evitar que se utilicen paquetes que no estén completamente refrigerados",
                            Criterio = "Crítico",
                            Capitulo="454",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                }

            };
        }
        public void Inicializa_AutoInspec()
        {
            AutoInspec = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                        {
                                 Numero=202,
                            Titulo = "El establecimiento cuenta con un procedimiento para la realización de autoinspecciones",
                            Criterio = "Mayor",
                            Capitulo="463",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=203,
                            Titulo = "El establecimiento farmacéutico tiene registrado la frecuencia con la que se realiza la autoinspección (mínimo una vez al año).",
                            Criterio = "Mayor",
                            Capitulo="463",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                  Numero=204,
                           Titulo = "Presentan evidencias de reportes realizados de las autoinspecciones. ",
                            Criterio = "Crítico",
                            Capitulo="464",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=205,
                            Titulo = "El reporte de autoinspección incluye:\r\n-resultados\r\n-evaluación y conclusiones\r\n-acciones correctivas con sus plazos de cumplimiento\r\n",
                            Criterio = "Crítico",
                            Capitulo="464",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                    new ContenidoPreguntas()
                        {
                                 Numero=206,
                            Titulo = "El establecimiento farmacéutico ha coordinado con la Dirección Nacional de Farmacia y Drogas alguna inspección oficial.",
                            Criterio = "Crítico",
                            Capitulo="469",
                            Articulo="",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                }

            };
        }


    }
}
