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


        public void Inicializa_DatosEstructuraOrganizacional()
        {
            DatosEstructuraOrganizacional = new AUD_ContenidoGenerico();
            DatosEstructuraOrganizacional.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de su letrero de identificación visible al público",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_DatosInfraEstructura()
        {
            DatosInfraEstructura = new AUD_ContenidoGenerico();
            DatosInfraEstructura.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Paredes",
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado de las Paredes",
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Cielo Raso",
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado del Cielo Raso",
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Pisos",
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado del Piso",
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación? De ser sí explique.",
                        Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_DatosAreaFisica()
        {
            DatosAreaFisica = new AUD_ContenidoGenerico();
            DatosAreaFisica.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Mobiliario de medicamentos",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Muebles separados de las paredes, pisos, y techos",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de Mobiliario",
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Estado del Mobiliario",
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Las cajas donde se dispondrán los medicamentos próximos a la ubicación en el recetario no deben obstruir el libre tránsito del personal por el área",
                        IsHeader = true,
                    },
             };
        }

        public void Inicializa_DatosPreguntasGenericas()
        {
            DatosPreguntasGenericas = new AUD_ContenidoGenerico();
            DatosPreguntasGenericas.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible frente al recetario con la siguiente instrucción: “El usuario que adquiera un medicamento de los regulados que se venden sin receta médica lo hace bajo su responsabilidad”. Art. 151 de la Ley 1 de 10 de enero de 2001",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Farmacia Privada: Anuncio visible y legible Artículo 655 y Artículo 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022 \r\n Artículo 655. Las farmacias privadas están obligadas a colocar, en sitio visible, un letrero que indique que el farmacéutico está facultado y obligado a ofrecer los medicamentos intercambiables y al hacer la sustitución genérica, deberá constancia del producto dispensado con su firma y código de registro al reverso de la receta. A su vez, el paciente al momento de aceptar la sustitución genérica también dejará constancia mediante su firma o huella digital al reverso de la prescripción médica. Artículo 656. Las farmacias privadas están obligadas a colocar, en sitio visible, un letrero que indique por su salud, consulte al farmacéutico sobre el uso adecuado de los medicamentos, especialmente los que presenta la leyenda venta bajo receta médica o frase similar",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. \r\nNo incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana\r\n",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área separada para la alimentación del personal",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales). Será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Aire acondicionado para mantener las condiciones de almacenamiento",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos)",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Alarmas contra incendios o detector de humo",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "La farmacia debe contar con un programa de mantenimiento preventivo que incluya cualquier desperfecto o condiciones no adecuadas de las estructuras",
                           IsHeader=true,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de Asesoría Farmacéutica delimitada e identificada que permita la interacción privada entre farmacéutico y paciente",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de Consultas bibliográficas Física",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de Consultas bibliográficas Electrónica",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área delimitada, segregada e identificada de productos vencidos (devolución).",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Refrigeradora para productos que requieren condiciones especiales de temperatura. (si aplica).",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Termómetro para el refrigerador y formato de registro de temperatura. (si aplica).",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "La farmacia estructuralmente tiene relación directa o conexión con clínica.",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Valor informativo:\r\n 1. Prohibiciones: no comer, no guardar plantas, ni comida, no fumar. \r\n2. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.\r\n3. La información dada por el paciente será manejada de manera confidencial.\r\n4. La venta de muestra médica al consumidor sea en establecimientos farmacéuticos o no farmacéuticos, en instalaciones de salud, en clínicas medicas públicas o privadas, es considerada una infracción a las normas de publicidad establecidas en la ley objeto de reglamentación, y como tal, acarreará la sanción respectiva. \r\n5. Las muestras médicas solo serán almacenadas en agencias distribuidoras que posean licencias de operación vigente. Las casas farmacéuticas que deseen importar, almacenar, manejar y distribuir las muestras médicas de sus productos deben obtener licencia de operación como distribuidora\r\n6. Se prohíbe la aplicación de medicamentos parenterales en la farmacia o que esta mantenga relación directa con clínicas. \r\n7. La farmacia desechará los empaques secundarios vacíos de medicamentos y no deberá guardarlos, las cajas vacías de medicamentos deben ser debidamente cortadas para evitar prácticas de incentivos monetarios por parte de las agencias distribuidoras o laboratorios fabricantes para su promoción, también aplica para cualquier otra forma de incentivo. tampoco podrán mantener material promocional visible, ni accesible al público de medicamentos de venta bajo receta médica para evitar el uso y abuso de medicamentos. \r\n8. La farmacia no debe comercializar medicamentos sin registro sanitario. \r\n9. Debe existir un sistema de registro cronológico que permita documentar la frecuencia con que se realiza la limpieza en las áreas de farmacia. Estas áreas deben mantenerse limpias y libres de polvo. Los productos de limpieza utilizados deben prevenir la contaminación de las zonas. \r\n",
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
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Delimitada",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Asegurado bajo llave u otro sistema de seguridad comprobada",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Posee un área identificada de vencidos",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Independiente de otras áreas",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Medidas aproximadas",
                            IsHeader=true,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Largo",
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Ancho",
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Altura",
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Descripción del lugar donde se almacenan y las medidas de seguridad",
                        },
             };
        }

        public void Inicializa_DatosAreaAlmacenamiento()
        {
            DatosAreaAlmacenamiento = new AUD_ContenidoGenerico();
            DatosAreaAlmacenamiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                            Titulo = "Esta identificada y delimitada",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "El espacio físico de almacenamiento es adecuado para el movimiento y operaciones del personal permitiendo un despacho oportuno a las estanterías del área de recetario",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "En el área de almacenamiento debe existir un sistema de inventario que permita determinar la vigencia de los medicamentos de tal forma que puedan abastecer o retirar los mismos en tiempo oportuno (de acuerdo con las políticas de devolución). Se almacenarán las existencias utilizando los sistemas FIFO (primero que entra que sale) o FEFO (primero que expira primero que sale).",
                            IsHeader=true,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo tres veces al día.",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Limpio y ordenado",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Iluminación",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas u otros. Manteniendo suficiente distancia de paredes, piso y techo",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (aplíquese cuando el almacén este fuera de las instalaciones de la farmacia)",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos)",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Alarmas contra incendios o detector de humo",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Luces de emergencia",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación)",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de productos devueltos y vencidos identificada, delimitada y asegurada",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de productos controlados, delimitada y asegurada bajo llave",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de almacenamiento de Alcohol o productos inflamables separada con ventilación adecuada que evite la exposición a los vapores",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas",
                            Evaluacion =  Helper.enumAUD_TipoSeleccion.NA,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "El establecimiento se compromete al fiel cumplimiento del Artículo 639 del Decreto Ejecutivo 115 De 16 de agosto de 2022",
                            IsHeader=true
                        },
             };
        }

    }
}
