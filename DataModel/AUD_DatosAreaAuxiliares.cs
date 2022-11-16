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


    }
}
