﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_ProdRetiroRetencionTB:SystemId
    {
        //Formulario de retencion / retiro
        private long frmRetiroRetencionId;
        public long FrmRetiroRetencionId { get => frmRetiroRetencionId; set => SetProperty(ref frmRetiroRetencionId, value); }
        private AUD_InspRetiroRetencionTB frmRetiroRetencion;
        [JsonIgnore]
        public virtual AUD_InspRetiroRetencionTB FrmRetiroRetencion { get => frmRetiroRetencion; set => SetProperty(ref frmRetiroRetencion, value); }

        //nombre del producto
        private string nombre;
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //presentacion comercial
        private string presentacionComercial;
        [StringLength(250)]
        public string PresentacionComercial { get => presentacionComercial; set => SetProperty(ref presentacionComercial, value); }

        //fabricante
        private string fabricante;
        [StringLength(250)]
        public string Fabricante { get => fabricante; set => SetProperty(ref fabricante, value); }

        //pais de fabricación
        private long? paisId;
        public long? PaisId { get => paisId; set => SetProperty(ref paisId, value); }
        private PaisTB? pais;
        public virtual PaisTB? Pais { get => pais; set => SetProperty(ref pais, value); }

        //lote
        private string lote;
        [StringLength(250)]
        public string Lote { get => lote; set => SetProperty(ref lote, value); }

        //fecha de Expiración
        private DateTime? fechaExp;
        public DateTime? FechaExp { get => fechaExp; set => SetProperty(ref fechaExp, value); }

        //cantidad Retenida
        private string cantidadRetenida;
        [StringLength(250)]
        public string CantidadRetenida { get => cantidadRetenida; set => SetProperty(ref cantidadRetenida, value); }

        //cantidad Retirada
        private string cantidadRetirada;
        [StringLength(250)]
        public string CantidadRetirada { get => cantidadRetirada; set => SetProperty(ref cantidadRetirada, value); }

        //motivo retencion o retiro
        private string motivo;
        [StringLength(500)]
        public string Motivo { get => motivo; set => SetProperty(ref motivo, value); }

        //destino del producto
        private string destino;
        [StringLength(250)]
        public string Destino { get => destino; set => SetProperty(ref destino, value); }
    }
}
