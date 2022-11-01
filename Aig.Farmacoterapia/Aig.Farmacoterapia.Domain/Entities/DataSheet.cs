using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class DataSheet
    {
        /// <summary>
        /// Name of the medication
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Qualitative and quantitative composition
        /// </summary>
        public string Composition { get; set; }
        /// <summary>
        /// Pharmaceutical Form
        /// </summary>
        public string PharmaceuticalForm { get; set; }
        /// <summary>
        /// Active Principles
        /// </summary>
        public string ActivePrinciples { get; set; }
        /// <summary>
        /// Excipients products
        /// </summary>
        public string Excipients { get; set; }
        
        /// <summary>
        /// Pharmacological Properties
        /// </summary>
        public string PharmacologicalProperties { get; set; }
        /// <summary>
        /// Pharmacodynamic and pharmacokinetic properties
        /// </summary>
        public string PharmacodynamicProperties { get; set; }
        /// <summary>
        /// Therapeutic Indications
        /// </summary>
        public string TherapeuticIndications { get; set; }
        /// <summary>
        /// Contraindications
        /// </summary>
        public string Contraindications { get; set; }
        /// <summary>
        /// Special warnings and precautions
        /// </summary>
        public string SpecialWarning { get; set; }
        /// <summary>
        /// Pregnancy and lactation
        /// </summary>
        public string PregnancyAndLactation { get; set; }

        /// <summary>
        /// Effects on ability to drive
        /// </summary>
        public string EffectsOnDrive { get; set; }
        /// <summary>
        /// Interaction with other medicinal products and other forms of interaction
        /// </summary>
        public string Interaction { get; set; }

        /// <summary>
        /// Adverse Reactions
        /// </summary>
        public string AdverseReactions { get; set; }
        /// <summary>
        /// Dosage and method of administration
        /// </summary>
        public string Dosage { get; set; }
        /// <summary>
        /// Overdose
        /// </summary>
        public string OverDose { get; set; }
    }
}
