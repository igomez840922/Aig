using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NotaClasificacion:SystemId
    {
        private string nombre;
        [StringLength(250)]
        public string Nombre { 
            get { return Helper.Helper.GetDescription(NoteType); }
            set { SetProperty(ref nombre, value); } 
        }

        private enumFMV_NoteType noteType;
        public enumFMV_NoteType NoteType { get => noteType; set => SetProperty(ref noteType, value); }

        
    }
}
