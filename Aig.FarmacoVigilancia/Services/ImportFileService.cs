using ClosedXML.Excel;
using DataAccess;
using DataAccess;
using DataModel;
using DataModel.Models;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using static Duende.IdentityServer.Models.IdentityResources;

namespace Aig.FarmacoVigilancia.Services
{
    public class ImportFileService : IImportFileService
    {
        private readonly IDalService DalService;
        private readonly IApiConnectionService apiConnectionService;
        private readonly IConfiguration configuration;

        public ImportFileService(IDalService dalService, IApiConnectionService apiConnectionService, IConfiguration configuration)
        {
            DalService = dalService;
            this.apiConnectionService = apiConnectionService;
            this.configuration = configuration;
        }


        public async Task ImportRAMEsavi(AttachmentTB attachment)
        {
            try
            {
                using (Stream stream = new FileStream(attachment.AbsolutePath, FileMode.Open))
                {
                    try
                    {
                        using var wbook = new XLWorkbook(stream);
                        var ws1 = wbook.Worksheet(1);
                        var count = ws1.RowCount();
                        for (int row = 2; row < count; row++)
                        {
                            var data = ws1.Row(row);

                            switch ((string)data.Cell(8).GetValue<string>())
                            {
                                case "Vacuna":
                                    {
                                        var esavi = new FMV_Esavi2TB()
                                        {
                                            FechaRecibidoCNFV = (DateTime)data.Cell(1).GetValue<DateTime>(),
                                            //IdFacedra = (string)data.Cell(3).GetValue<string>(),
                                            CodCNFV = (string)data.Cell(3).GetValue<string>(),
                                            Notificador = "Servicio Web",
                                            LVacunas = new List<FMV_EsaviVacunaTB>() {
                                            new FMV_EsaviVacunaTB()
                                            {
                                                VacunaComercial= (string)data.Cell(7).GetValue<string>(),
                                            }
                                        }
                                        };
                                        var tmpEsavi = DalService.Find<FMV_Esavi2TB>(x => x.CodCNFV == esavi.CodCNFV);
                                        if (tmpEsavi == null)
                                        {
                                            DalService.Save(esavi);
                                        }
                                        break;
                                    }
                                case "Medicamento":
                                    {
                                        var ram = new FMV_Ram2TB()
                                        {
                                            FechaRecibidoCNFV = (DateTime)data.Cell(1).GetValue<DateTime>(),
                                            CodigoNotiFacedra = (string)data.Cell(3).GetValue<string>(),
                                            CodigoCNFV = (string)data.Cell(3).GetValue<string>(),
                                            LFarmacos = new List<FMV_RamFarmacoTB>() {
                                                new FMV_RamFarmacoTB()
                                                {
                                                    FarmacoSospechosoComercial= (string)data.Cell(7).GetValue<string>(),
                                                    FarmacoSospechosoDci= (string)data.Cell(7).GetValue<string>(),
                                                }
                                            }
                                        };
                                        var tmpRam = DalService.Find<FMV_Ram2TB>(x => x.CodigoCNFV == ram.CodigoCNFV);
                                        if (tmpRam == null)
                                        {
                                            DalService.Save(ram);
                                        }
                                        break;
                                    }
                            }

                            //TramiteCosto tramiteCosto = new TramiteCosto()
                            //{
                            //    TramiteTipo = (TramiteTipo)data.Cell(1).GetValue<int>(),
                            //    TramiteAccion = (TramiteAccion)data.Cell(2).GetValue<int>(),
                            //    EstablecimientoTipo = (EstablecimientoTipo)data.Cell(3).GetValue<int>(),
                            //    TipoCertificado = (TipoCertificado)data.Cell(4).GetValue<int>(),
                            //    Nombre = data.Cell(5).GetValue<string>(),
                            //    Precio = data.Cell(6).GetValue<decimal>(),
                            //};
                            //await unitOfWork.Repository<TramiteCosto>().SaveUpdate(tramiteCosto);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex) { }
        }

        public async Task<string> TransferRAMEsavi(ImportFVRE data)
        {
            try
            {
                if(!configuration["ApiUrlFadi"].Contains(apiConnectionService.Client.BaseAddress.AbsoluteUri))
                    apiConnectionService.UpdateUrlBase( configuration["ApiUrlFadi"]);
                //apiConnectionService.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token.data.token);

                //var myDict = new Dictionary<string, object>()
                //            {
                //                { "term",filter},
                //                { "pageIndex","1"},
                //                { "pageSize","40"}
                //            };
                StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var result = await apiConnectionService.Client.PostAsync("tramitegen/NuevoFVRE", content);
                var resultContent = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    return null;
                }
                else
                {
                    return resultContent.Replace("\"","");
                }
            }
            catch (Exception ex) { return ex.Message; }
            return "no se pudo crear el trámite";
        }

    }
}
