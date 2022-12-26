using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_PropositosInspeccion:SystemId
    {
        public AUD_PropositosInspeccion() {
            LPropositos = new List<PropositoInspeccion>();
        }

        private List<PropositoInspeccion> lPropositos;
        public List<PropositoInspeccion> LPropositos { get => lPropositos; set => SetProperty(ref lPropositos, value); }



    }
}
