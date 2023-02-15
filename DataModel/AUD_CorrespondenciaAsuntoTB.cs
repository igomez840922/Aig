﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_CorrespondenciaAsuntoTB:SystemId
    {
        //nombre
        private string nombre;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        private List<AUD_CorrespondenciaTB> lCorrespondencia;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<AUD_CorrespondenciaTB> LCorrespondencia { get => lCorrespondencia; set => SetProperty(ref lCorrespondencia, value); }
    }
}