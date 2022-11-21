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
        public bool MedicalPrescription { get; set; } = false;
        public bool NotMedicalPrescription { get; set; } = false;
        public bool HospitalUse { get; set; } = false;
        public bool NotHospitalUse { get; set; } = false;
        public bool PopularSale { get; set; } = false;
        public bool NotPopularSale { get; set; } = false;

        public bool ChemicalSynthesis { get; set; } = false;
        public bool NotChemicalSynthesis { get; set; } = false;
        public bool Radiopharmaceuticals { get; set; } = false;
        public bool NotRadiopharmaceuticals { get; set; } = false;
        public bool Orphans { get; set; } = false;
        public bool NotOrphans { get; set; } = false;
        public bool Homeopathic { get; set; } = false;
        public bool NotHomeopathic { get; set; } = false;
        public bool Phytopharmaceuticals { get; set; } = false;
        public bool NotPhytopharmaceuticals { get; set; } = false;
        public bool Biotechnological { get; set; } = false;
        public bool NotBiotechnological { get; set; } = false;
        public bool Biological { get; set; } = false;
        public bool NotBiological { get; set; } = false;

        public bool Interchangeable { get; set; } = false;
        public bool NotInterchangeable { get; set; } = false;
        public bool Reference { get; set; } = false;
        public bool NotReference { get; set; } = false;
        public bool Generic { get; set; } = false;
        public bool NotGeneric { get; set; } = false;

    }
   
}
