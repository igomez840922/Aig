using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_FarmaceuticoTablas:SystemId
    {
        public AUD_FarmaceuticoTablas()
        {
            LFarmaceuticos = new List<AUD_Farmaceutico>();
        }

        private List<AUD_Farmaceutico> lFarmaceuticos;
        public List<AUD_Farmaceutico> LFarmaceuticos { get => lFarmaceuticos; set => SetProperty(ref lFarmaceuticos, value); }

    }
}
