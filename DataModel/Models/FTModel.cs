using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class FTModel
    {
        public DatosPaciente DatosPaciente { get; set; }
        public DatosMedicamento DatosMedicamento { get; set; }
        public SospechaFallaTerapeutica SospechaFallaTerapeutica { get; set; }
        public DatosNotificador DatosNotificador { get; set; }
                     

        public List<AttachmentTB> LAdjuntos { get; set; }
        public long IdTramite { get; set; }



    }

    public class FTNoteModel
    {
        public string CodCNFV { get; set; }
        public AttachmentTB Adjunto { get; set; }

    }

    public class DatosPaciente
    {
        
        public Persona Paciente { get; set; }

        public enumSexo Sexo { get; set; }
        public string? Edad { get; set; }
        public string? Peso { get; set; }
        public string? Talla { get; set; }
        public string? PA { get; set; }
        public string? FC { get; set; }
        public string? FR { get; set; }
        public string? Temp { get; set; }

        public bool Alergias { get; set; }
        public string? AlergiasDesc { get; set; }

        public bool Embarazo { get; set; }
        public string? EmbarazoDesc { get; set; }
        public bool Alcohol { get; set; }
        public string? AlcoholDesc { get; set; }
        public bool Droga { get; set; }
        public string? DrogaDesc { get; set; }
        public bool Tabaquismo { get; set; }
        public string? TabaquismoDesc { get; set; }
        public bool Diabetes { get; set; }
        public string? DiabetesDesc { get; set; }
        public bool Hta { get; set; }
        public string? HtaDesc { get; set; }
        public bool Hepatico { get; set; }
        public string? HepaticoDesc { get; set; }
        public bool Renal { get; set; }
        public string? RenalDesc { get; set; }
        public bool Cardiaco { get; set; }
        public string? CardiacoDesc { get; set; }
        public bool Respiratorio { get; set; }
        public string? RespiratorioDesc { get; set; }
        public bool Hematologico { get; set; }
        public string? HematologicoDesc { get; set; }
        public bool Gi { get; set; }
        public string? GiDesc { get; set; }
        public bool Piel { get; set; }
        public string? PielDesc { get; set; }
        public bool Neurologico { get; set; }
        public string? NeurologicoDesc { get; set; }
        public bool Otros { get; set; }
        public string? OtrosDesc { get; set; }

    }

    public class DatosMedicamento
    {
        public string NomComercial { get; set; }
        public string? NomDCI { get; set; }
        public string? Presentacion { get; set; }
        public string? Concentracion { get; set; }
        public string? FormaFarmaceutica { get; set; }
        public PaisTB? PaisFabricante { get; set; }
        public LaboratorioTB? Laboratorio { get; set; }
        public string LaboratorioOtro { get; set; }
        public string RegSanitario { get; set; }
        public string Lotes { get; set; }
        public DateTime? FechaExp { get; set; }
        public string? Diagnostigo { get; set; }
        public string? DosisPosologiaIndicada { get; set; }
        public string? DosisPosologiaPrescrita { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }




    }

    public class SospechaFallaTerapeutica
    {
        public SospechaFallaTerapeutica()
        {
            LMedicamentoSospechoso = new List<MedicamentoSospechoso>();
        }

        public string Razones { get; set; }
        public DateTime? FechaFalla { get; set; }

        public bool AmentoDosisMedSospechoso { get; set; }
        public string AmentoDosisMedSospechosoDesc { get; set; }

        public bool CambioMedSospechoso { get; set; }
        public string CambioMedSospechosoDesc { get; set; }

        public List<MedicamentoSospechoso> LMedicamentoSospechoso { get; set; }

        public string Observaciones { get; set; }

    }

    public class MedicamentoSospechoso
    {
        public string NomComercial { get; set; }
        public string NomDCI { get; set; }
        public string RegSanitario { get; set; }
        public string? DosisAdministracion { get; set; }
        public string? ViaAdministracion { get; set; }
        public string? FrecuenciaAdministracion { get; set; }
        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Diagnostico { get; set; }

        public DateTime? FechaRecibo { get; set; }
        public string CodExt { get; set; }
        public string PrincActivo { get; set; }
        public LaboratorioTB? Laboratorio { get; set; }
        public string LaboratorioOtro { get; set; }
    }

    public class DatosNotificador
    {
        public DatosNotificador()
        {
            Notificador = new Persona();
        }

        public Persona Notificador { get; set; }

        public InstitucionDestinoTB? InstalacionSalud { get; set; }
        public ProvinciaTB? Provincia { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public string? Firma { get; set; }
        public enumFMV_RAMNotificationType TipoNotificador { get; set; }

    }

    public class Persona
    {
        public TipoPersona TipoPersona { get; set; }
        public TipoIdentificaion TipoIdentificaion { get; set; }
        public string? NumIdentificacion { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }
        public string? NombreEmpresa { get; set; }
        public string? NumLicencia { get; set; }
        public string? Departamento { get; set; }
        public string? Titulo { get; set; }

        public string NombreCompleto
        {
            get
            {
                string[] nameArray = null;
                switch (this.TipoPersona)
                {
                    case TipoPersona.NAT:
                        {
                            nameArray = new string[] { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };
                            break;
                        }
                    case TipoPersona.JUD:
                        {
                            nameArray = new string[] { NombreEmpresa };
                            break;
                        }
                }
                //string[] nameArray = { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };
                return string.Join(" ", nameArray.Where(s => !string.IsNullOrEmpty(s)));
            }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }


    }

}
