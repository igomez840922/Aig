using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class MenuOptionModel
    {
        public string Name { get; set; }
        public enumSelectedChapter Chapter { get; set; }
    }

    public class InspectionTypeMenuOptionModel
    {
        public string Name { get; set; }
        public enumAUD_TipoActa InspectionType { get; set; }
    }
}
