using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosEstructuraFarmacia:SystemId
    {
        public AUD_DatosEstructuraFarmacia()
        {
            Material = new AUD_DatosEstructuraFarmaciaMaterial();
            AreaFisica = new AUD_DatosEstructuraFarmaciaMaterial();
        }

        //Material
        private AUD_DatosEstructuraFarmaciaMaterial material;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstructuraFarmaciaMaterial Material { get => material; set => SetProperty(ref material, value); }


        //ÁREA FÍSICA DE LA FARMACIA
        private AUD_DatosEstructuraFarmaciaMaterial areaFisica;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstructuraFarmaciaMaterial AreaFisica { get => areaFisica; set => SetProperty(ref areaFisica, value); }

    }

    public class AUD_DatosEstructuraFarmaciaMaterial: SystemId
    {
        // La farmacia estructuralmente tiene relación directa o conexión con clínica
        private enumAUD_TipoSeleccion relacionDirectaClinica;
        public enumAUD_TipoSeleccion RelacionDirectaClinica { get => relacionDirectaClinica; set => SetProperty(ref relacionDirectaClinica, value); }

        // El espacio Físico de 20mts2 (incluye área de consulta farmacéutica, área de asesoría bibliográfica, área administrativa del farmacéutico).
        private enumAUD_TipoSeleccion espacioFisicoAdecuado;
        public enumAUD_TipoSeleccion EspacioFisicoAdecuado { get => espacioFisicoAdecuado; set => SetProperty(ref espacioFisicoAdecuado, value); }

        // Cumple con el espacio adecuado para la movilización del personal 
        private enumAUD_TipoSeleccion espacioAdecuadoMoviliza;
        public enumAUD_TipoSeleccion EspacioAdecuadoMoviliza { get => espacioAdecuadoMoviliza; set => SetProperty(ref espacioAdecuadoMoviliza, value); }

        // Tipo de techo:
        private string tipoTecho;
        public string TipoTecho { get => tipoTecho; set => SetProperty(ref tipoTecho, value); }

        // Estado de techo:
        private string estadoTecho;
        public string EstadoTecho { get => estadoTecho; set => SetProperty(ref estadoTecho, value); }


        // Tipo de paredes:
        private string tipoParedes;
        public string TipoParedes { get => tipoParedes; set => SetProperty(ref tipoParedes, value); }

        // Estado de paredes:
        private string estadoParedes;
        public string EstadoParedes { get => estadoParedes; set => SetProperty(ref estadoParedes, value); }


        // Tipo de piso:
        private string tipoPiso;
        public string TipoPiso { get => tipoPiso; set => SetProperty(ref tipoPiso, value); }

        // Estado de piso:
        private string estadoPiso;
        public string EstadoPiso { get => estadoPiso; set => SetProperty(ref estadoPiso, value); }

        // El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación
        private enumAUD_TipoSeleccion riesgoContaminacion;
        public enumAUD_TipoSeleccion RiesgoContaminacion { get => riesgoContaminacion; set => SetProperty(ref riesgoContaminacion, value); }
        private string riesgoContaminacionDesc;
        public string RiesgoContaminacionDesc { get => riesgoContaminacionDesc; set => SetProperty(ref riesgoContaminacionDesc, value); }



    }

    public class AUD_DatosEstructuraFarmaciaAreaFisica : SystemId
    {
        // La farmacia estructuralmente tiene relación directa o conexión con clínica
        private enumAUD_TipoIluminacion iluminacion;
        public enumAUD_TipoIluminacion Iluminacion { get => iluminacion; set => SetProperty(ref iluminacion, value); }

        // Mobiliario para medicamentos:
        private enumAUD_TipoSeleccion mobiliarioMedicamento;
        public enumAUD_TipoSeleccion MobiliarioMedicamento { get => mobiliarioMedicamento; set => SetProperty(ref mobiliarioMedicamento, value); }

        // Mobiliario para medicamentos tipo:
        private string mobiliarioMedicamentoTipo;
        public string MobiliarioMedicamentoTipo { get => mobiliarioMedicamentoTipo; set => SetProperty(ref mobiliarioMedicamentoTipo, value); }

        // Mobiliario para medicamentos Estado:
        private string mobiliarioMedicamentoEstado;
        public string MobiliarioMedicamentoEstado { get => mobiliarioMedicamentoEstado; set => SetProperty(ref mobiliarioMedicamentoEstado, value); }

        // Muebles separados de las paredes, pisos y techos 
        private enumAUD_TipoSeleccion mueblesSeparados;
        public enumAUD_TipoSeleccion MueblesSeparados { get => mueblesSeparados; set => SetProperty(ref mueblesSeparados, value); }

        // Muebles ordenados, limpios y libres de polvo
        private enumAUD_TipoSeleccion mueblesOrdenados;
        public enumAUD_TipoSeleccion MueblesOrdenados { get => mueblesOrdenados; set => SetProperty(ref mueblesOrdenados, value); }

        // Vencidos en los muebles o estanterías
        private enumAUD_TipoSeleccion vencidosMueblesEstantes;
        public enumAUD_TipoSeleccion VencidosMueblesEstantes { get => vencidosMueblesEstantes; set => SetProperty(ref vencidosMueblesEstantes, value); }


        // Área de alimento del personal, separada
        private enumAUD_TipoSeleccion areaAlimentoSeparada;
        public enumAUD_TipoSeleccion AreaAlimentoSeparada { get => areaAlimentoSeparada; set => SetProperty(ref areaAlimentoSeparada, value); }

        // Área administrativa del farmacéutico, debidamente identificada
        private enumAUD_TipoSeleccion areaAdministIdentif;
        public enumAUD_TipoSeleccion AreaAdministIdentif { get => areaAdministIdentif; set => SetProperty(ref areaAdministIdentif, value); }

        // Área de asesoría farmacéutica, delimitada e identificada
        private enumAUD_TipoSeleccion areaAsesoriaIdentif;
        public enumAUD_TipoSeleccion AreaAsesoriaIdentif { get => areaAsesoriaIdentif; set => SetProperty(ref areaAsesoriaIdentif, value); }

        // Área bibliográfica texto, debidamente identificada 
        private enumAUD_TipoSeleccion areaBibliografTxtIdentif;
        public enumAUD_TipoSeleccion AreaBibliografTxtIdentif { get => areaBibliografTxtIdentif; set => SetProperty(ref areaBibliografTxtIdentif, value); }
        
        // Área bibliográfica internet, debidamente identificada 
        private enumAUD_TipoSeleccion areaBibliografIntIdentif;
        public enumAUD_TipoSeleccion AreaBibliografIntIdentif { get => areaBibliografIntIdentif; set => SetProperty(ref areaBibliografIntIdentif, value); }

        // Área delimitada, segregada e identificada de productos vencidos (devolución)
        private enumAUD_TipoSeleccion areaProdVencidosIdentif;
        public enumAUD_TipoSeleccion AreaProdVencidosIdentif { get => areaProdVencidosIdentif; set => SetProperty(ref areaProdVencidosIdentif, value); }

        // Sanitario para el personal 
        private enumAUD_TipoSeleccion sanitarioPersonal;
        public enumAUD_TipoSeleccion SanitarioPersonal { get => sanitarioPersonal; set => SetProperty(ref sanitarioPersonal, value); }

        //No Comer
        private enumAUD_TipoSeleccion noComer;
        public enumAUD_TipoSeleccion NoComer { get => noComer; set => SetProperty(ref noComer, value); }

        //No Beber
        private enumAUD_TipoSeleccion noBeber;
        public enumAUD_TipoSeleccion NoBeber { get => noBeber; set => SetProperty(ref noBeber, value); }

        //No Fumar
        private enumAUD_TipoSeleccion noFumar;
        public enumAUD_TipoSeleccion NoFumar { get => noFumar; set => SetProperty(ref noFumar, value); }

        //No Fumar
        private enumAUD_TipoSeleccion noGuardarPlantasComidasBebidas;
        public enumAUD_TipoSeleccion NoGuardarPlantasComidasBebidas { get => noGuardarPlantasComidasBebidas; set => SetProperty(ref noGuardarPlantasComidasBebidas, value); }


    }

}
