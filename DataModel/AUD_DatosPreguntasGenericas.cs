using DataBindable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos de Preguntas Genericas
    /// </summary>
    public class AUD_DatosPreguntasGenericas : SystemId
    {

        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible frente al recetario con la siguiente instrucción: “El usuario que adquiera un medicamento de los regulados que se venden sin receta médica lo hace bajo su responsabilidad”. Art. 151 de la Ley 1 de 10 de enero de 2001",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Farmacia Privada: Anuncio visible y legible Artículo 655 y Artículo 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022 \r\n Artículo 655. Las farmacias privadas están obligadas a colocar, en sitio visible, un letrero que indique que el farmacéutico está facultado y obligado a ofrecer los medicamentos intercambiables y al hacer la sustitución genérica, deberá constancia del producto dispensado con su firma y código de registro al reverso de la receta. A su vez, el paciente al momento de aceptar la sustitución genérica también dejará constancia mediante su firma o huella digital al reverso de la prescripción médica. Artículo 656. Las farmacias privadas están obligadas a colocar, en sitio visible, un letrero que indique por su salud, consulte al farmacéutico sobre el uso adecuado de los medicamentos, especialmente los que presenta la leyenda venta bajo receta médica o frase similar",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. \r\nNo incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana\r\n",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área separada para la alimentación del personal",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales). Será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Aire acondicionado para mantener las condiciones de almacenamiento",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos)",
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
                        Titulo = "La farmacia debe contar con un programa de mantenimiento preventivo que incluya cualquier desperfecto o condiciones no adecuadas de las estructuras",
                           IsHeader=true,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).",
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
                        Titulo = "Área delimitada, segregada e identificada de productos vencidos (devolución).",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Refrigeradora para productos que requieren condiciones especiales de temperatura. (si aplica).",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Termómetro para el refrigerador y formato de registro de temperatura. (si aplica).",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "La farmacia estructuralmente tiene relación directa o conexión con clínica.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Valor informativo:\r\n 1. Prohibiciones: no comer, no guardar plantas, ni comida, no fumar. \r\n2. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.\r\n3. La información dada por el paciente será manejada de manera confidencial.\r\n4. La venta de muestra médica al consumidor sea en establecimientos farmacéuticos o no farmacéuticos, en instalaciones de salud, en clínicas medicas públicas o privadas, es considerada una infracción a las normas de publicidad establecidas en la ley objeto de reglamentación, y como tal, acarreará la sanción respectiva. \r\n5. Las muestras médicas solo serán almacenadas en agencias distribuidoras que posean licencias de operación vigente. Las casas farmacéuticas que deseen importar, almacenar, manejar y distribuir las muestras médicas de sus productos deben obtener licencia de operación como distribuidora\r\n6. Se prohíbe la aplicación de medicamentos parenterales en la farmacia o que esta mantenga relación directa con clínicas. \r\n7. La farmacia desechará los empaques secundarios vacíos de medicamentos y no deberá guardarlos, las cajas vacías de medicamentos deben ser debidamente cortadas para evitar prácticas de incentivos monetarios por parte de las agencias distribuidoras o laboratorios fabricantes para su promoción, también aplica para cualquier otra forma de incentivo. tampoco podrán mantener material promocional visible, ni accesible al público de medicamentos de venta bajo receta médica para evitar el uso y abuso de medicamentos. \r\n8. La farmacia no debe comercializar medicamentos sin registro sanitario. \r\n9. Debe existir un sistema de registro cronológico que permita documentar la frecuencia con que se realiza la limpieza en las áreas de farmacia. Estas áreas deben mantenerse limpias y libres de polvo. Los productos de limpieza utilizados deben prevenir la contaminación de las zonas. \r\n",
                            IsHeader =  true,
                    },
             };
        }





        //Anuncio visible y legible frente al recetario con la instrucción del Art. 151 de la Ley 1 de 10 de enero de 2001
        private bool anuncioVisibleLeyArt151;
        public bool AnuncioVisibleLeyArt151 { get => anuncioVisibleLeyArt151; set => SetProperty(ref anuncioVisibleLeyArt151, value); }


        //Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. "Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos":
        private bool anuncioVisibleTablaPromPrecio;
        public bool AnuncioVisibleTablaPromPrecio { get => anuncioVisibleTablaPromPrecio; set => SetProperty(ref anuncioVisibleTablaPromPrecio, value); }

        //Anuncio visible y legible de Art. 1 y Art. 2 de Ley 17 de 12 de septiembre de 2014. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.
        private bool anuncioVisibleLeyArt1;
        public bool AnuncioVisibleLeyArt1 { get => anuncioVisibleLeyArt1; set => SetProperty(ref anuncioVisibleLeyArt1, value); }

        //Farmacia Privada: Anuncio visible y legible Art. 655 y Art. 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022.
        private bool anuncioVisibleLeyArt656;
        public bool AnuncioVisibleLeyArt656 { get => anuncioVisibleLeyArt656; set => SetProperty(ref anuncioVisibleLeyArt656, value); }

        //Higrótermometro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía.
        private bool registroTempHumedadRelat;
        public bool RegistroTempHumedadRelat { get => registroTempHumedadRelat; set => SetProperty(ref registroTempHumedadRelat, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string registroTempHumedadRelatDescrip;
        public string RegistroTempHumedadRelatDescrip { get => registroTempHumedadRelatDescrip; set => SetProperty(ref registroTempHumedadRelatDescrip, value); }

        //Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa.
        private bool programaCalibracion;
        public bool ProgramaCalibracion { get => programaCalibracion; set => SetProperty(ref programaCalibracion, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string programaCalibracionDescrip;
        public string ProgramaCalibracionDescrip { get => programaCalibracionDescrip; set => SetProperty(ref programaCalibracionDescrip, value); }

        //El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. No incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana.
        private bool espacioFisicoMin20;
        public bool EspacioFisicoMin20 { get => espacioFisicoMin20; set => SetProperty(ref espacioFisicoMin20, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string espacioFisicoMin20Descrip;
        public string EspacioFisicoMin20Descrip { get => espacioFisicoMin20Descrip; set => SetProperty(ref espacioFisicoMin20Descrip, value); }

        //Área de gestión administrativa del farmacéutico indentificada.
        private bool areaGestionAdmin;
        public bool AreaGestionAdmin { get => areaGestionAdmin; set => SetProperty(ref areaGestionAdmin, value); }

        //Área separada para la alimentación del personal
        private bool areaSeparadaAlimentPersonal;
        public bool AreaSeparadaAlimentPersonal { get => areaSeparadaAlimentPersonal; set => SetProperty(ref areaSeparadaAlimentPersonal, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string areaSeparadaAlimentPersonalDescrip;
        public string AreaSeparadaAlimentPersonalDescrip { get => areaSeparadaAlimentPersonalDescrip; set => SetProperty(ref areaSeparadaAlimentPersonalDescrip, value); }

        //Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales). Será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene.
        private bool sanitarioPersonal;
        public bool SanitarioPersonal { get => sanitarioPersonal; set => SetProperty(ref sanitarioPersonal, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string sanitarioPersonalDescrip;
        public string SanitarioPersonalDescrip { get => sanitarioPersonalDescrip; set => SetProperty(ref sanitarioPersonalDescrip, value); }

        //Aire acondicionado para mantener las condiciones de almacenamiento
        private bool aireAcondicionadoCondAliment;
        public bool AireAcondicionadoCondAliment { get => aireAcondicionadoCondAliment; set => SetProperty(ref aireAcondicionadoCondAliment, value); }

        //Extintores contra incendios(vigentes y aprobados por el cuerpo de Bomberos)
        private bool extintoresIncendio;
        public bool ExtintoresIncendio { get => extintoresIncendio; set => SetProperty(ref extintoresIncendio, value); }

        //Alarmas contra incendio  o detector de humo
        private bool alarmaIntrusoIncendio;
        public bool AlarmaIntrusoIncendio { get => alarmaIntrusoIncendio; set => SetProperty(ref alarmaIntrusoIncendio, value); }

        //Luces de Emergencia
        private bool lucesEmergencias;
        public bool LucesEmergencias { get => lucesEmergencias; set => SetProperty(ref lucesEmergencias, value); }

        //salida emergencia
        private bool salidaEmergencias;
        public bool SalidaEmergencias { get => salidaEmergencias; set => SetProperty(ref salidaEmergencias, value); }

        //No Comer
        private bool noComer;
        public bool NoComer { get => noComer; set => SetProperty(ref noComer, value); }

        //No Beber
        private bool noBeber;
        public bool NoBeber { get => noBeber; set => SetProperty(ref noBeber, value); }

        //No Fumar
        private bool noFumar;
        public bool NoFumar { get => noFumar; set => SetProperty(ref noFumar, value); }

        //No Fumar
        private bool noGuardarPlantasComidasBebidas;
        public bool NoGuardarPlantasComidasBebidas { get => noGuardarPlantasComidasBebidas; set => SetProperty(ref noGuardarPlantasComidasBebidas, value); }

        ////Asesoria Farmaceutica
        //private bool asesoriaFarmaceutica;
        //public bool AsesoriaFarmaceutica { get => asesoriaFarmaceutica; set => SetProperty(ref asesoriaFarmaceutica, value); }

        ////Consulta Bibliografica
        //private bool consultaBibliografica;
        //public bool ConsultaBibliografica { get => consultaBibliografica; set => SetProperty(ref consultaBibliografica, value); }

        ////productos Vencidos
        //private bool productosVencidos;
        //public bool ProductosVencidos { get => productosVencidos; set => SetProperty(ref productosVencidos, value); }

        ////Refrigeradora para productos que requiere condiciones especiales de temperatura
        //private bool refriProductosCondEspeciales;
        //public bool RefriProductosCondEspeciales { get => refriProductosCondEspeciales; set => SetProperty(ref refriProductosCondEspeciales, value); }

    }
}
