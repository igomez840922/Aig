using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosReclamoProductoRetirado : SystemId
    {
        
        // Persona Encargada
        private enumAUD_TipoSeleccion personaEncargada;
        public enumAUD_TipoSeleccion PersonaEncargada { get => personaEncargada; set => SetProperty(ref personaEncargada, value); }

        // Observaciones
        private string personaEncargadaDesc;
        [StringLength(500)]
        public string PersonaEncargadaDesc { get => personaEncargadaDesc; set => SetProperty(ref personaEncargadaDesc, value); }

        // Si el encargado no es el Regente Farmacéutico, está plasmado en los procedimientos que debe ser informado de estos casos
        private enumAUD_TipoSeleccion regFarmProcedInformado;
        public enumAUD_TipoSeleccion RegFarmProcedInformado { get => regFarmProcedInformado; set => SetProperty(ref regFarmProcedInformado, value); }

        // Observaciones
        private string regFarmProcedInformadoDesc;
        [StringLength(500)]
        public string RegFarmProcedInformadoDesc { get => regFarmProcedInformadoDesc; set => SetProperty(ref regFarmProcedInformadoDesc, value); }

        // Procedimientos para reclamos de productos
        private enumAUD_TipoSeleccion procReclamosProd;
        public enumAUD_TipoSeleccion ProcReclamosProd { get => procReclamosProd; set => SetProperty(ref procReclamosProd, value); }

        // Observaciones
        private string procReclamosProdDesc;
        [StringLength(500)]
        public string ProcReclamosProdDesc { get => procReclamosProdDesc; set => SetProperty(ref procReclamosProdDesc, value); }

        // Procedimientos para el retiro de productos del mercado
        private enumAUD_TipoSeleccion procRetiProdMercado;
        public enumAUD_TipoSeleccion ProcRetiProdMercado { get => procRetiProdMercado; set => SetProperty(ref procRetiProdMercado, value); }

        // Observaciones
        private string procRetiProdMercadoDesc;
        [StringLength(500)]
        public string ProcRetiProdMercadoDesc { get => procRetiProdMercadoDesc; set => SetProperty(ref procRetiProdMercadoDesc, value); }

    }
}
