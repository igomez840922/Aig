using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamAccionesRegulatoria:SystemId
    {
        // Recomendaciones a Profesionales y Pacientes. Total=3. Si, No, null
        private enumOpcionSiNo recomendacionProPac;
        public enumOpcionSiNo RecomendacionProPac { get => recomendacionProPac; set => SetProperty(ref recomendacionProPac, value); }

        // Actualización de monografía e inserto. Total=3. Si, No, null
        private enumOpcionSiNo actMonografia;
        public enumOpcionSiNo ActMonografia { get => actMonografia; set => SetProperty(ref actMonografia, value); }

        // Consentimiento Informado. Total=3. Si, No, null
        private enumOpcionSiNo consInformado;
        public enumOpcionSiNo ConsInformado { get => consInformado; set => SetProperty(ref consInformado, value); }

        // Suspensión y retiro de lote(s). Total=3. Si, No, null
        private enumOpcionSiNo suspRetiroLote;
        public enumOpcionSiNo SuspRetiroLote { get => suspRetiroLote; set => SetProperty(ref suspRetiroLote, value); }

        // Registro Sanitario (Suspensión/Cancelación). Total=3. Si, No, null
        private enumOpcionSiNo regSanSuspencionCancelacion;
        public enumOpcionSiNo RegSanSuspencionCancelacion { get => regSanSuspencionCancelacion; set => SetProperty(ref regSanSuspencionCancelacion, value); }

        // Otras
        private string otras;
        public string Otras { get => otras; set => SetProperty(ref otras, value); }

        // Observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }
    }
}
