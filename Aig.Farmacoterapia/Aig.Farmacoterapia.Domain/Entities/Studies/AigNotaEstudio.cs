using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigNota
    {
        [IgnoreDataMember]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Observaciones { get; set; }
        public bool WhiteSpace { get; set; }
        public int PaperSize { get; set; } //Letter = 1, A4 = 9,
    }
    public class AigNotaEstudio
    {
        public AigNotaEstudio()=> Lines ??= new List<AigNota>();
        public DateTime? FechaEvaluacion { get; set; } = DateTime.Today;
        public string? Observaciones { get; set; }
        public string DirectoraNacional { get; set; }
        public string Jefe { get; set; }
        public List<AigNota> Lines { get; set; }
        public string GetNoteCode(long noteNo){
            if (noteNo == default) return string.Empty;
            var noteCode = noteNo.ToString();
            noteCode = noteCode.PadLeft(noteCode.Length+2,'0');
            return $"{noteCode}-FCT-DNFD-{DateTime.Now:yy}";
        }
    }
}