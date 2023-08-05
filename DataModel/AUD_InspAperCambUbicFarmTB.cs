using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class AUD_InspAperCambUbicFarmTB : SystemId
	{       
       
        private AUD_InspeccionTB inspeccion;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Datos del Solicitante
        private AUD_DatosSolicitante datosSolicitante;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosSolicitante DatosSolicitante { get => datosSolicitante; set => SetProperty(ref datosSolicitante, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos del Regente
        private AUD_Horarios horariosAtencion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_Horarios HorariosAtencion { get => horariosAtencion; set => SetProperty(ref horariosAtencion, value); }

        //Datos Estructura Organizacional
        private AUD_ContenidoGenerico datosEstructuraOrganizacional;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosEstructuraOrganizacional { get => datosEstructuraOrganizacional; set => SetProperty(ref datosEstructuraOrganizacional, value); }

        //Datos Infraestructura
        private AUD_ContenidoGenerico datosInfraEstructura;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosInfraEstructura { get => datosInfraEstructura; set => SetProperty(ref datosInfraEstructura, value); }

        //Datos Area Física
        private AUD_ContenidoGenerico datosAreaFisica;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosAreaFisica { get => datosAreaFisica; set => SetProperty(ref datosAreaFisica, value); }

        //Datos Preguntas Genericas
        private AUD_ContenidoGenerico datosPreguntasGenericas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosPreguntasGenericas { get => datosPreguntasGenericas; set => SetProperty(ref datosPreguntasGenericas, value); }

        //Datos Area Productos Controlados
        private AUD_ContenidoGenerico datosAreaProductosControlados;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosAreaProductosControlados { get => datosAreaProductosControlados; set => SetProperty(ref datosAreaProductosControlados, value); }

        //Datos Area Almacenamiento
        private AUD_ContenidoGenerico datosAreaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosAreaAlmacenamiento { get => datosAreaAlmacenamiento; set => SetProperty(ref datosAreaAlmacenamiento, value); }
        
        //Datos Area Almacenamiento
        private AUD_ContenidoGenerico datosAreaAlmacenamientoAlcohol;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DatosAreaAlmacenamientoAlcohol { get => datosAreaAlmacenamientoAlcohol; set => SetProperty(ref datosAreaAlmacenamientoAlcohol, value); }


        public void Inicializa_DatosEstructuraOrganizacional()
        {
            DatosEstructuraOrganizacional = new AUD_ContenidoGenerico();
            DatosEstructuraOrganizacional.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de su letrero de identificación visible al público",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        Observaciones = "Este ítem es de valor informativo."
                    },
                    //    new ContenidoPreguntas(){
                    //    Titulo = "El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022",
                    //    IsHeader = true,
                    //},
             };
        }

        public void Inicializa_DatosInfraEstructura()
        {
            DatosInfraEstructura = new AUD_ContenidoGenerico();
            DatosInfraEstructura.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Paredes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado de las Paredes",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Cielo Raso",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado del Cielo Raso",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Pisos",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado del Piso",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación? De ser sí Por qué?.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }

        public void Inicializa_DatosAreaFisica()
        {
            DatosAreaFisica = new AUD_ContenidoGenerico();
            DatosAreaFisica.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Mobiliario de medicamentos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Mobiliario",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado del Mobiliario",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Muebles separados de las paredes, pisos, y techos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }

        public void Inicializa_DatosPreguntasGenericas()
        {
            DatosPreguntasGenericas = new AUD_ContenidoGenerico();
            DatosPreguntasGenericas.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible frente al recetario con la siguiente instrucción: “El usuario que adquiera un medicamento de los regulados que se venden sin receta médica lo hace bajo su responsabilidad”. Art. 151 de la Ley 1 de 10 de enero de 2001 y Art. 625 del Decreto Ejecutivo 13 del 1 de marzo de 2023.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. \"Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible frente al recetario con la siguiente información: “Por su salud, consulte al farmacéutico sobre el uso adecuado de los medicamentos, especialmente los que presenta la leyenda venta bajo receta médica o frase similar”. Art. 625 del Decreto Ejecutivo 13 del 1 de marzo de 2023.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "Anuncio visible de Prohibido el ingreso de animales.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "Anuncio visible de Prohibido Fumar.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "La farmacia cuenta con equipos para llevar el control de temperatura y humedad relativa.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "Cuenta con formato para el registro diario de temperatura y humedad relativa. El registro y control diario de los parámetros debe ser como mínimo dos veces al día, de preferencia en horas de la mañana y medio día.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Temperatura",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() { HideEvaluacion=true} },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Humedad Relativa",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() { HideEvaluacion=true} },
                    },
                    //new ContenidoPreguntas(){
                    //    Titulo = "Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa",
                    //        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                    new ContenidoPreguntas(){
                        Titulo = "El establecimiento cuenta con espacio que permita realizar adecuada y cómodamente las labores al personal según aspectos biopsicosocial.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área separada para la ingesta de alimentos del personal. Si la farmacia está ubicada en locales comerciales o similares será permitido el uso de estos en áreas comunes.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con baño higiénico adecuado para uso del personal. Si la farmacia está ubicada en locales comerciales o similares será permitido el uso de estos en áreas comunes.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Aire acondicionado para mantener las condiciones de almacenamiento.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Extintores contra incendios",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Alarmas contra incendios o detector de humo.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Lámpara de emergencia en lugares adecuados para la seguridad del personal y clientes.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    //new ContenidoPreguntas(){
                    //    Titulo = "La farmacia debe contar con un programa de mantenimiento preventivo que incluya cualquier desperfecto o condiciones no adecuadas de las estructuras",
                    //       IsHeader=true,
                    //},
                    new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva y documento que respalde esta",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de Asesoría Farmacéutica delimitada e identificada que permita la interacción privada entre farmacéutico y paciente",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de Consultas bibliográficas Física",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de Consultas bibliográficas Electrónica",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área identificada, separada y delimitada para los productos vencidos o deteriorados, con el objetivo de evitar el riesgo de confusión entre medicamentos vencidos y medicamentos con fecha de expiración vigente.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Refrigeradora para productos que requieren condiciones especiales de temperatura. (si aplica).",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Termómetro para el refrigerador y formato de registro de temperatura. El registro y control diario de los parámetros debe ser como mínimo dos veces al día, de preferencia en horas de la mañana y medio día. (si aplica).",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "La farmacia estructuralmente tiene relación directa o conexión con clínica.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Valor informativo:\r\n 1. Prohibiciones: no comer, no guardar plantas, ni comida, no fumar. \r\n2. Ley 17 de 12 de septiembre de 2014. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.\r\n3. La información dada por el paciente será manejada de manera confidencial.\r\n4. La venta de muestra médica al consumidor sea en establecimientos farmacéuticos o no farmacéuticos, en instalaciones de salud, en clínicas medicas públicas o privadas, es considerada una infracción a las normas de publicidad establecidas en la ley objeto de reglamentación, y como tal, acarreará la sanción respectiva. \r\n5. Las muestras médicas solo serán almacenadas en agencias distribuidoras que posean licencias de operación vigente. Las casas farmacéuticas que deseen importar, almacenar, manejar y distribuir las muestras médicas de sus productos deben obtener licencia de operación como distribuidora\r\n6. Se prohíbe la aplicación de medicamentos parenterales en la farmacia o que esta mantenga relación directa con clínicas. \r\n7. La farmacia desechará los empaques secundarios vacíos de medicamentos y no deberá guardarlos, las cajas vacías de medicamentos deben ser debidamente cortadas para evitar prácticas de incentivos monetarios por parte de las agencias distribuidoras o laboratorios fabricantes para su promoción, también aplica para cualquier otra forma de incentivo. tampoco podrán mantener material promocional visible, ni accesible al público de medicamentos de venta bajo receta médica para evitar el uso y abuso de medicamentos. \r\n8. La farmacia no debe comercializar medicamentos sin registro sanitario. \r\n9. En el establecimiento debe existir un registro cronológico que permita documentar la limpieza en las áreas de la farmacia. Estas áreas deben mantenerse limpias y libres de polvo.\r\n",
                            IsHeader =  true,
                    },
             };
        }

        public void Inicializa_DatosAreaProductosControlados()
        {
            DatosAreaProductosControlados = new AUD_ContenidoGenerico();
            DatosAreaProductosControlados.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                            Titulo = "Identificada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Delimitada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Asegurado bajo llave u otro sistema de seguridad comprobada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Posee un área identificada de vencidos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Independiente de otras áreas",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Descripción del lugar donde se almacenan y las medidas de seguridad",
                             LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Medidas aproximadas",
                            IsHeader=true,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Largo",
                             LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Ancho",
                             LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Altura",
                             LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
             };
        }

        public void Inicializa_DatosAreaAlmacenamiento()
        {
            DatosAreaAlmacenamiento = new AUD_ContenidoGenerico();
            DatosAreaAlmacenamiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                            Titulo = "Esta identificada y delimitada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "El espacio físico de almacenamiento es adecuado para el movimiento y operaciones del personal permitiendo un despacho oportuno a las estanterías del área de recetario",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "En el área de almacenamiento debe existir un sistema de inventario que permita determinar la vigencia de los medicamentos de tal forma que puedan abastecer o retirar los mismos en tiempo oportuno (de acuerdo con las políticas de devolución). Se almacenarán las existencias utilizando los sistemas FIFO (primero que entra que sale) o FEFO (primero que expira primero que sale).",
                            IsHeader=true,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Higrotermómetro y formato de registro de temperatura y humedad relativa.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Limpio y ordenado",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Iluminación",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas u otros. Manteniendo suficiente distancia de paredes, piso y techo",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (aplíquese cuando el almacén este fuera de las instalaciones de la farmacia)",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Extintores contra incendios",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Alarmas contra incendios o detector de humo",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Luces de emergencia",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Existe un sistema para el control de fauna nociva y documento que respalde esta",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de productos devueltos y vencidos identificada, delimitada y asegurada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de productos controlados, delimitada y asegurada bajo llave",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        //new ContenidoPreguntas(){
                        //    Titulo = "Área de almacenamiento de Alcohol o productos inflamables separada con ventilación adecuada que evite la exposición a los vapores",
                        //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        //},
                        //new ContenidoPreguntas(){
                        //    Titulo = "Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas",
                        //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        //},
                        //new ContenidoPreguntas(){
                        //    Titulo = "El establecimiento se compromete al fiel cumplimiento del Artículo 639 del Decreto Ejecutivo 115 De 16 de agosto de 2022",
                        //    IsHeader=true
                        //},
             };
        }

        public void Inicializa_DatosAreaAlmacenamientoAlcohol()
        {
            DatosAreaAlmacenamientoAlcohol = new AUD_ContenidoGenerico();
            DatosAreaAlmacenamientoAlcohol.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                            Titulo = "Separado",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Cuenta con ventilación adecuada que evite la exposición a los vapores",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Extintores contra incendios",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Alarmas contra incendios o detector de humo",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Lámpara de emergencia en lugares adecuados para la seguridad del personal",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Cuenta con Kit de emergencia para el manejo de sustancias peligrosas o corrosivas",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
             };
        }

    }
}
