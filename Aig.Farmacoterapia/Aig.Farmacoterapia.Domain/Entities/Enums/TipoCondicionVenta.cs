using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Enums
{
    public static class TipoCondicionVenta
    {
        public const string SinPrescripcion = "SP"; //Sin Prescripción Médica
        public const string ConPrescripcion = "CP"; //Con Prescripción Médica
        public const string UsoHospitalario = "UH"; //Uso Hospitalario Exclusivo
        public const string VentaPopular = "VP"; //Venta Popular
    }
}