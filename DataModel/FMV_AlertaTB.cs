using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_AlertaTB:SystemId
    {
       
        //RAM
        private long? ramId;
        public long? RamId { get => ramId; set => SetProperty(ref ramId, value); }
        private FMV_RamTB? ram;
        public virtual FMV_RamTB? Ram { get => ram; set => SetProperty(ref ram, value); }

       

    }
}
