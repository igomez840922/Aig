using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspRutinaVigFarmaciaTB : SystemId
    {  
        private AUD_InspeccionTB inspeccion;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //FARMACÉUTICO DE TURNO
        private AUD_DatosFarmaceutico datosFarmaceutico;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosFarmaceutico DatosFarmaceutico { get => datosFarmaceutico; set => SetProperty(ref datosFarmaceutico, value); }


        //EXPEDIENTES DEL PERSONAL DE LA FARMACIA 
        private AUD_ContenidoGenerico expPersonalFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ExpPersonalFarmacia { get => expPersonalFarmacia; set => SetProperty(ref expPersonalFarmacia, value); }

        //ESTRUCTURA ORGANIZACIONAL DE LA FARMACIA
        private AUD_ContenidoGenerico estructOrganizFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico EstructOrganizFarmacia { get => estructOrganizFarmacia; set => SetProperty(ref estructOrganizFarmacia, value); }

        //ESTRUCTURA ORGANIZACIONAL DE LA FARMACIA
        private AUD_ContenidoGenerico estructFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico EstructFarmacia { get => estructFarmacia; set => SetProperty(ref estructFarmacia, value); }

        //ÁREA FÍSICA DE LA FARMACIA
        private AUD_ContenidoGenerico areaFisicaFarmacia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaFisicaFarmacia { get => areaFisicaFarmacia; set => SetProperty(ref areaFisicaFarmacia, value); }

        //AREA DE PRODUCTOS CONTROLADOS (CUANDO APLIQUE).
        private AUD_ContenidoGenerico areaProdControlados;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProdControlados { get => areaProdControlados; set => SetProperty(ref areaProdControlados, value); }

        //REGISTRO DE MOVIMIENTO DE EXISTENCIA
        private AUD_ContenidoGenerico regMovimientoExistencia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico RegMovimientoExistencia { get => regMovimientoExistencia; set => SetProperty(ref regMovimientoExistencia, value); }

        //ÁREA DE ALMACEN DE MEDICAMENTOS Y OTROS PRODUCTOS PARA LA SALUD HUMANA. (CUANDO APLIQUE).
        private AUD_ContenidoGenerico areaAlmacenMedicamentos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenMedicamentos { get => areaAlmacenMedicamentos; set => SetProperty(ref areaAlmacenMedicamentos, value); }

        //PROCEDIMIENTOS
        private AUD_ContenidoGenerico procedimientos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Procedimientos { get => procedimientos; set => SetProperty(ref procedimientos, value); }

        //REPORTE DE INVENTARIO DE MEDICAMENTOS DE USO CONTROLADO
        private AUD_InventarioMedicamento inventarioMedicamento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_InventarioMedicamento InventarioMedicamento { get => inventarioMedicamento; set => SetProperty(ref inventarioMedicamento, value); }


        public void Inicializa_ExpPersonalFarmacia()
        {
            ExpPersonalFarmacia = new AUD_ContenidoGenerico();
            ExpPersonalFarmacia.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "En el expediente personal de cada colaborador de la farmacia se incluye la idoneidad y evidencia de capacitación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los farmacéuticos y técnicos en farmacia portan visiblemente el carnet con su número de idoneidad que los acredite como personal idóneo para la atención farmacéutica",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_EstructOrganizFarmacia()
        {
            EstructOrganizFarmacia = new AUD_ContenidoGenerico();
            EstructOrganizFarmacia.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de su letrero de identificación visible al público",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento utiliza plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_EstructFarmacia()
        {
            EstructFarmacia = new AUD_ContenidoGenerico();
            EstructFarmacia.LContenido = new List<ContenidoPreguntas>() {
                        
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de paredes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estado de paredes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de cielo raso",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estado de cielo raso",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de pisos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estado de pisos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación. De ser SÍ ¿Por qué?:",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_AreaFisicaFarmacia()
        {
            AreaFisicaFarmacia = new AUD_ContenidoGenerico();
            AreaFisicaFarmacia.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Mobiliario de medicamentos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tipo de mobiliario",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estado de mobiliario",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Muebles separados de las paredes, pisos y techos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Muebles ordenados, limpios y libres de polvo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Hay cajas donde se disponen los medicamentos próximos a la ubicación en el recetario que obstruyen el libre tránsito del personal por el área",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PREGUNTA",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible frente al recetario con la siguiente instrucción: “El usuario que adquiera un medicamento de los regulados que se venden sin receta médica lo hace bajo su responsabilidad”. Artículo 151 de la Ley 1 de 10 de enero de 2001",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Farmacia Privada: Anuncio visible y legible Artículo 655 y Artículo 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022. \r\nArtículo 655. Las farmacias privadas están obligadas a colocar, en sitio visible, un letrero que indique que el farmacéutico está facultado y obligado a ofrecer los medicamentos intercambiables y al hacer la sustitución genérica, deberá constancia del producto dispensado con su firma y código de registro al reverso de la receta. A su vez, el paciente al momento de aceptar la sustitución genérica también dejará constancia mediante su firma o huella digital al reverso de la prescripción médica.\r\nArtículo 656. Las farmacias privadas están obligadas a colocar, en sitio visible, un letrero que indique “por su salud, consulte al farmacéutico sobre el uso adecuado de los medicamentos, especialmente los que presenta la leyenda venta bajo receta médica o frase similar”.\r\n",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. \r\nNo incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana. (No aplican farmacias existentes antes de 18 de marzo de 2019)\r\n",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área separada para la alimentación del personal",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales), será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Aire acondicionado para mantener las condiciones de almacenamiento",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Alarmas contra incendios o detector de humo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con un programa de mantenimiento preventivo que incluya cualquier desperfecto o condiciones no adecuadas de las estructuras",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área de Asesoría Farmacéutica delimitada e identificada que permita la interacción privada entre farmacéutico y paciente",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área de Consultas bibliográficas Física",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área de Consultas bibliográficas Electrónica",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área delimitada, segregada e identificada de productos vencidos (devolución).",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Refrigeradora para productos que requieren condiciones especiales de temperatura",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Termómetro para el refrigerador y registro de temperatura debidamente identificado",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema de registro cronológico que permite documentar la frecuencia con que se realiza la limpieza en las áreas de farmacias",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las áreas de la farmacia están libres de polvo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La farmacia estructuralmente tiene relación directa o conexión con clínica",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Valor informativo: \r\n\r\n1.Prohibiciones: no comer, no guardar plantas, ni comida, no fumar. \r\n2.“Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.\r\n3.La información dada por el paciente será manejada de manera confidencial.\r\n4.La venta de muestra médica al consumidor sea en establecimientos farmacéuticos o no farmacéuticos, en instalaciones de salud, en clínicas medicas públicas o privadas, es considerada una infracción a las normas de publicidad establecidas en la ley objeto de reglamentación, y como tal, acarreará la sanción respectiva. \r\n5.Las muestras médicas solo serán almacenadas en agencias distribuidoras que posean licencias de operación vigente. Las casas farmacéuticas que deseen importar, almacenar, manejar y distribuir las muestras médicas de sus productos deben obtener licencia de operación como distribuidora\r\n6. Se prohíbe la aplicación de medicamentos parenterales en la farmacia o que esta mantenga relación directa con clínicas. \r\n7.La farmacia desechará los empaques secundarios vacíos de medicamentos y no deberá guardarlos, las cajas vacías de medicamentos deben ser debidamente cortadas para evitar prácticas de incentivos monetarios por parte de las agencias distribuidoras o laboratorios fabricantes para su promoción, también aplica para cualquier otra forma de incentivo. tampoco podrán mantener material promocional visible, ni accesible al público de medicamentos de venta bajo receta médica para evitar el uso y abuso de medicamentos. \r\n8.La farmacia no debe comercializar medicamentos sin registro sanitario.",
                        IsHeader = true,
                    },
             };
        }

        public void Inicializa_AreaProdControlados()
        {
            AreaProdControlados = new AUD_ContenidoGenerico();
            AreaProdControlados.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Limpia",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Asegurado bajo llave u otro sistema de seguridad comprobada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Posee un área identificada de vencidos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Independiente de otras áreas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_RegMovimientoExistencia()
        {
            RegMovimientoExistencia = new AUD_ContenidoGenerico();
            RegMovimientoExistencia.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Se encuentra el Libro Récord en el establecimiento a disposición del inspector",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El establecimiento cuenta con Libro Récord numerado y foliado por la DNFD",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Libro Record para el registro de recetas corrientes está al día hasta el",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Esta anota las recetas corriente y Antibióticos dispensadas en este libro",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Todas las recetas se encuentran archivadas en orden cronológico, mensual o trimestral",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }

        public void Inicializa_AreaAlmacenMedicamentos()
        {
            AreaAlmacenMedicamentos = new AUD_ContenidoGenerico();
            AreaAlmacenMedicamentos.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Esta identificada y delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El espacio físico de almacenamiento es adecuado para el movimiento y operaciones del personal permitiendo un despacho oportuno a las estanterías del área de recetario",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "En el área de almacenamiento existe un sistema de inventario que permite determinar la vigencia de los medicamentos de tal forma que puedan abastecer o retirar los mismos entiempo oportuno (de acuerdo con las políticas de devolución). Sistemas FIFO (primero que entra que sale) o FEFO (primero que expira primero que sale)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Higrotermómetro y registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo tres veces al día",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Limpia y ordenado",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas u otros. Manteniendo suficiente distancia de paredes, piso y techo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (Aplíquese cuando el almacén esté fuera de las instalaciones de la farmacia).",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Extintores contra incendios (vigentes).",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Alarmas contra incendios o detector de humo.",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de productos devueltos y vencidos identificada, delimitada y asegurada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de productos controlados, delimitada y asegurada bajo llave",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de almacenamiento de Alcohol o productos inflamables con ventilación adecuada que evite la exposición a los vapores.",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    }
             };
        }

        public void Inicializa_Procedimientos()
        {
            Procedimientos = new AUD_ContenidoGenerico();
            Procedimientos.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con procedimientos para almacenamiento de los medicamentos y otros productos para la salud humana",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con procedimientos para retiro y remplazo de productos vencidos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con procedimientos de limpieza del área",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con procedimientos para la capacitación continua del personal",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con procedimientos de manejo de medicamentos de cadena de frío",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos estándares de operación para la devolución de los medicamentos a los proveedores y se deben documentar las transacciones por devolución de los medicamentos permitiendo la trazabilidad de acuerdo con las políticas acordadas con cada proveedor",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
                
    }
}
