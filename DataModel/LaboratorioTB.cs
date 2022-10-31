﻿using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LaboratorioTB:SystemId
    {
        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        private enum_UbicationType tipoUbicacion;
        public enum_UbicationType TipoUbicacion { get => tipoUbicacion; set => SetProperty(ref tipoUbicacion, value); }

        //nombre de establecimiento
        private string pais;
        [StringLength(250)]
        public string Pais { get => pais; set => SetProperty(ref pais, value); }

        private enum_LaboratoryType tipoLaboratorio;
        public enum_LaboratoryType TipoLaboratorio { get => tipoLaboratorio; set => SetProperty(ref tipoLaboratorio, value); }

        //antigua BD
        private int idEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int IdEmpresa { get => idEmpresa; set => SetProperty(ref idEmpresa, value); }


        private List<FMV_PmrProductoTB> lProductos;
        public virtual List<FMV_PmrProductoTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        private List<FMV_IpsTB> lIps;
        public virtual List<FMV_IpsTB> LIps { get => lIps; set => SetProperty(ref lIps, value); }

        private List<FMV_RfvTB> lRfv;
        public virtual List<FMV_RfvTB> LRfv { get => lRfv; set => SetProperty(ref lRfv, value); }


    }
}