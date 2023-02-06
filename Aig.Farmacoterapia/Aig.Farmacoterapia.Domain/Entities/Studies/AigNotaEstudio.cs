﻿using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigNotaEstudio
    { 
        public DateTime? FechaEvaluacion { get; set; } = DateTime.Today;
        public string? Observaciones { get; set; }
        public string GetNoteCode(long noteNo){
            if (noteNo == default) return string.Empty;
            var noteCode = noteNo.ToString();
            noteCode = noteCode.PadLeft(noteCode.Length+2,'0');
            return $"{noteCode}-FCT/DNFD-{DateTime.Now:yy}";
        }
    }
}
