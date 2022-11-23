using Aig.Farmacoterapia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Medicament.Model
{
   
    public class HomeFilter : BaseFilter
    {
        public HomeFilter():base() {}
        public bool? MedicalPrescription { get; set; } = null;
        public bool? HospitalUse { get; set; } = null;
        public bool? PopularSale { get; set; } = null;
       
        public bool? ChemicalSynthesis { get; set; } = null;
        public bool? Radiopharmaceuticals { get; set; } = null;
        public bool? Orphans { get; set; } = null;
        public bool? Homeopathic { get; set; } = null;
        public bool? Phytopharmaceuticals { get; set; } = null;
        public bool? Biotechnological { get; set; } = null;
        public bool? Biological { get; set; } = null;

        public bool? Interchangeable { get; set; } = null;
        public bool? Reference { get; set; } = null;
        public bool? Generic { get; set; } = null;
        public bool? Mark { get; set; } = null;

    }
   
}
