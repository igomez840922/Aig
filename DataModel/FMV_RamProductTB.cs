using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamProductTB:SystemId
    {
        //Notificaion
        private long ramId;
        public long EvaluadorId { get => ramId; set => SetProperty(ref ramId, value); }
        private FMV_RamTB ram;
        public virtual FMV_RamTB RAM { get => ram; set => SetProperty(ref ram, value); }



    }
}
