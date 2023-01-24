using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class ReportModelResponse
    {    
        public int Count { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Lote { get; set; }

        public enumFMV_RAMOrigenType RAMOrigenType { get; set; }
        public enumFMV_RAMNotificationType RAMNotificationType { get; set; }
        public enumFMV_RAMStatus RAMStatus { get; set; }
        public enumSexo Sexo { get; set; }
        public enumFMV_RAMIntensidad RAMIntensidad { get; set; }

        public enumFMV_RAMDesenlace RAMDesenlace { get; set; }

        public enumFMV_EsaviProbabilidadAsociacion EsaviProbabilidadAsociacion { get; set; }

        public enumFMV_FfTipoIncidenciaCaso FfTipoIncidenciaCaso { get; set; }

    }

}
