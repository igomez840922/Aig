using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_EsaviVacunaTB:SystemId
    {
        public FMV_EsaviVacunaTB()
        {
            LEsavis = new List<FMV_EsaviVacunaEsaviTB>();
        }

        //ESAVI
        private long? esaviId;
        public long? EsaviId { get => esaviId; set => SetProperty(ref esaviId, value); }
        private FMV_Esavi2TB? esavi;
        [JsonIgnore]
        public virtual FMV_Esavi2TB? Esavi { get => esavi; set => SetProperty(ref esavi, value); }


        //Vacuna Sospechosa (Comercial)
        private string vacunaComercial;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string VacunaComercial { get => vacunaComercial; set => SetProperty(ref vacunaComercial, value); }

        
        private long? tipoVacunaId;
        public long? TipoVacunaId { get => tipoVacunaId; set => SetProperty(ref tipoVacunaId, value); }
        private TipoVacunaTB? tipoVacuna;
        public virtual TipoVacunaTB? TipoVacuna { get => tipoVacuna; set => SetProperty(ref tipoVacuna, value); }

        ////Fabricante
        private long? laboratorioId;
        public long? LaboratorioId { get => laboratorioId; set => SetProperty(ref laboratorioId, value); }
        private LaboratorioTB? laboratorio;
        public virtual LaboratorioTB? Laboratorio { get => laboratorio; set => SetProperty(ref laboratorio, value); }

        //Fabricante
        private string lote;
        [StringLength(250)]
        public string Lote { get => lote; set => SetProperty(ref lote, value); }

        // Fecha de Expiración
        private DateTime? fechaExp;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaExp { get => fechaExp; set => SetProperty(ref fechaExp, value); }

        //Registro Sanitario
        private string regSanitario;
        [StringLength(250)]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        // Fecha de Vacunación
        private DateTime? fechaVacunacion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVacunacion { get => fechaVacunacion; set => SetProperty(ref fechaVacunacion, value); }


        //Indicaciones
        private string indicaciones;
        [StringLength(500)]
        public string Indicaciones { get => indicaciones; set => SetProperty(ref indicaciones, value); }

        //Dosis y Vía de Administración
        private string dosisViaAdmin;
        [StringLength(500)]
        public string DosisViaAdmin { get => dosisViaAdmin; set => SetProperty(ref dosisViaAdmin, value); }

        //Dosis en que se presenta el ESAVI
        private enumFMV_DosisNumero dosisPresenta;
        public enumFMV_DosisNumero DosisPresenta { get => dosisPresenta; set => SetProperty(ref dosisPresenta, value); }


        /////////////////////////////
        ///EFECTOS ADVERSOS DE LA VACUNA

        private List<FMV_EsaviVacunaEsaviTB> lEsavis;
        public virtual List<FMV_EsaviVacunaEsaviTB> LEsavis { get => lEsavis; set => SetProperty(ref lEsavis, value); }


    }
}
