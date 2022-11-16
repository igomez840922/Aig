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

    }
}
