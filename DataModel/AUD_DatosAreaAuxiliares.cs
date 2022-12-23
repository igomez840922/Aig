using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaAuxiliares:SystemId
    {
        // ÁREAS AUXILIARES / (Puntos a Evaluar - Cumplimiento - Observaciones)
        // Áreas de descanso y comedores separados de áreas técnicas
        private enumAUD_TipoSeleccion areaDescanso;
        public enumAUD_TipoSeleccion AreaDescanso { get => areaDescanso; set => SetProperty(ref areaDescanso, value); }

        // Observaciones
        private string areaDescansoDesc;
        [StringLength(500)]
        public string AreaDescansoDesc { get => areaDescansoDesc; set => SetProperty(ref areaDescansoDesc, value); }

        // Servicios sanitarios, lavamanos y en cantidad suficiente
        private enumAUD_TipoSeleccion servSanitarioLavadoSuficiente;
        public enumAUD_TipoSeleccion ServSanitarioLavadoSuficiente { get => servSanitarioLavadoSuficiente; set => SetProperty(ref servSanitarioLavadoSuficiente, value); }

        // Observaciones
        private string servSanitarioLavadoSuficienteDesc;
        [StringLength(500)]
        public string ServSanitarioLavadoSuficienteDesc { get => servSanitarioLavadoSuficienteDesc; set => SetProperty(ref servSanitarioLavadoSuficienteDesc, value); }

        // Casilleros para el personal
        private enumAUD_TipoSeleccion casillerosPersonales;
        public enumAUD_TipoSeleccion CasillerosPersonales { get => casillerosPersonales; set => SetProperty(ref casillerosPersonales, value); }

        // Observaciones
        private string casillerosPersonalesDesc;
        [StringLength(500)]
        public string CasillerosPersonalesDesc { get => casillerosPersonalesDesc; set => SetProperty(ref casillerosPersonalesDesc, value); }

        // Áreas de mantenimiento separadas de las áreas de producción. 
        private enumAUD_TipoSeleccion areaMantenimSeparada;
        public enumAUD_TipoSeleccion AreaMantenimSeparada { get => areaMantenimSeparada; set => SetProperty(ref areaMantenimSeparada, value); }

        // Observaciones
        private string areaMantenimSeparadaDesc;
        [StringLength(500)]
        public string AreaMantenimSeparadaDesc { get => areaMantenimSeparadaDesc; set => SetProperty(ref areaMantenimSeparadaDesc, value); }

        ///////////////////////////////
        //////////////////////////////////
        ///

        // Están los servicios sanitarios accesibles a las áreas de trabajo y no se comunican directamente con las áreas de producción? 
        private enumAUD_TipoSeleccion servSanitarioAccesible;
        public enumAUD_TipoSeleccion ServSanitarioAccesible { get => servSanitarioAccesible; set => SetProperty(ref servSanitarioAccesible, value); }

        // Observaciones
        private string servSanitarioAccesibleDesc;
        public string ServSanitarioAccesibleDesc { get => servSanitarioAccesibleDesc; set => SetProperty(ref servSanitarioAccesibleDesc, value); }

        // Los vestidores están comunicados directamente con las áreas de producción?
        private enumAUD_TipoSeleccion vestidoresComunicaProd;
        public enumAUD_TipoSeleccion VestidoresComunicaProd { get => vestidoresComunicaProd; set => SetProperty(ref vestidoresComunicaProd, value); }

        // Observaciones
        private string vestidoresComunicaProdDesc;
        public string VestidoresComunicaProdDesc { get => vestidoresComunicaProdDesc; set => SetProperty(ref vestidoresComunicaProdDesc, value); }

        // Los vestidores y servicios sanitarios están Identificados correctamente
        private enumAUD_TipoSeleccion vestidoresIdentificados;
        public enumAUD_TipoSeleccion VestidoresIdentificados { get => vestidoresIdentificados; set => SetProperty(ref vestidoresIdentificados, value); }

        // Observaciones
        private string vestidoresIdentificadosDesc;
        public string VestidoresIdentificadosDesc { get => vestidoresIdentificadosDesc; set => SetProperty(ref vestidoresIdentificadosDesc, value); }

        // La cantidad de servicios sanitarios para hombres y mujeres está de acuerdo con el número de trabajadores? 
        private enumAUD_TipoSeleccion cantidadServicioSanitarios;
        public enumAUD_TipoSeleccion CantidadServicioSanitarios { get => cantidadServicioSanitarios; set => SetProperty(ref cantidadServicioSanitarios, value); }

        // Observaciones
        private string cantidadServicioSanitariosDesc;
        public string CantidadServicioSanitariosDesc { get => cantidadServicioSanitariosDesc; set => SetProperty(ref cantidadServicioSanitariosDesc, value); }

        // Cuentan con lavamanos y duchas provistas de agua?
        private enumAUD_TipoSeleccion lavadosDuchasProvistasAgua;
        public enumAUD_TipoSeleccion LavadosDuchasProvistasAgua { get => lavadosDuchasProvistasAgua; set => SetProperty(ref lavadosDuchasProvistasAgua, value); }

        // Observaciones
        private string lavadosDuchasProvistasAguaDesc;
        public string LavadosDuchasProvistasAguaDesc { get => lavadosDuchasProvistasAguaDesc; set => SetProperty(ref lavadosDuchasProvistasAguaDesc, value); }

        // Dispone de espejos, toallas de papel o secador eléctrico de manos, jaboneras con jabón líquido desinfectante y papel higiénico?
        private enumAUD_TipoSeleccion disponeEspejos;
        public enumAUD_TipoSeleccion DisponeEspejos { get => disponeEspejos; set => SetProperty(ref disponeEspejos, value); }

        // Observaciones
        private string disponeEspejosDesc;
        public string DisponeEspejosDesc { get => disponeEspejosDesc; set => SetProperty(ref disponeEspejosDesc, value); }

        // Casilleros, zapateras y las bancas necesarias (no de madera)
        private enumAUD_TipoSeleccion casillerosZapaterosNecesario;
        public enumAUD_TipoSeleccion CasillerosZapaterosNecesario { get => casillerosZapaterosNecesario; set => SetProperty(ref casillerosZapaterosNecesario, value); }

        // Observaciones
        private string casillerosZapaterosNecesarioDesc;
        public string CasillerosZapaterosNecesarioDesc { get => casillerosZapaterosNecesarioDesc; set => SetProperty(ref casillerosZapaterosNecesarioDesc, value); }

        //Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área, manteniendo rótulos que indiquen esta disposición
        private enumAUD_TipoSeleccion prohibeConsumirAlimentos;
        public enumAUD_TipoSeleccion ProhibeConsumirAlimentos { get => prohibeConsumirAlimentos; set => SetProperty(ref prohibeConsumirAlimentos, value); }

        // Observaciones
        private string prohibeConsumirAlimentosDesc;
        public string ProhibeConsumirAlimentosDesc { get => prohibeConsumirAlimentosDesc; set => SetProperty(ref prohibeConsumirAlimentosDesc, value); }

        //Se prohíbe fumar en estas áreas (rótulo).
        private enumAUD_TipoSeleccion prohibeFumar;
        public enumAUD_TipoSeleccion ProhibeFumar { get => prohibeFumar; set => SetProperty(ref prohibeFumar, value); }

        // Observaciones
        private string prohibeFumarDesc;
        public string ProhibeFumarDesc { get => prohibeFumarDesc; set => SetProperty(ref prohibeFumarDesc, value); }

        //Cuentan con un comedor separado de las demás áreas productivas e identificada, en buenas condiciones de orden y limpieza? 
        private enumAUD_TipoSeleccion comedorSeparado;
        public enumAUD_TipoSeleccion ComedorSeparado { get => comedorSeparado; set => SetProperty(ref comedorSeparado, value); }

        // Observaciones
        private string comedorSeparadoDesc;
        public string ComedorSeparadoDesc { get => comedorSeparadoDesc; set => SetProperty(ref comedorSeparadoDesc, value); }

        //Cuentan con un área de lavandería separada y exclusiva para el lavado y secado de los uniformes utilizados por el personal? 
        private enumAUD_TipoSeleccion areaLavanderia;
        public enumAUD_TipoSeleccion AreaLavanderia { get => areaLavanderia; set => SetProperty(ref areaLavanderia, value); }

        // Observaciones
        private string areaLavanderiaDesc;
        public string AreaLavanderiaDesc { get => areaLavanderiaDesc; set => SetProperty(ref areaLavanderiaDesc, value); }

        //Existe un área destinada para investigación y desarrollo de sus productos?
        private enumAUD_TipoSeleccion areaInvestigaciones;
        public enumAUD_TipoSeleccion AreaInvestigaciones { get => areaInvestigaciones; set => SetProperty(ref areaInvestigaciones, value); }

        // Observaciones
        private string areaInvestigacionesDesc;
        public string AreaInvestigacionesDesc { get => areaInvestigacionesDesc; set => SetProperty(ref areaInvestigacionesDesc, value); }

    }
}
