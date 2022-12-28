﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class FMV_SocTB : SystemId
	{
		//nombre
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "requerido")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }


        //private List<FMV_EsaviTB> lEsavi;
        //public virtual List<FMV_EsaviTB> LEsavi { get => lEsavi; set => SetProperty(ref lEsavi, value); }

        //private List<FMV_FfTB> lFf;
        //public virtual List<FMV_FfTB> LFf { get => lFf; set => SetProperty(ref lFf, value); }

        //private List<FMV_RamTB> lRam;
        //public virtual List<FMV_RamTB> LRam { get => lRam; set => SetProperty(ref lRam, value); }

    }
}