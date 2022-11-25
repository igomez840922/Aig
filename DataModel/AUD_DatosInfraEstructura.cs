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
    /// Datos de Estructura Organizacional del Establecimiento
    /// </summary>
    public class AUD_DatosInfraEstructura : SystemId
    {
        //Escribir el tipo de paredes y el estado en el que está
        private string tipoParedes;
        [StringLength(500)]
        public string TipoParedes { get => tipoParedes; set => SetProperty(ref tipoParedes, value); }
        private string tipoParedesDesc;
        public string TipoParedesDesc { get => tipoParedesDesc; set => SetProperty(ref tipoParedesDesc, value); }

        //Escribir el tipo de cielo raso y el estado en el que está
        private string tipoCieloRaso;
        [StringLength(500)]
        public string TipoCieloRaso { get => tipoCieloRaso; set => SetProperty(ref tipoCieloRaso, value); }
        private string tipoCieloRasoDesc;
        public string TipoCieloRasoDesc { get => tipoCieloRasoDesc; set => SetProperty(ref tipoCieloRasoDesc, value); }


        //Escribir el tipo de pisos y el estado en el que está.
        private string tipoPiso;
        [StringLength(500)]
        public string TipoPiso { get => tipoPiso; set => SetProperty(ref tipoPiso, value); }
        private string tipoPisoDesc;
        public string TipoPisoDesc { get => tipoPisoDesc; set => SetProperty(ref tipoPisoDesc, value); }


        //El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación
        private bool riesgoExterno;
        public bool RiesgoExterno { get => riesgoExterno; set => SetProperty(ref riesgoExterno, value); }

        // Debe dar breve explicación del por qué.
        private string riesgoExternoDescrip;
        public string RiesgoExternoDescrip { get => riesgoExternoDescrip; set => SetProperty(ref riesgoExternoDescrip, value); }

    }
}
