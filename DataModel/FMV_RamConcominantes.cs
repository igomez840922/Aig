using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamConcominantes : SystemId
    {
        public FMV_RamConcominantes()
        {           
            LProductos = new List<FMV_RamFarmacoConcominante>();
        }

        private List<FMV_RamFarmacoConcominante> lProductos;
        public virtual List<FMV_RamFarmacoConcominante> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

    }
}
