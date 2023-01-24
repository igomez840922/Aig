using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Reflection.Metadata;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MimeKit;
using System;
using Org.BouncyCastle.Utilities;
using System.IO;
using Microsoft.Net.Http.Headers;
using Aig.Auditoria.Pages.Inspections;

namespace Aig.Auditoria.Services
{    
    public class PdfGenerationService : IPdfGenerationService
    {
        private readonly IDalService DalService;
        private readonly IWebHostEnvironment env;
        public PdfGenerationService(IDalService dalService, IWebHostEnvironment env)
        {
            DalService = dalService;
            this.env = env;
        }

        public async Task<Stream> GenerateInspectionPDF(long InspectionId)
        {
            try
            {
                var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);
                switch (inspection.TipoActa)
                {
                    case DataModel.Helper.enumAUD_TipoActa.RR:
                        {
                            return await GenerateRetentionReceptionPDF(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AF:
                    case DataModel.Helper.enumAUD_TipoActa.CUF:
                        {
                            inspection.InspAperCambUbicFarm.DatosSolicitante = inspection.InspAperCambUbicFarm.DatosSolicitante != null ? inspection.InspAperCambUbicFarm.DatosSolicitante : new AUD_DatosSolicitante();

                            return await GenerateAperturaCambioUbicacionFarmacia(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AA:
                    case DataModel.Helper.enumAUD_TipoActa.CUA:
                        {
                            inspection.InspAperCambUbicAgen.DatosSolicitante = inspection.InspAperCambUbicAgen.DatosSolicitante != null ? inspection.InspAperCambUbicAgen.DatosSolicitante : new AUD_DatosSolicitante();

                            return await GenerateAperturaCambioUbicacionAgencia(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.INV:
                        {                            
                            return await GenerateInvestigaciones(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AFM:
                    case DataModel.Helper.enumAUD_TipoActa.AFC:
                        {
                            inspection.InspAperFabricante.DatosSolicitante = inspection.InspAperFabricante.DatosSolicitante != null ? inspection.InspAperFabricante.DatosSolicitante : new AUD_DatosSolicitante();

                            return await GenerateAperturaFabricantesMedicamentos(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMCD:
                        {
                            
                            return await GenerateGuiaFabricantesCosmeticosDesinfectantes(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AECA:
                        {
                            return await GenerateAperturaCosmeticosArtesanales(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMMN:
                        {
                            return await GenerateGuiaFabricantesProdNaturalesMedicinales(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.VF:
                        {
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.VA:
                        {
                            return await GenerateRutinaVigilanciaAgencia(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.COP:
                        {
                            return await GenerateCierreOperaciones(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.DFP:
                        {
                            return await GenerateDisposicionFinalProd(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMFM:
                        {
                            return await GenerateGuiaFabricantesMedicamentos(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPMAM:
                        {
                            return await GenerateGuiaLabAcondicionadores(inspection);
                            break;
                        }
                    case DataModel.Helper.enumAUD_TipoActa.BPA:
                        {
                            return await GenerateGuiaBPM_BPA(inspection);
                            break;
                        }
                }
            }
            catch { }
            return null;
        }

        //generamos el pdf del Acta de Retiro y Retencion de Productos
        private async Task<Stream> GenerateRetentionReceptionPDF(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                  {
                      container.Page(page =>
                      {
                          page.Size(PageSizes.A4);
                          page.Margin(5, Unit.Millimetre);
                          page.PageColor(Colors.White);
                          page.DefaultTextStyle(x => x.FontSize(8));
                          //page.DefaultTextStyle(x => x.Color("Black"));

                          var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");
                          
                          page.Header().Table(table =>
                          {
                              table.ColumnsDefinition(columns =>
                              {
                                  columns.RelativeColumn();
                                  columns.RelativeColumn();
                                  columns.RelativeColumn();
                              });

                              table.Header(header =>
                              {
                                  header.Cell().Image(path);
                                  header.Cell().AlignCenter().Text("");
                                  header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa,DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                              });
                              
                              table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                              table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                              table.Cell().ColumnSpan(3).AlignCenter().Text("ACTA DE RETENCIÓN Y/O RETIRO DE PRODUCTOS FARMACÉUTICOS").Bold();
                          });
                                                   
                          page.Content().PaddingVertical(8).Column(column =>
                              {
                                  string participantes = "";
                                  if (inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes!=null)
                                  {
                                      foreach(var partic in inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes)
                                      {
                                          participantes += partic.NombreCompleto + ", ";
                                      }
                                  }

                                  column.Item().Text(string.Format("Siendo las {0} del día {1} de {2} de {3}, actuando en representación de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud, procedimos a efectuar la {4}, de los productos a continuación descritos y que fueron localizados en el establecimiento denominado: {5}, ubicado en: {6}, con Aviso de Operación No. {7} y Licencia de operación {8}/DNFD. Y cuyo Representante Legal es {9} con documento de identidad personal N° {10}. Por la Dirección Nacional de Farmacia y Drogas, participamos: {11}. Y fuimos atendidos por: {12}, con cargo {13} cip: {14}\r\n",
                                      inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.ToString("dd"), Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.ToString("yyyy"), DataModel.Helper.Helper.GetDescription(inspection.InspRetiroRetencion.RetiroRetencionType), inspection.Establecimiento?.Nombre??"", inspection.UbicacionEstablecimiento,inspection.AvisoOperacion, inspection.LicenseNumber, inspection.InspRetiroRetencion.DatosRepresentLegal.Nombre, inspection.InspRetiroRetencion.DatosRepresentLegal.Cedula, participantes, inspection.InspRetiroRetencion.DatosAtendidosPor.Nombre, inspection.InspRetiroRetencion.DatosAtendidosPor.Cargo, inspection.InspRetiroRetencion.DatosAtendidosPor.Cedula));

                                  column.Item().Table(table =>
                                  {
                                      table.ColumnsDefinition(columns =>
                                      {
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                          columns.RelativeColumn();
                                      });

                                      table.Header(header =>
                                      {
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Nombre del Producto").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Presentación Comercial").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Fabricante").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("País de Fabricación").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Lote").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Fecha de Exp.").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cant. Retenida").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cant. Retirada").Bold();
                                          header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Motivo de la Retención y/o Retiro").Bold();

                                      });

                                      //table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                                      if(inspection.InspRetiroRetencion!=null && inspection.InspRetiroRetencion.LProductos != null)
                                      {
                                          foreach(var prod in inspection.InspRetiroRetencion.LProductos)
                                          {
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Nombre);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.PresentacionComercial);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Fabricante);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Pais);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Lote);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.FechaExp?.ToString("dd/MM/yyyy")??"");
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.CantidadRetenida);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.CantidadRetirada);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Motivo);

                                              static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                                          }
                                      }  
                                  
                                  });

                                  column.Item().PaddingVertical(5).Text(string.Format("Los productos retenidos y retirados del establecimiento se mantendrán bajo custodia en las instalaciones de la Dirección Nacional de Farmacia y Drogas, hasta culminar las investigaciones.\r\nLos productos farmacéuticos que se mantengan retenidos en el local no podrán ser movidos del lugar donde se fijó su ubicación al momento de levantar este documento.\r\n"));

                                  ////////////////////////////
                                  ///

                                  column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                                  column.Item().Table(table =>
                                  {
                                      table.ColumnsDefinition(columns =>
                                      {
                                          columns.RelativeColumn(1);
                                          columns.RelativeColumn(1);
                                          columns.RelativeColumn(1);
                                      });
                                      
                                      table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                      if (!string.IsNullOrEmpty(inspection.InspRetiroRetencion.DatosAtendidosPor.Firma))
                                      {
                                          //var bytes = Convert.FromBase64String(base64encodedstring);
                                          //var contents = new StreamContent(new MemoryStream(bytes));
                                          byte[] data = Convert.FromBase64String(inspection.InspRetiroRetencion.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                          MemoryStream memoryStream = new MemoryStream(data);
                                          table.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitWidth);
                                      }
                                      else
                                      {
                                          table.Cell().AlignLeft().Text("");
                                      }
                                      if (!string.IsNullOrEmpty(inspection.InspRetiroRetencion.DatosRegente.Firma))
                                      {
                                          //var bytes = Convert.FromBase64String(base64encodedstring);
                                          //var contents = new StreamContent(new MemoryStream(bytes));
                                          byte[] data = Convert.FromBase64String(inspection.InspRetiroRetencion.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                          MemoryStream memoryStream = new MemoryStream(data);
                                          table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                      }
                                      else
                                      {
                                          table.Cell().AlignLeft().Text("");
                                      }

                                      table.Cell().AlignLeft().Text("");

                                      table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Cargo:{2}", inspection.InspRetiroRetencion.DatosAtendidosPor.Nombre, inspection.InspRetiroRetencion.DatosAtendidosPor.Cedula, inspection.InspRetiroRetencion.DatosAtendidosPor.Cargo));
                                      table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Cargo:{2} | Reg.:{3}", inspection.InspRetiroRetencion.DatosRegente.Nombre, inspection.InspRetiroRetencion.DatosRegente.Cedula, inspection.InspRetiroRetencion.DatosRegente.Cargo, inspection.InspRetiroRetencion.DatosRegente.NumRegistro));

                                      table.Cell().AlignLeft().Text("");

                                      table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                      if (inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes !=null)
                                      {
                                          table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();

                                          foreach (var participant in inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes)
                                          {
                                              table.Cell().Table(tbl =>
                                              {
                                                  tbl.ColumnsDefinition(columns =>
                                                  {
                                                      columns.RelativeColumn(1);
                                                  });
                                                  if (!string.IsNullOrEmpty(participant.Firma))
                                                  {
                                                      byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                      MemoryStream memoryStream = new MemoryStream(data);
                                                      tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                                  }
                                                  tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                              });
                                          }                                          
                                      }

                                  });

                                  column.Item().PaddingVertical(5).Text(" ");
                                  column.Item().AlignBottom().Table(table =>
                                  {
                                      table.ColumnsDefinition(columns =>
                                      {
                                          columns.RelativeColumn(1);
                                          columns.RelativeColumn((float)1.5);
                                      });

                                      table.Cell().AlignLeft().Text(" ");

                                      table.Cell().Border(1).BorderColor(Colors.Black).Padding(10).AlignBottom().AlignLeft().Column(col =>
                                      {
                                          col.Item().AlignLeft().Text("Para uso de la Administración de la DNFD:").Bold();
                                          col.Item().PaddingTop(5).Text("Productos recibidos por (nombre): _____________________________________________________________");
                                          col.Item().PaddingTop(15).Text("(firma): ___________________________________________________________________________________________");
                                          col.Item().PaddingTop(15).Text("Fecha (dd/MM/yyyy): __________________________     Hora: __________________________");
                                      });

                                  });

                              });

                      });
                  })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }

        //generamos el pdf del Acta de Apertura o Cambio de Ubicacion de Farmacia
        private async Task<Stream> GenerateAperturaCambioUbicacionFarmacia(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("ACTA PARA LA VERIFICACIÓN DE LOS REQUISITOS ESTRUCTURALES DE APERTURA O MODIFICACIÓN POR CAMBIO DE UBICACIÓN DE FARMACIA").Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));
                            column.Item().AlignLeft().Text(string.Format("No. Recibo: {0}", inspection.InspAperCambUbicFarm.ReciboPago));
                            
                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}",DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.7);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("GENERALIDADES DE LA FARMACIA Y SOLICITANTE").Bold();
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("NOMBRE DEL ESTABLECIMIENTO");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Provincia?.Nombre??"");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Distrito?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Corregimiento?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Ubicacion);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.Establecimiento.Telefono1, inspection.Establecimiento.Telefono2));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("NOMBRE DE SOLICITANTE");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tipo"); 
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosSolicitante.Tipo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Nacionalidad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Nacionalidad);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cédula de Identidad Personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Cedula);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Correo electrónico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Email);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Residencia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.PaisResidencia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Provincia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Distrito);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Corregimiento);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Direccion);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.InspAperCambUbicFarm.DatosSolicitante.TelefonoResid, inspection.InspAperCambUbicFarm.DatosSolicitante.TelefonoMovil));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Profesión");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSolicitante.Profesion);

                                table.Footer(footer =>
                                {
                                    footer.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ley 66 de 10 de noviembre de 1947. Código Sanitario de la República de Panamá. (G.O. 10467 de 6 de diciembre de 1947). Artículo 200. Prohíbese ejercer conjuntamente las profesiones de médico-cirujano y farmacéutico. A partir de la aprobación de este código, ningún médico que ejerza la profesión podrá ser dueño por sí mismo o por interpuesta persona, accionista o tener participación comercial cualquiera en establecimientos en que se fabriquen, preparen o vendan medicinas y artículos de cualquier clase que se usen para la prevención o curación de enfermedades, corrección de defectos o para el diagnóstico");
                                });
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.7);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("DATOS SOBRE EL REGENTE FARMACÉUTICO DE LA EMPRESA").Bold();
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Nombre");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Registro de Idoneidad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.NumRegistro);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cédula de Identidad Personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Cedula);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Correo electrónico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Email);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Residencia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.PaisResidencia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Provincia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Distrito);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Corregimiento);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosRegente.Ubicacion);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.InspAperCambUbicFarm.DatosRegente.TelefonoOfic, inspection.InspAperCambUbicFarm.DatosRegente.TelefonoMovil));
                                                                
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ESTRUCTURA ORGANIZACIONAL DE LA FARMACIA").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PREGUNTA");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de su letrero de identificación visible al público");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.LetreroIdentificacion?"Si":"No");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.LetreroIdentificacionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El horario de operación coincide con lo señalado en la solicitud de licencia de operación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.HorarioOpeIgualSolic ? "Si" : "No");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.HorarioOpeIgualSolicDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.UtilizaPlatafComercial ? "Si" : "No");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.UtilizaPlatafComercialDesc);

                                string horarioAtenc = "";
                                if (inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.HorariosAtencion != null)
                                {
                                    foreach (var data in inspection.InspAperCambUbicFarm.DatosEstructuraOrganizacional.HorariosAtencion)
                                    {
                                        horarioAtenc += string.Format("{0} {1} \r\n", data.Dias, data.Horarios);
                                    }
                                }
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Horario de Atención");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(horarioAtenc);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022.");
                                
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("INFRAESTRUCTURA DE LA FARMACIA").Bold();
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tipo de paredes");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.TipoParedes);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Estado");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.TipoParedesDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tipo de cielo raso");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.TipoCieloRaso);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Estado");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.TipoCieloRasoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tipo de pisos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.TipoPiso);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Estado");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.TipoPisoDesc);

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación:");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.RiesgoExterno?"Si":"No");

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("De ser SÍ. Explicar?");
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosInfraEstructura.RiesgoExternoDescrip);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.5);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA FÍSICA DE LA FARMACIA").Bold();
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PREGUNTA");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Iluminación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaFisica.PresentaIluminacion?"Si":"No");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaFisica.PresentaIluminacionDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Mobiliario de medicamentos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaFisica.MobiliarioMedicamentos ? "Si" : "No");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaFisica.MobiliarioMedicamentosDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tipo de mobiliario");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaFisica.TipoMoviliario);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Estado de mobiliario");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaFisica.TipoMoviliarioEstado);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las cajas donde se dispondrán los medicamentos próximos a la ubicación en el recetario no deben obstruir el libre tránsito del personal por el área");

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.7);
                                    columns.RelativeColumn((float)0.3);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PREGUNTAS").Bold();
                                });

                                //Preguntas
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Anuncio visible y legible frente al recetario con la siguiente instrucción: “El usuario que adquiera un medicamento de los regulados que se venden sin receta médica lo hace bajo su responsabilidad”. Art. 151 de la Ley 1 de 10 de enero de 2001.");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AnuncioVisibleLeyArt151 ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AnuncioVisibleTablaPromPrecio ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Anuncio visible y legible de Art. 1 y Art. 2 de Ley 17 de 12 de septiembre de 2014. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AnuncioVisibleLeyArt1 ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Farmacia Privada: Anuncio visible y legible Art. 655 y Art. 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022.");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AnuncioVisibleLeyArt656 ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.RegistroTempHumedadRelat ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.ProgramaCalibracion ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. No incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.EspacioFisicoMin20 ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área administrativa del farmacéutico identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AreaGestionAdmin ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área separada para la alimentación del personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AreaSeparadaAlimentPersonal ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales). Será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.SanitarioPersonal ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Aire acondicionado para mantener las condiciones de almacenamiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AireAcondicionadoCondAliment ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos).");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.ExtintoresIncendio ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Alarmas contra incendios o detector de humo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.AlarmaIntrusoIncendio ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Luces de emergencia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosPreguntasGenericas.LucesEmergencias ? "Si" : "No");

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("La farmacia debe contar con un programa de mantenimiento preventivo que incluya cualquier desperfecto o condiciones no adecuadas de las estructuras");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Señalizaciones o avisos de No comer, No beber, No fumar, No guardar plantas, comida y bebidas, Prohibido el ingreso de animales");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.NoComerInstalac ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.ExisteSistemaControlFauna ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de Asesoría Farmacéutica delimitada e identificada que permita la interacción privada entre farmacéutico y paciente)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.AreaAsesoriaFarmaceutica ? "Si" : "No");

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("La información dada por el paciente será manejada de manera confidencial");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de Consultas bibliográficas: Física (Texto) ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.AreaConsultasBibliograficasTxt ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de Consultas bibliográficas: Electrónica (Internet) ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.AreaProductosVencidos ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área delimitada, segregada e identificada de productos vencidos (devolución)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.AreaProductosVencidos ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área Refrigeradora para productos que requieren condiciones especiales de temperatura");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.RefrigeradoraProductosEspeciales ? "Si" : "No");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("La farmacia estructuralmente tiene relación directa o conexión con clínica.");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosSenalizacionAvisos.RefrigeradoraProductosEspeciales ? "Si" : "No");

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Debe existir un sistema de registro cronológico que permita documentar la frecuencia con que se realiza la limpieza en las áreas de farmacia. Estas áreas deben mantenerse limpias y libres de polvo. Los productos de limpieza utilizados deben prevenir la contaminación de las zonas");
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se prohíbe la aplicación de medicamentos parenterales en la farmacia o que esta mantenga relación directa con clínicas");
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("La venta de muestra médica al consumidor sea en establecimientos farmacéuticos o no farmacéuticos, en instalaciones de salud, en clínicas medicas publicas o privadas, es considerada una infracción a las normas de publicidad establecidas en la ley objeto de reglamentación, y como tal, acarreará la sanción respectiva");
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las muestras médicas solo serán almacenadas en agencias distribuidoras que posean licencias de operación vigente. Las casas farmacéuticas que deseen importar, almacenar,manejar y distribuir las muestras médicas de sus productos deben obtener licencia de operación como distribuidora.");
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("La farmacia desechará los empaques secundarios vacíos de medicamentos y no deberá guardarlos, las cajas vacías de medicamentos deben ser debidamente cortadas para evitar prácticas de incentivos monetarios por parte de las agencias distribuidoras o laboratorios fabricantes para su promoción, también aplica para cualquier otra forma de incentivo. Tampoco podrán mantener material promocional visible, ni accesible al público de medicamentos de venta bajo receta médica para evitar el uso y abuso de medicamentos");
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("La farmacia no debe comercializar medicamentos sin registro sanitario");

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                    columns.RelativeColumn((float)0.5);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("AREA DE PRODUCTOS CONTROLADOS (CUANDO APLIQUE).").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PREGUNTA");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Preguntas
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaIdentificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaIdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaDelimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaDelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaAsegurada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Asegurado bajo llave u otro sistema de seguridad comprobada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaAseguradaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaAsegurada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Posee un área identificada de vencidos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaAseguradaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaIndependiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Independiente de otras áreas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaIndependienteDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaIluminaVentila));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Iluminación y Ventilación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.AreaIluminaVentilaDesc);

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Medidas aproximadas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("Largo: {0}, Ancho: {1}, Alto: {2}", inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.DimLargo.ToString("F2"), inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.DimAncho.ToString("F2"), inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.DimAltura.ToString("F2")));

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Descripción del lugar donde se almacenan y las medidas de seguridad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaProductosControlados.LugarAlmacenMedidasSegDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                    columns.RelativeColumn((float)0.5);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACEN DE MEDICAMENTOS Y OTROS PRODUCTOS PARA LA SALUD HUMANA. (CUANDO APLIQUE).").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PREGUNTA");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Preguntas
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.EspacioFisicoAdecuado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El espacio físico de almacenamiento es adecuado para el movimiento y operaciones del personal permitiendo un despacho oportuno a las estanterías del área de recetario");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.EspacioFisicoAdecuadoDesc);

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Medidas aproximadas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("Largo: {0}, Ancho: {1}, Alto: {2}", inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.DimLargo.ToString("F2"), inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.DimAncho.ToString("F2"), inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.DimAltura.ToString("F2")));

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("En el área de almacenamiento debe existir un sistema de inventario que permita determinar la vigencia de los medicamentos de tal forma que puedan abastecer o retirar los mismos en tiempo oportuno (de acuerdo con las políticas de devolución). Se almacenarán las existencias utilizando los sistemas FIFO (primero que entra que sale) o FEFO (primero que expira primero que sale)");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.TempHumedadRelat));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo tres veces al día");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.TempHumedadRelatDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.LimpioOrdenado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpio y ordenado");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.LimpioOrdenadoDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.Iluminacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Iluminación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.IluminacionDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.ProdSobreAnaqueles));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas u otros. Manteniendo suficiente distancia de paredes, piso y techo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.ProdSobreDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.CondParedesPisoTecho));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos.");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.CondParedesPisoTechoDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.CortinaAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (cuando aplique).");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.CortinaAireDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.ExtintoresIncendio));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos).");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.ExtintoresIncendioDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AlarmaIncendio));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Alarmas contra incendios o detector de humo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AlarmaIncendioDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.LucesEmergencias));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Luces de emergencia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.LucesEmergenciasDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.ControlFaunaNociva));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.ControlFaunaNocivaDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AreaCuarentena));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de cuarentena identificada, delimitada y asegurada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AreaCuarentenaDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AreaProdControlados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de productos controlados, delimitada y asegurada bajo llave");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AreaProdControladosDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.Alcohol));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de almacenamiento de Alcohol o productos inflamables separada con ventilación adecuada que evite la exposición a los vapores");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AlcoholDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AltoNivelInventario));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.AltoNivelInventarioDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.Vencidos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Área de vencidos o deteriorados separada e identificada. Asegurada bajo llave");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosAreaAlmacenamiento.VencidosDescrip);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("El establecimiento se compromete al fiel cumplimiento del Artículo 639 del Decreto Ejecutivo 115 De 16 de agosto de 2022");
                                //table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Firma del Regente");
                                //if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosRegente.Firma))
                                //{
                                //    //var bytes = Convert.FromBase64String(base64encodedstring);
                                //    //var contents = new StreamContent(new MemoryStream(bytes));
                                //    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                //    MemoryStream memoryStream = new MemoryStream(data);
                                //    table.Cell().AlignLeft().Image(memoryStream);
                                //}
                                //else
                                //{
                                //    table.Cell().Text("");
                                //}
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicFarm.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("SEGÚN CRITERIO TÉCNICO SE CONCLUYE QUE").Bold();
                                });

                                if (inspection.InspAperCambUbicFarm.DatosConclusiones.CumpleRequisitosMinOperacion)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL LOCAL CUMPLE ESTRUCTURALMENTE CON LOS REQUISITOS MÍNIMOS PARA OPERAR").Bold();
                                }
                                else
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL LOCAL NO CUMPLE ESTRUCTURALMENTE CON LOS REQUISITOS MÍNIMOS PARA OPERAR").Bold();
                                }

                            });

                            column.Item().PaddingVertical(5).Text("OBSERVACIÓN:").Bold();
                            column.Item().Text("El Acta original se mantendrá en el expediente del establecimiento que permanece en la Dirección Nacional de Farmacia y Drogas y se hace entrega de una copia al firmante de esta acta, al finalizar la inspección").Bold();

                            column.Item().PaddingVertical(5).Text("DE NO CUMPLIR CON LOS REQUISITOS MÍNIMOS ESTRUCTURALES EN ESTA ACTA, EL USUARIO DEBERÁ SUBSANAR TODOS LOS PUNTOS PENDIENTES, PARA SU DEBIDA VERIFICACIÓN EN UNA SEGUNDA INSPECCIÓN. DE REINCIDIR EN LAS DESVIACIONES IDENTIFICADAS EN LA PRIMERA INSPECCIÓN, SE PROCEDERÁ A LA DEVOLUCIÓN DE LA SOLICITUD Y EL INTERESADO DEBERÁ REINICIAR EL TRÁMITE CON TODOS LOS REQUISITOS ESTABLECIDOS PARA EL MISMO").Bold();


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosAtendidosPor?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitArea);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }


                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosRegente?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }


                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Cargo:{2}", inspection.InspAperCambUbicFarm.DatosAtendidosPor?.Nombre, inspection.InspAperCambUbicFarm.DatosAtendidosPor?.Cedula, inspection.InspAperCambUbicFarm.DatosAtendidosPor?.Cargo));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Cargo:{2} | Reg.:{3}", inspection.InspAperCambUbicFarm.DatosRegente.Nombre, inspection.InspAperCambUbicFarm.DatosRegente.Cedula, inspection.InspAperCambUbicFarm.DatosRegente.Cargo, inspection.InspAperCambUbicFarm.DatosRegente.NumRegistro));

                                table.Cell().AlignLeft().Text("");

                            });

                            column.Item().PaddingVertical(5).Text(" ").Bold();

                            if (inspection.InspAperCambUbicFarm.DatosConclusiones.LParticipantes != null)
                            {
                                column.Item().Table(table => {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();

                                    foreach (var participant in inspection.InspAperCambUbicFarm.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));
                                        });                                        
                                    }
                                });
                            }

                            column.Item().PaddingVertical(5).Text(string.Format("Hora de finalización de inspección: {0}", inspection.InspAperCambUbicFarm.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt")??""));

                            column.Item().PaddingVertical(5).Text("Fundamento Legal").Bold();
                            column.Item().Text("Ley 66 de 10 de noviembre de 1947 \r\nLey 1 de 10 de enero de 2001 \r\nLey 17 de 12 de septiembre de 2014 \r\nLey 24 de 29 de enero de 1963 \r\nDecreto Ejecutivo 115 de 16 de agosto de 2022 \r\nResolución No. 774 de 7 de octubre de 2019");

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });

                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf del Acta de Apertura o Cambio de Ubicacion de Agencia
        private async Task<Stream> GenerateAperturaCambioUbicacionAgencia(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("ACTA PARA LA VERIFICACIÓN DE LOS REQUISITOS ESTRUCTURALES DE APERTURA O MODIFICACIÓN POR CAMBIO DE UBICACIÓN DE AGENCIA DISTRIBUIDORA").Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));
                            column.Item().AlignLeft().Text(string.Format("No. Recibo: {0}", inspection.InspAperCambUbicAgen.ReciboPago));
                            
                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.7);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("GENERALIDADES DE LA FARMACIA Y SOLICITANTE").Bold();
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("NOMBRE DEL ESTABLECIMIENTO");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Provincia?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Distrito?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Corregimiento?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Ubicacion);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.Establecimiento.Telefono1, inspection.Establecimiento.Telefono2));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("NOMBRE DE SOLICITANTE");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tipo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosSolicitante.Tipo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Nacionalidad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Nacionalidad);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cédula de Identidad Personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Cedula);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Correo electrónico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Email);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Residencia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.PaisResidencia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Provincia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Distrito);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Corregimiento);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Direccion);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.InspAperCambUbicAgen.DatosSolicitante.TelefonoResid, inspection.InspAperCambUbicAgen.DatosSolicitante.TelefonoMovil));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Profesión");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosSolicitante.Profesion);

                                table.Footer(footer =>
                                {
                                    footer.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ley 66 de 10 de noviembre de 1947. Código Sanitario de la República de Panamá. (G.O. 10467 de 6 de diciembre de 1947). Artículo 200. Prohíbese ejercer conjuntamente las \r\nprofesiones de médico-cirujano y farmacéutico. A partir de la aprobación de este código, ningún médico que ejerza la profesión podrá ser dueño por sí mismo o por interpuesta persona, accionista o tener participación comercial cualquiera en establecimientos en que se fabriquen, preparen o vendan medicinas y artículos de cualquier clase que se usen para la prevención o curación de enfermedades, corrección de defectos o para el diagnóstico");
                                });
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.7);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("DATOS SOBRE EL REGENTE FARMACÉUTICO DE LA EMPRESA").Bold();
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Nombre");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Registro de Idoneidad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.NumRegistro);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cédula de Identidad Personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Cedula);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Correo electrónico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Email);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Residencia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.PaisResidencia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Provincia);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Distrito);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Corregimiento);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosRegente.Ubicacion);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.InspAperCambUbicAgen.DatosRegente.TelefonoOfic, inspection.InspAperCambUbicAgen.DatosRegente.TelefonoMovil));

                                table.Footer(footer =>
                                {
                                    footer.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ley 66 de 10 de noviembre de 1947. Código Sanitario de la República de Panamá. (G.O. 10467 de 6 de diciembre de 1947). Artículo 200. Prohíbese ejercer conjuntamente las \r\nprofesiones de médico-cirujano y farmacéutico. A partir de la aprobación de este código, ningún médico que ejerza la profesión podrá ser dueño por sí mismo o por interpuesta persona, accionista o tener participación comercial cualquiera en establecimientos en que se fabriquen, preparen o vendan medicinas y artículos de cualquier clase que se usen para la prevención o curación de enfermedades, corrección de defectos o para el diagnóstico");
                                });
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CONDICIONES Y CARACTERÍSTICAS DEL ESTABLECIMIENTO").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El local está ubicado en área residencial? Está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.LocalAreaResidencial));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.LocalAreaResidencialDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se encontraba el Regente Farmacéutico en el Local?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.EstabaRegFarmEnLocal));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.EstabaRegFarmEnLocalDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El Regente Farmacéutico realiza otras funciones del dentro de la empresa?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.OtrasFuncionesRegFarm));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.OtrasFuncionesRegFarmDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe letrero visible que identifique la empresa?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.LetreroVisible));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.LetreroVisibleDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA ADMINSITRATIVA").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de área administrativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminDispone));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminDisponeDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminIdentificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminIdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dirección del área administrativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminDir));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminDirDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de servicios sanitarios y lavamanos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminDisponeServSanitario));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasAdministrativa.AreaAdminDisponeServSanitarioDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE RECEPCIÓN DE PRODUCTOS").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Separada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.Separada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.SeparadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ordenada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.Ordenada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.OrdenadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de estructuras en esta área (Tarimas, mesa de trabajo)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.DisponeEstructurasTarimas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.DisponeEstructurasDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está esta área protegida de las inclemencias del tiempo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.AreaProtegidaIncTiempo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.AreaProtegidaIncTiempoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe rampa para carga y descarga (cuando sea necesario) ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.RampaCargaDescarga));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreasRecProducto.RampaCargaDescargaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACENAMIENTO").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Claramente identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ordenada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.Ordenada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.OrdenadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Separada para la conservación y consumo de alimentos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SeparadaConservConsumoAlimentos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SeparadaConservConsumoAlimentosDesc);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tamaño aproximado del Depósito");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("De acuerdo al criterio técnico del Farmacéutico inspector, la capacidad del área es suficiente para almacenar productos, manejo adecuado de productos y circulación del personal (de ser negativa la respuesta, indicar motivo).");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.EspacioFisicoAdecuado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.EspacioFisicoAdecuadoDesc);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("SON ADECUADAS LAS CONDICIONES");
                                
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Piso");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondPiso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondPisoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Techo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondTecho));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondTechoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Paredes");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondParedes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondParedesDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Iluminación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.Iluminacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.IluminacionDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ventilación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondVentilacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondVentilacionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Suministro eléctrico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondSumElectricos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CondSumElectricosDesc);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("DISPONEN DE SUFICIENTE EQUIPO PARA EL CONTROL DE INCENDIOS");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Extintores Vigentes");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioAlarma));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioExtintoresDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Alarma");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioAlarmaDesc));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioExtintoresDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Detectores de humo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioDetectHumo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioDetectHumoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Otros");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioOtros));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.CtrIncendioOtrosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe señalización de rutas de evacuación en caso de siniestros");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SenalizacionRutaEva));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SenalizacionRutaEvaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe salida de emergencia identificada del local");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SalidaEmerIdenficada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SalidaEmerIdenficadaDesc);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("DISPONE DE ESTRUCTURAS DONDE ALMACENAN LOS PRODUCTOS");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Anaqueles");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreAnaqueles));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreAnaquelesDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Estantes");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreEstantes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreEstantesDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tablillas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreTablillas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreTablillasDesc);
                                
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tarimas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreTarimas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreTarimasDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Otros");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreOtros));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ProdSobreOtrosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Son adecuadas, suficientes e identificadas estas estructuras");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.EstructuraAdecuada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.EstructuraAdecuadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.MueblesADistancia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.MueblesADistanciaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con área de desperdicios");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.AreaDesperdicio));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.AreaDesperdicioDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El área de almacenamiento está libre de polvo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.AlmacenLibrePolvo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.AlmacenLibrePolvoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un sistema para monitorear la temperatura y humedad relativa de acuerdo con las especificaciones de almacenamiento del fabricante");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SistMonitorTemperatura));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SistMonitorTemperaturaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se mantiene monitoreo de la temperatura y humedad de esta área");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SistMonitorTempHumArea));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SistMonitorTempHumAreaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Temperatura");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.TemperaturaActual));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.TemperaturaActualDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Humedad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.HumedadActual));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.HumedadActualDesc);
                                
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se mantiene registro");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SistRegistroTemperatura));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SistRegistroTemperaturaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Es adecuada la temperatura de almacenamiento de los productos allí almacenados");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.TempAlmacenamientoAdecuada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.TempAlmacenamientoAdecuadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe letrero visible que identifique los rangos de temperatura y humedad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.LetreroVisibleIdentTempHum));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.LetreroVisibleIdentTempHumDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un sistema para el control de fauna nociva (cebadera y certificado de fumigación)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ControlFaunaNociva));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.ControlFaunaNocivaDescrip);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Señalizaciones o avisos de No comer, No beber, No fumar, No guardar plantas, comida y bebidas. Prohibido el ingreso de animales");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.NoComer));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.NoComerBeberFumarDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe flujo lógico de operaciones");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SenalFlujoLogicoOpe));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.SenalFlujoLogicoOpeDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA PARA PRODUCTOS RETIRADOS DEL MERCADO (VENCIDOS, DETERIORADOS.)").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Asegurada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosRetirados.Asegurada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosRetirados.AseguradaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosRetirados.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosRetirados.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosRetirados.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamiento.LimpiaDesc);


                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE CUARENTENA PARA PRODUCTOS").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Asegurada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.Asegurada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.AseguradaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las condiciones del área que pueden afectar los productos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.CondicionesArea));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.CondicionesAreaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProductosCuarentena.LimpiaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE DESPACHO DE PRODUCTOS").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Separada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.Separada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.SeparadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de estructuras en esta área (Tarimas, mesa de trabajo)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.DisponeEstructuras));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.DisponeEstructurasDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está esta área protegida de las inclemencias del tiempo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.ProtegidaIncTiempo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.ProtegidaIncTiempoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe rampa para carga y descarga (cuando sea necesario)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.RampaCargaDesc));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaDespachoProductos.RampaCargaDescargaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACENAMIENTO DE PRODUCTOS QUE REQUIEREN CADENA DE FRÍO").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se mantiene monitoreo de la temperatura y humedad de esta área");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.RegistroMonitoreoTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.RegistroMonitoreoTempDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Temperatura");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.Temperatura));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.TemperaturaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Humedad Relativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.HumedadRelativa));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.HumedadRelativaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuentan con el equipo necesario para la conservación de la temperatura de este tipo de productos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.EquipoConservacionTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.EquipoConservacionTempDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El área de almacenamiento con temperatura controlada posee sistema de alarma");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.SistemaAlarma));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoFrio.SistemaAlarmaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACENAMIENTO DE PRODUCTOS VOLATILES").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Separada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.Separada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.SeparadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ordenada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.Ordenada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.OrdenadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con kit de derrame");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.KitDerrame));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.KitDerrameDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con control de incendio");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.ControlIncendio));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.ControlIncendioDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con adecuada ventilación, que impida la concentración de olores");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.AdecuadaVentilacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoVolatil.AdecuadaVentilacionDesc);


                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACENAMIENTO DE PLAGUICIDAS DE USO DOMÉSTICO Y DE SALUD PÚBLICA").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Separada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.Separada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.SeparadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ordenada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.Ordenada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoPlaguicida.OrdenadaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACENAMIENTO DE MATERIA PRIMA PARA LA INDUSTRIA FARMACÉUTICA").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Separada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.Separada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.SeparadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ordenada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.Ordenada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoMateriaPrima.OrdenadaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE ALMACENAMIENTO DE PRODUCTOS SUJETOS A CONTROL (CUANDO APLIQUE)").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Asegurada (llave y/o candado)");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.Asegurada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.AseguradaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Independiente de otras áreas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.Independiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.IndependienteDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Iluminación y Ventilación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.Iluminacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.IluminacionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Posee un área identificada de vencidos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.IdentificadaVencidos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.IdentificadaVencidosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se mantiene monitoreo de la temperatura y humedad de esta área");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MonitorTemperaturaHumedad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MonitorTemperaturaHumedadDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Temperatura");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MonitorTemperatura));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MonitorTemperaturaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Humedad Relativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MonitorHumedad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MonitorHumedadDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se mantiene registro");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MantineRegistro));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.MantineRegistroDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Responsable del Área");
                                //table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.RespnsableArea));
                                table.Cell().Border(2).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.RespnsableArea);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Describa el lugar donde se almacenan y las medidas de seguridad");
                                //table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.LugarDesc));
                                table.Cell().Border(2).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaProdSujetosControl.LugarDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ÁREA DE DESPERDICIOS QUE SE GENERAN Y NO PUEDEN SER COLOCADOS EN EL ÁREA DE ALMACENAMIENTO").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Delimitada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.Delimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.DelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Limpia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Identificada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ordenada");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.Ordenada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaAlmacenamientoDesperdicio.OrdenadaDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.4);
                                    columns.RelativeColumn((float)0.1);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PROCEDIMIENTOS").Bold();
                                });

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL ESTABLECIMIENTO SE COMPROMETE A QUE LOS PROCEDIMIENTOS OPERATIVOS ESTANDARIZADOS (POE’S) Y DOCUMENTACIÓN RELACIONADA A ESTOS, ESTÉN COMPLETOS Y ACORDE CON EL DECRETO EJECUTIVO 115 DEL 16 DE AGOSTO DE 2022, Y SEGÚN LAS ACTIVIDADES A LAS QUE SE DEDICARÁ EL ESTABLECIMIENTO. DE IGUAL FORMA EL ESTABLECIMIENTO DEBERÁ TENER A DISPOSICIÓN DE LA AUTORIDAD REGULADORA LOS PROCEDIMIENTOS OPERATIVOS ESTANDARIZADOS (POE’S) Y DOCUMENTACIÓN RELACIONADA A ESTOS CUANDO ESTA LO SOLICITE");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.Procedimiento);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("TRANSPORTE").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El transporte cuenta con controles y registro de Temperatura y Humedad relativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ControlRegistroHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ControlRegistroHumTempDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El transporte mantiene los productos protegidos de la luz");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ProteccionLuzSolar));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ProteccionLuzSolarDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los productos que requieren cadena de frío se trasladan en vehículos o envases que permiten mantener la temperatura requerida");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ProdReqCadenaFrio));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ProdReqCadenaFrioDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("En los camiones se colocan los productos sobre tarimas");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.CamionesProdTarimas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.CamionesProdTarimasDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Presenta formato de verificación de mantenimiento y condiciones del vehículo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.FormatVerifMantenimiento));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.FormatVerifMantenimientoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("En caso de tercerización del transporte presenta contrato con la empresa que brindará el servicio");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.TranTercerizacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.TranTercerizacionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe transporte, según la normativa sanitaria vigente para el traslado de los productos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ExisteNormSanitariaVigente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaTransporte.ExisteNormSanitariaVigenteDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("VEHICULOS MOTORIZADOS").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITO");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El transporte cuenta con controles y registro de Temperatura y Humedad relativa");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.ControlRegistroTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.ControlRegistroTempDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El transporte mantiene los productos protegidos de la luz");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.ProteccionLuzSolar));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.ProteccionLuzSolarDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los productos que requieren cadena de frío se trasladan en vehículos o envases que permiten mantener la temperatura requerida");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.ReqCadenaFrio));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.ReqCadenaFrioDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los vehículos motorizados están identificados como transporte de medicamentos y otros productos para la salud humana");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehIdentificadoTransporteMed));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehIdentificadoTransporteMedDesc);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se acepta la identificación con el nombre de la empresa que cuente con licencia de operación ante la Dirección Nacional de Farmacia y Drogas");

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("El embalaje debe mantener la temperatura y humedad establecida por el fabricante, la cual debe ser monitoreada y registrada al momento de la preparación y entrega del pedido");

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Presenta formato de verificación de mantenimiento y condiciones del vehículo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehFormatVeriMantenimiento));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehFormatVeriMantenimientoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("En caso de tercerización del transporte presenta contrato con la empresa que brindará el servicio");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehTercerizacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehTercerizacionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe transporte, según la normativa sanitaria vigente para el traslado de los productos");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehTercerizacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosCondicionesLocal.AreaVehiculosMotorizado.VehNormSanitariaVigente);

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("El caso que el transporte sea realizado por terceros debe existir un contrato que detalle los deberes y responsabilidades del contratista y contratante. El distribuidor debe informar a los transportistas de las condiciones de transporte. El contratante debe verificar que el mismo cumpla con los requisitos establecidos en el presente reglamento");

                            });



                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperCambUbicAgen.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("SEGÚN CRITERIO TÉCNICO SE CONCLUYE QUE").Bold();
                                });

                                if (inspection.InspAperCambUbicAgen.DatosConclusiones.CumpleRequisitosMinOperacion)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL LOCAL CUMPLE ESTRUCTURALMENTE CON LOS REQUISITOS MÍNIMOS PARA OPERAR").Bold();
                                }
                                else
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL LOCAL NO CUMPLE ESTRUCTURALMENTE CON LOS REQUISITOS MÍNIMOS PARA OPERAR").Bold();
                                }

                                //Actividades y Productos
                                if (inspection.InspAperCambUbicAgen.DatosActProd != null)
                                {
                                    string strData = "";
                                    if (inspection.InspAperCambUbicAgen.DatosActProd.LActividades != null && inspection.InspAperCambUbicAgen.DatosActProd.LActividades.Count > 0)
                                    {
                                        table.Cell().PaddingTop(5).Border(1).BorderColor(Colors.Black).AlignLeft().Text("ACTIVIDADES").Bold();
                                        foreach (var data in inspection.InspAperCambUbicAgen.DatosActProd.LActividades)
                                        {
                                            strData += string.Format(" {0},", data.Nombre);
                                        }
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(strData);

                                    }
                                    if (inspection.InspAperCambUbicAgen.DatosActProd.LProductos != null && inspection.InspAperCambUbicAgen.DatosActProd.LProductos.Count > 0)
                                    {
                                        table.Cell().PaddingTop(5).Border(1).BorderColor(Colors.Black).AlignLeft().Text("PRODUCTOS").Bold();
                                        foreach (var data in inspection.InspAperCambUbicAgen.DatosActProd.LProductos)
                                        {
                                            strData += string.Format(" {0},", data.Nombre);
                                        }
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(strData);
                                    }
                                }
                            });
                            
                            column.Item().PaddingVertical(5).Text("OBSERVACIÓN:").Bold();
                            column.Item().Text("El Acta original se mantendrá en el expediente del establecimiento que permanece en la Dirección Nacional de Farmacia y Drogas y se hace entrega de una copia al firmante de esta acta, al finalizar la inspección").Bold();

                            column.Item().PaddingVertical(5).Text("COMO PARTE DE LOS REQUISITOS PARA LA EMISIÓN DE LA LICENCIA DE OPERACIÓN, LAS DESVIACIONES OBSERVADAS EN LA INSPECCIÓN, DEBERÁN SER SUBSANADAS EN UN TERMINO NO MAYOR A 20 DÍAS, DENTRO DE LOS CUALES DEBEN NOTIFICAR A LA DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS. PARA REALIZAR LA INSPECCIÓN DEFINITIVA").Bold();


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicAgen.DatosAtendidosPor?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicAgen.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitArea);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }                                

                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicAgen.DatosRegente?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicAgen.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text("");
    
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Cargo:{2}", inspection.InspAperCambUbicAgen.DatosAtendidosPor?.Nombre, inspection.InspAperCambUbicAgen.DatosAtendidosPor?.Cedula, inspection.InspAperCambUbicAgen.DatosAtendidosPor?.Cargo));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Cargo:{2} | Reg.:{3}", inspection.InspAperCambUbicAgen.DatosRegente.Nombre, inspection.InspAperCambUbicAgen.DatosRegente.Cedula, inspection.InspAperCambUbicAgen.DatosRegente.Cargo, inspection.InspAperCambUbicAgen.DatosRegente.NumRegistro));
                                
                                table.Cell().AlignLeft().Text("");
                            });
                            column.Item().PaddingVertical(5).Text(" ").Bold();
                            if (inspection.InspAperCambUbicAgen.DatosConclusiones.LParticipantes != null)
                            {
                                column.Item().Table(table => {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();

                                    foreach (var participant in inspection.InspAperCambUbicAgen.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));
                                        });
                                    }
                                });
                            }


                            column.Item().PaddingVertical(5).Text(string.Format("Hora de finalización de inspección: {0}", inspection.InspAperCambUbicAgen.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                            column.Item().PaddingVertical(5).Text("Fundamento Legal").Bold();
                            column.Item().Text("Ley 66 de 10 de noviembre de 1947 \r\nLey 1 de 10 de enero de 2001 \r\nLey 17 de 12 de septiembre de 2014 \r\nLey 24 de 29 de enero de 1963 \r\nDecreto Ejecutivo 115 de 16 de agosto de 2022 \r\nResolución No. 774 de 7 de octubre de 2019");

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf del Acta de Apertura o Cambio de Ubicacion de Agencia
        private async Task<Stream> GenerateInvestigaciones(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("ACTA DE INSPECCIÓN").Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Nombre del establecimiento:{0}", inspection.Establecimiento.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Ubicación:{0}", inspection.UbicacionEstablecimiento));
                            column.Item().AlignLeft().Text(string.Format("Num. de Lic.:{0}", inspection.LicenseNumber));
                            column.Item().AlignLeft().Text(string.Format("Aviso de Operación:{0}", inspection.AvisoOperacion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Siendo las {0} del {1} de {2} de {3}; actuando como colaboradores de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud, procedimos a realizar inspección al establecimiento antes descrito, para verificar {4}", 
                                inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.Day, Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.Year, inspection.InspInvestigacion.DetalleVerificacion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Al llegar al establecimiento fuimos atendidos por {0} con cargo de {1}, y documento de identidad personal N° {2}. A quien se le informó el motivo de la visita.",
    inspection.InspInvestigacion.DatosAtendidosPor.Nombre, inspection.InspInvestigacion.DatosAtendidosPor.Cargo, inspection.InspInvestigacion.DatosAtendidosPor.Cedula));

                            column.Item().PaddingVertical(5).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas, participaron:");
                            if (inspection.InspInvestigacion.DatosConclusiones.LParticipantes != null)
                            {
                                column.Item().Table(tbl =>
                                {
                                    tbl.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn((float)0.7);
                                        columns.RelativeColumn((float)0.3);
                                    });

                                    tbl.Header(header =>
                                    {
                                        header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignLeft().Text("Nombre").Bold();
                                        header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignLeft().Text("No. Idoneidad").Bold();
                                    });

                                    foreach (var participant in inspection.InspInvestigacion.DatosConclusiones.LParticipantes)
                                    {
                                        tbl.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(participant.NombreCompleto);
                                        tbl.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(participant.RegistroNumero);
                                    }
                                });                                
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("A continuación, se describen los detalles de la inspección:\r\n{0}", inspection.InspInvestigacion.DetalleInspeccion));
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Se adjunta acta de retención y retiro de productos: {0}", DataModel.Helper.Helper.GetDescription(inspection.InspInvestigacion.AdjuntaActaRetencion)));
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("No se puede movilizar los productos hasta culminar la investigación: {0}", DataModel.Helper.Helper.GetDescription(inspection.InspInvestigacion.MovilizarProductos)));

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspInvestigacion.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("se finaliza la inspección por".ToUpper()).Bold();
                                });
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspInvestigacion.DetalleVerificacion).Bold();

                                //table.Header(header =>
                                //{
                                //    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("SEGÚN CRITERIO TÉCNICO SE CONCLUYE QUE").Bold();
                                //});

                                //if (inspection.InspInvestigacion.DatosConclusiones.CumpleRequisitosMinOperacion)
                                //{
                                //    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL LOCAL CUMPLE ESTRUCTURALMENTE CON LOS REQUISITOS MÍNIMOS PARA OPERAR").Bold();
                                //}
                                //else
                                //{
                                //    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("EL LOCAL NO CUMPLE ESTRUCTURALMENTE CON LOS REQUISITOS MÍNIMOS PARA OPERAR").Bold();
                                //}
                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspInvestigacion.DatosAtendidosPor?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspInvestigacion.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text("");
                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspInvestigacion.DatosAtendidosPor?.Nombre, inspection.InspInvestigacion.DatosAtendidosPor?.Cedula));
                                table.Cell().AlignLeft().Text("");
                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspInvestigacion.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspInvestigacion.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspInvestigacion.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });

                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf del Acta de Apertura o Cambio de Ubicacion de Agencia
        private async Task<Stream> GenerateAperturaFabricantesMedicamentos(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("Evaluación Técnica por Apertura a Fabricante de Medicamentos".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.7);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("GENERALIDADES DE LA FARMACIA Y SOLICITANTE").Bold();
                                });

                                //Establecimiento
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("NOMBRE DEL ESTABLECIMIENTO");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Provincia");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Provincia?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Distrito");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Distrito?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Corregimiento");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.Establecimiento.Corregimiento?.Nombre ?? "");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ubicación");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.UbicacionEstablecimiento);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Teléfono / Celular");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0} / {1}", inspection.Establecimiento.Telefono1, inspection.Establecimiento.Telefono2));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Correo Electronico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(string.Format("{0}", inspection.Establecimiento.Email));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("REGENTE FARMACEUTICO");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosRegente.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cédula de Identidad Personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosRegente.Cedula);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Num. Registro");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosRegente.NumRegistro);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("REPRESENTANTE LEGAL");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosRepresentLegal.Nombre);
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cédula de Identidad Personal");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosRepresentLegal.Cedula);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("PRODUCTOS QUE FABRICA");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.TipoProductos);

                            });
                                                        
                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PERSONAL").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PUNTO POR EVALUAR");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Regente Farmacéutico");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosDocumentacion.RegenteFarmaceutico));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosDocumentacion.RegenteFarmaceuticoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Responsable de investigación y desarrollo");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosDocumentacion.RespInvDesarrollo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosDocumentacion.RespInvDesarrolloDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Responsable de producción");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosDocumentacion.RespProduccion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosDocumentacion.RespProduccionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Responsable de control de calidad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosDocumentacion.RespControlCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosDocumentacion.RespControlCalidadDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Responsable de garantía de la calidad");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosDocumentacion.RespGarantiaCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosDocumentacion.RespGarantiaCalidadDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("INSTALACIONES").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PUNTO POR EVALUAR");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Area Externa");

                                //Area Externa
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El establecimiento se encuentra identificado exteriormente, mediante letrero?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaExterna.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaExterna.IdentificadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está diseñado el edificio de tal manera que facilite la limpieza, mantenimiento y ejecución apropiada de las operaciones?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaExterna.DisenoFacilitaLimpMant));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaExterna.DisenoFacilitaLimpMantDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las vías de acceso interno a las instalaciones ¿están pavimentadas o construidas de manera tal que el polvo no sea fuente de contaminación en el interior de la planta?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaExterna.ViaAccesoInternoInst));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaExterna.ViaAccesoInternoInstDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existen fuentes de contaminación ambiental en el área circundante al edificio? En caso afirmativo, ¿se adoptan medidas de resguardo? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaExterna.FuentesContaminaAmbiental));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaExterna.FuentesContaminaAmbientalDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está diseñado y equipado el edificio de tal forma que ofrezca la máxima protección contra el ingreso de insectos y animales? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaExterna.ProteccionContraAnimales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaExterna.ProteccionContraAnimalesDesc);

                                ///////////////
                                ///////////////
                                ///
                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Area Internas");

                                //Area Internas
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está diseñado el edificio, de tal manera que permita el flujo de materiales, procesos y personal evitando la confusión, contaminación y errores? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.DisenoPermiteFlujoMat));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.DisenoPermiteFlujoMatDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están las áreas de acceso restringido debidamente delimitadas e identificadas? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.AreaRetringDelimitada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.AreaRetringDelimitadaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se utilizan como áreas de paso las áreas de producción, almacenamiento y control de calidad?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.AreaPasoComoAlmacen));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.AreaPasoComoAlmacenDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las condiciones de iluminación, temperatura, humedad y ventilación, para la producción y almacenamiento, están acordes con los requerimientos del producto? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.CondIlumTemHum));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.CondIlumTemHumDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, están diseñados y ubicados, de tal forma que faciliten la limpieza? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.TuberiaArtefactosFacilLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.TuberiaArtefactosFacilLimpiezaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone el edificio de extintores adecuados a las áreas y se encuentran estos ubicados en lugares estratégicos? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.DisponeExtintores));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.DisponeExtintoresDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Señalización de rutas de evacuación y salidas de emergencia? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaInterna.SenalRutaEvacuacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaInterna.SenalRutaEvacuacionDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(8).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("AREA DE ALMACENAMIENTO").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto por evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Materia Prima");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Material de Acondicionamiento");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Producto Terminado");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Producto a Granel");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Inflamables");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Rechazados");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Devoluciones");
                                });


                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están debidamente identificadas? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.Identificada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.Identificada));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los pisos, paredes, techos de los almacenes están construidos de tal forma que no afectan la calidad de los materiales y productos que se almacenan y permite la fácil limpieza?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.PisoParedesTechosCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.PisoParedesTechosCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.PisoParedesTechosCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.PisoParedesTechosCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.PisoParedesTechosCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.PisoParedesTechosCalidad));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.PisoParedesTechosCalidad));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.CapacidadSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.CapacidadSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.CapacidadSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.CapacidadSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.CapacidadSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.CapacidadSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.CapacidadSuficiente));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las instalaciones eléctricas están diseñadas y ubicadas de tal forma que facilitan la limpieza? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.InstElectFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.InstElectFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.InstElectFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.InstElectFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.InstElectFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.InstElectFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.InstElectFacilitaLimpieza));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Hay instrumentos para medir la temperatura y humedad y estas mediciones están dentro de los parámetros establecidos para los materiales y productos almacenados?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.InstrumentoMedHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.InstrumentoMedHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.InstrumentoMedHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.InstrumentoMedHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.InstrumentoMedHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.InstrumentoMedHumTemp));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.InstrumentoMedHumTemp));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Para las materias primas y productos que requieren condiciones especiales de enfriamiento, existe cámara fría?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.ExisteCamaraFria));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.ExisteCamaraFria));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.ExisteCamaraFria));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.ExisteCamaraFria));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.ExisteCamaraFria));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.ExisteCamaraFria));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.ExisteCamaraFria));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están protegidas de las condiciones ambientales las áreas de recepción y despacho? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.ProtegidaCondiAmbientales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.ProtegidaCondiAmbientales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.ProtegidaCondiAmbientales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.ProtegidaCondiAmbientales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.ProtegidaCondiAmbientales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.ProtegidaCondiAmbientales));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.ProtegidaCondiAmbientales));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área de despacho de producto terminado?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.ExisteAreaDespachoProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.ExisteAreaDespachoProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.ExisteAreaDespachoProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.ExisteAreaDespachoProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.ExisteAreaDespachoProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.ExisteAreaDespachoProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.ExisteAreaDespachoProd));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las áreas donde se almacenan materiales y productos sometidos a cuarentena están claramente definidas y marcadas, el acceso a las mismas está limitado sólo al personal autorizado? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AreaCuarentenaDefinida));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AreaCuarentenaDefinida));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AreaCuarentenaDefinida));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AreaCuarentenaDefinida));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AreaCuarentenaDefinida));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AreaCuarentenaDefinida));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AreaCuarentenaDefinida));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El muestreo de materia prima se efectúa en área separada o en el área de pesaje o dispensado? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.MuestreoMateriaPrima));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.MuestreoMateriaPrima));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.MuestreoMateriaPrima));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.MuestreoMateriaPrima));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.MuestreoMateriaPrima));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.MuestreoMateriaPrima));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.MuestreoMateriaPrima));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se utilizan materias primas psicotrópicas o estupefacientes? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.MateriaPrimaPsicotropica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.MateriaPrimaPsicotropica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.MateriaPrimaPsicotropica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.MateriaPrimaPsicotropica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.MateriaPrimaPsicotropica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.MateriaPrimaPsicotropica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.MateriaPrimaPsicotropica));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existen áreas separadas, bajo llave, de acceso restringido e identificadas para almacenar materias primas y productos psicotrópicos y estupefacientes?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AreaBajoLlaveStupefacientes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AreaBajoLlaveStupefacientes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AreaBajoLlaveStupefacientes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AreaBajoLlaveStupefacientes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AreaBajoLlaveStupefacientes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AreaBajoLlaveStupefacientes));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AreaBajoLlaveStupefacientes));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta el laboratorio con áreas de almacenamiento separadas para productos rechazados, retirados y devueltos? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AreaProdRechazados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AreaProdRechazados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AreaProdRechazados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AreaProdRechazados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AreaProdRechazados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AreaProdRechazados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AreaProdRechazados));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tienen estas áreas acceso restringido y bajo llave?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AreaProdRechazadosRestring));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AreaProdRechazadosRestring));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AreaProdRechazadosRestring));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AreaProdRechazadosRestring));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AreaProdRechazadosRestring));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AreaProdRechazadosRestring));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AreaProdRechazadosRestring));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área separada y de acceso restringido para almacenar material impreso (etiquetas, estuches, insertos y envases impresos)? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AlmacenMaterialImpreso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AlmacenMaterialImpreso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AlmacenMaterialImpreso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AlmacenMaterialImpreso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AlmacenMaterialImpreso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AlmacenMaterialImpreso));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AlmacenMaterialImpreso));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está identificada?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AlmacenMaterialImpresoIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AlmacenMaterialImpresoIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AlmacenMaterialImpresoIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AlmacenMaterialImpresoIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AlmacenMaterialImpresoIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AlmacenMaterialImpresoIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AlmacenMaterialImpresoIdentif));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área para almacenamiento de productos inflamables y explosivos alejada de las otras instalaciones, es ventilada y cuenta con medidas de seguridad contra incendios o explosiones según la legislación nacional?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMateriaPrima.AlmacenProdInflamables));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaMaterialAcondicionamiento.AlmacenProdInflamables));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoTerminado.AlmacenProdInflamables));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoAGranel.AlmacenProdInflamables));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoInflamable.AlmacenProdInflamables));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaProductoRechazados.AlmacenProdInflamables));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAlmacenamiento.AreaDevoluciones.AlmacenProdInflamables));

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de Dispensado de Materia Prima".ToUpper()).Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto por evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área separada e identificada, para llevar a cabo las operaciones de dispensación? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.Existe));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.Existe);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tiene paredes, pisos, techos lisos y curvas sanitarias? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.ParedesPisosTechos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.ParedesPisosTechosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con un sistema de inyección y extracción de aire que garanticen la no contaminación cruzada y seguridad del operario? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.SistInyExtAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.SistInyExtAireDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se mide la presión diferencial?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.MedPresionDif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.MedPresionDifDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.PrecausionesNecesarioas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.PrecausionesNecesarioasDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se cuenta con sistemas para la extracción localizada de polvos, cuando aplique?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.SistExtracPolvo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.SistExtracPolvoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área adyacente al área de dispensado, que se encuentre delimitada e identificada en donde se coloquen las materias primas que serán pesadas o medidas y las materias primas dispensadas que se utilizarán en la producción?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaDispensado.AreaAdyacente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaDispensado.AreaAdyacenteDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.4);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.3);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(5).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de Producción").Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto por evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Líquidos");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Semisólidos");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Sólidos");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuenta con esclusas?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.Exclusas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.Exclusas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.Exclusas));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.ExclusasDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El laboratorio cuenta con áreas de tamaño, diseño y servicios (aire comprimido, agua, luz, ventilación, etc.) para efectuar los procesos de producción que corresponden? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.DisenoTamanoProcesos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.DisenoTamanoProcesos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.DisenoTamanoProcesos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.DisenoTamanoProcesosDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están identificadas y separadas las áreas para la producción de sólidos, líquidos y semisólidos?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.IndentificadaSeparada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.IndentificadaSeparada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.IndentificadaSeparada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.IndentificadaSeparadaDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.ParedesPisosTechos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.ParedesPisosTechos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.ParedesPisosTechos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.ParedesPisosTechosDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TuberiasPtosVentFacilLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TuberiasPtosVentFacilLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TuberiasPtosVentFacilLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TuberiasPtosVentFacilLimpiezaDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están las tomas de gases y fluidos identificados y no son intercambiables?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TomasGasesIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TomasGasesIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TomasGasesIdentif));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TomasGasesIdentifDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Disponen de sistemas de inyección y extracción de aire?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.SistInyExtAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.SistInyExtAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.SistInyExtAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.SistInyExtAireDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuentan con equipo de control de aire, que permita el manejo de los diferenciales de presión de acuerdo a los requerimientos de cada área?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.EquipoControlAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.EquipoControlAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.EquipoControlAire));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.EquipoControlAireDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las condiciones de temperatura y humedad relativa se ajustan a los requerimientos de los productos que en ella se realizan?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.CondHumTempAjustaReq));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.CondHumTempAjustaReq));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.CondHumTempAjustaReq));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.CondHumTempAjustaReqDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.PrecNecMatFotosensible));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.PrecNecMatFotosensible));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.PrecNecMatFotosensible));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.PrecNecMatFotosensibleDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están identificadas y separadas las áreas para el empaque primario de sólidos, líquidos y semisólidos? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaEmpaqueIdentSeparada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaEmpaqueIdentSeparada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaEmpaqueIdentSeparada));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaEmpaqueIdentSeparadaDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están las tomas de gases y fluidos identificados?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TomasGasesFluidosIdent));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TomasGasesFluidosIdent));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TomasGasesFluidosIdent));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TomasGasesFluidosIdentDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Las instalaciones tienen curvas sanitarias y servicios para el trabajo que allí se ejecuta? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.CurvasSanitarias));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.CurvasSanitarias));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.CurvasSanitarias));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.CurvasSanitariasDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área exclusiva para el lavado de equipos móviles, recipientes y utensilios?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaLavadoEquipMoviles));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaLavadoEquipMoviles));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaLavadoEquipMoviles));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaLavadoEquipMovilesDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área separada, identificada, limpia y ordenada para colocar equipo limpio que no se esté utilizando?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaEquiposLimpios));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaEquiposLimpios));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaEquiposLimpios));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaEquiposLimpiosDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está el área de empaque secundario separada e identificada? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaEmpaqueSecundario));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaEmpaqueSecundario));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.AreaEmpaqueSecundario));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.AreaEmpaqueSecundarioDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("El área tiene el tamaño de acuerdo con su capacidad y línea de producción, con el fin de evitar confusiones?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TamanoAdecuado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TamanoAdecuado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.TamanoAdecuado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.TamanoAdecuadoDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tienen paredes, pisos y techos lisos de tal forma que permitan la fácil limpieza y sanitización?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.FacilLimpiezaSanitizacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.FacilLimpiezaSanitizacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.FacilLimpiezaSanitizacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.FacilLimpiezaSanitizacionDesc));

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Qué sistema utilizan para el tratamiento de agua?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.SisTrataminetoAgua));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.SisTrataminetoAgua));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoSemiSolido.SisTrataminetoAgua));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaProduccion.TipoLiquido.SisTrataminetoAguaDesc));

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Áreas Auxiliares".ToUpper()).Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto por evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Están los servicios sanitarios accesibles a las áreas de trabajo y no se comunican directamente con las áreas de producción? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.ServSanitarioAccesible));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.ServSanitarioAccesibleDesc);
                                
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los vestidores están comunicados directamente con las áreas de producción?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.VestidoresComunicaProd));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.VestidoresComunicaProdDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los vestidores y servicios sanitarios están Identificados correctamente");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.VestidoresIdentificados));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.VestidoresIdentificadosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("La cantidad de servicios sanitarios para hombres y mujeres está de acuerdo con el número de trabajadores? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.CantidadServicioSanitarios));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.CantidadServicioSanitariosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuentan con lavamanos y duchas provistas de agua?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.LavadosDuchasProvistasAgua));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.LavadosDuchasProvistasAguaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de espejos, toallas de papel o secador eléctrico de manos, jaboneras con jabón líquido desinfectante y papel higiénico?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.DisponeEspejos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.DisponeEspejosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Casilleros, zapateras y las bancas necesarias (no de madera)?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.CasillerosZapaterosNecesario));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.CasillerosZapaterosNecesarioDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área, manteniendo rótulos que indiquen esta disposición?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.ProhibeConsumirAlimentos));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.ProhibeConsumirAlimentosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Se prohíbe fumar en estas áreas (rótulo)?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.ProhibeFumar));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.ProhibeFumarDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuentan con un comedor separado de las demás áreas productivas e identificada, en buenas condiciones de orden y limpieza?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.ComedorSeparado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.ComedorSeparadoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Cuentan con un área de lavandería separada y exclusiva para el lavado y secado de los uniformes utilizados por el personal? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.AreaLavanderia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.AreaLavanderiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área destinada para investigación y desarrollo de sus productos?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaAuxiliares.AreaInvestigaciones));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaAuxiliares.AreaInvestigacionesDesc);


                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Control de Calidad".ToUpper()).Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto por evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existe un área destinada para el laboratorio de control de calidad que se encuentra identificada y separada del área de producción?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.Existe));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.ExisteDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tiene paredes lisas que faciliten su limpieza?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.Limpia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.LimpiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tiene una campana de extracción para los vapores nocivos?");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.CampanaExtraccion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.CampanaExtraccionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Tiene suficiente iluminación y ventilación? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.IluminacionVentilacion));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.IluminacionVentilacionDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de suficiente espacio para evitar confusiones y contaminación cruzada? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EspacioSuficiente));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EspacioSuficienteDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de area de microbiología? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaMicrobiologia));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaMicrobiologiaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de area de fisicoquímicas? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaFisicoQuimica));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaFisicoQuimicaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de area de instrumental? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaInstrumental));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaInstrumentalDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Dispone de area de lavado de cristalería y utensilios? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaLavadoUtensilios));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.AreaLavadoUtensiliosDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existen equipos de seguridad como duchas? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegDucha));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegDuchaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existen equipos de seguridad como lava ojos ? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegLavaOjo));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegLavaOjoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existen equipos de seguridad como extintores? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegExtintores));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegExtintoresDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Existen equipos de seguridad como elementos de protección? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegElemProtec));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosAreaLabCtrCalidad.EquipoSegElemProtecDesc);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.4);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Equipos".ToUpper()).Bold();
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto por evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ");
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIÓN");
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Está el equipo utilizado en la producción diseñado y construido de acuerdo a la operación que en él se realice? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosEquipos.DisenoConstAcordeOpera));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosEquipos.DisenoConstAcordeOperaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("La ubicación del equipo facilita su limpieza, así como la del área en la que se encuentra? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosEquipos.UbicacionFacilitaLimpieza));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosEquipos.UbicacionFacilitaLimpiezaDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Si el equipo es muy pesado, está diseñado para que se pueda ejecutar su limpieza, sanitización o esterilización en el área de producción? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosEquipos.EquipoPesado));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosEquipos.EquipoPesadoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Son las superficies de los equipos que tienen contacto directo con las materias primas, productos en proceso, de acero inoxidable de acuerdo a su uso u otro material que no sea reactivo, aditivo y adsorbente? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosEquipos.SuperficieContactDirecto));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosEquipos.SuperficieContactDirectoDesc);

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("Los soportes de los equipos que lo requieran son de acero inoxidable u otro material que no contamine? ");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(inspection.InspAperFabricante.DatosEquipos.SoporteAceroInox));
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosEquipos.SoporteAceroInoxDesc);

                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Procedimientos Operativos Estándares:")).Bold();
                            column.Item().AlignLeft().Text(string.Format("El establecimiento se compromete a que los procedimientos operativos estandarizados (POE’S) y documentación relacionada a estos, estén completos y acorde con la Normativa vigente y según las actividades a las que se dedicará el establecimiento.  De igual forma el establecimiento deberá tener a disposición de la Autoridad Reguladora los procedimientos operativos estandarizados (POE’S) y documentación relacionada a estos cuando esta lo solicite y al momento de Auditoría de Buenas prácticas de Fabricación."));

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("CRITERIO TÉCNICO")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Una vez evaluado el cumplimiento de los requerimientos previstos en el GUÍA DE VERIFICACIÓN DEL REGLAMENTO TECNICO CENTROAMERICANO RTCA 11.03.42:07 REGLAMENTO TÉCNICO SOBRE BUENAS PRÁCTICAS DE MANUFACTURA PARA LA INDUSTRIA FARMACÉUTICA. PRODUCTOS FARMACÉUTICOS Y MEDICAMENTOS DE USO HUMANO, por el cual se reglamentan las Buenas Prácticas de Manufactura de Productos Farmacéuticos.  Inspectores Farmacéuticos de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud de Panamá concluyen que el establecimiento denominado {0}, ubicado en {1}, {2} con los requisitos mínimos para operar como Laboratorio farmacéutico dedicado a {3}. \r\nDado en la ciudad de Panamá a los {4} días del mes de {5} de {6}.", inspection.Establecimiento.Nombre, inspection.UbicacionEstablecimiento,(inspection.InspAperFabricante.DatosConclusiones.CumpleRequisitosMinOperacion? "SÍ CUMPLE": "NO CUMPLE"), inspection.InspAperFabricante.TipoProductos, inspection.InspAperFabricante.DatosConclusiones.FechaFinalizacion?.Day, Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.InspAperFabricante.DatosConclusiones.FechaFinalizacion?.ToString("MM")??"01")), inspection.InspAperFabricante.DatosConclusiones.FechaFinalizacion?.Year.ToString()??""));

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Inconformidades o desviaciones detectadas".ToUpper()).Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperFabricante.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspAperFabricante.DatosRegente?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperFabricante.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspAperFabricante.DatosRepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperFabricante.DatosRepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspAperFabricante.DatosRegente?.Nombre, inspection.InspAperFabricante.DatosRegente?.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspAperFabricante.DatosRepresentLegal?.Nombre, inspection.InspAperFabricante.DatosRepresentLegal?.Cedula));

                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspAperFabricante.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspAperFabricante.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspAperFabricante.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf de BPM Guia Fabricante de Cosmeticos y Desinfectantes
        private async Task<Stream> GenerateGuiaFabricantesCosmeticosDesinfectantes(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("Guía de Laboratorio Fabricante de Fabricantes Cosmeticos Desinfectantes y Plaguicidas".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("I. PARTICIPANTES EN LA INSPECCIÓN:".ToUpper())).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Autoridad Sanitaria:"));
                            foreach (var participant in inspection.InspGuiBPMFabCosmeticoMed.DatosConclusiones.LParticipantes)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", participant.NombreCompleto));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Por la Empresa:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Representante Legal: {0}", inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("C.I.P : {0}", inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal.Cedula));
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });
                            column.Item().AlignLeft().Text(string.Format("Regente farmacéutico /Director Técnico y número de Registro:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Lic: {0}", inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Registro : {0}", inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico.NumRegistro));
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Otros funcionarios de la empresa:"));
                            foreach (var persona in inspection.InspGuiBPMFabCosmeticoMed.OtrosFuncionarios.LPersona)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", persona.Nombre));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("II. GENERALIDADES:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre de la empresa: {0}", inspection.InspGuiBPMFabCosmeticoMed.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Dirección: {0}", inspection.InspGuiBPMFabCosmeticoMed.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Ciudad: {0}", inspection.InspGuiBPMFabCosmeticoMed.GeneralesEmpresa.Ciudad));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiBPMFabCosmeticoMed.GeneralesEmpresa.Telefono));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiBPMFabCosmeticoMed.GeneralesEmpresa.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("RESPONSABLE DE PRODUCCIÓN:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspGuiBPMFabCosmeticoMed.RespProduccion.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspGuiBPMFabCosmeticoMed.RespProduccion.Profesion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("RESPONSABLE DE CONTROL DE CALIDAD:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspGuiBPMFabCosmeticoMed.RespControlCalidad.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspGuiBPMFabCosmeticoMed.RespControlCalidad.Profesion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("REQUISITOS LEGALES:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.6); 
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.1".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("De la autorización de funcionamiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                });

                                var i = 0;
                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.RequisitosLegales.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(i>0?"":"6.1.1");
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    i++;
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Observaciones:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(inspection.InspGuiBPMFabCosmeticoMed.Observaciones);

                            column.Item().AlignLeft().Text(string.Format("¿Está el establecimiento sometido a un proceso periódico de vigilancia y control sanitario por la autoridad competente?"));
                            column.Item().AlignLeft().Text(string.Format(DataModel.Helper.Helper.GetDescription(inspection.InspGuiBPMFabCosmeticoMed.ProcesoVigilanciaSanit)));

                            column.Item().AlignLeft().Text(string.Format("Fecha de la última visita: {0}", inspection.InspGuiBPMFabCosmeticoMed.FechaUltimaVista?.ToString("dd/MM/yyyy")??""));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("CLASIFICACIÓN DE LA ACTIVIDAD COMERCIAL:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.9);
                                    columns.RelativeColumn((float)0.1);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Adquisición de Materias primas y materiales".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.ClasifActComerciales.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                }
                            });
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("CLASIFICACIÓN DEL ESTABLECIMIENTO:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Objetivos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.8);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Adquisición de Materias primas y materiales".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento2.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                }
                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Capítulo I - ADMINISTRACIÓN E INFORMACIÓN GENERAL".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("A- Generalidades - Estructura Organizativa".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                
                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.GenEstructuraOrganizativa.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    });

                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CAPITULO II - ALMACENES".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("A - Condiciones Externas de los Almacenes".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.CondExtAlmacenas.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    });
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("B - Condiciones Internas de los Almacenes".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.CondIntAlmacenas.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("C - Área de Recepción de Materia Prima ".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaRecepMateriaPrima.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CH - Almacén de Materia Prima".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AlmacenMateriaPrima.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("D - Área de almacenamiento de Materiales de Acondicionamiento, Empaque y Envase".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AlmacenMatAcondicionamineto.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("E - Recepción de Producto Terminado (De producción al almacén)".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.RecepProductoTerminado.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("E.1 - Almacén de Producto Terminado".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AlmacenProductoTerminado.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("F - Área de productos Devueltos y/o Rechazados".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.ProductoDevueltoRechazado.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("G - Distribución de Productos Terminados".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.DistProductoTerminado.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("H - Manejo de quejas y reclamos de productos comercializados".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.ManejoQuejaReclamos.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("I - Retiro de Productos del Mercado".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.RetiroProcMercado.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Capitulo III - SISTEMAS CRITICOS DE APOYO".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });
                                                                
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("3.1 Sistemas e Instalaciones de Agua".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.SistemaInstAgua.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("3.1.1 OSMOSIS INVERSA".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.OsmosisInversa.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("3.1.2 SISTEMA DE DEIONIZACION".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.SistemaDeIonizacion.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("3.2 Calibraciones y Verificaciones de equipo".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.CalibraVerifEquipo.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("3.3 Validaciones".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.Validaciones.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("3.4 Mantenimiento de áreas y equipos".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.MantAreaEquipos.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Capitulo IV - ÁREAS DE PRODUCCIÓN".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });
                                                                
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.1.A Condiciones Externas".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaProdCondExternas.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.1.B Condiciones Internas".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaProdCondInternas.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.2 Organización y Documentación".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaOrganizaDocumentacion.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.3 Área de Dispensación de Ordenes de Fabricación".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaDispensionOrdFab.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.4.1 Fabricación de Productos Desinfectantes".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.FabProdDesinfectante.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.5.1 Fabricación de Plaguicidas ".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.FabPlaguicida.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("4.6.1 Fabricación de Cosméticos".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.FabCosmeticos.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }


                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Capítulo V - Acondicionamiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("5.1 Área de Envasado".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaEnvasado.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("5.2. Área de Etiquetado y Empaque".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AreaEtiquetadoEmpaque.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }


                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Capítulo VI- Control de Calidad".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.1 Laboratorio de Control de Calidad".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.LabControlCalidad.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.2 Análisis por Contrato".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.AnalisisContrato.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }


                            });

                            column.Item().PaddingVertical(5).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)40);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)10);
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)30);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Capítulo VII- Inspecciones y Auditoría".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());

                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto. Max".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Pto Obt.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                });

                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                table.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text(" ".ToUpper());
                                table.Cell().ColumnSpan(4).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());

                                foreach (var dat in inspection.InspGuiBPMFabCosmeticoMed.InspeccionAudito.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosMax);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.PuntosObtenido);
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    }); 
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Articulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }


                            });




                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspGuiBPMFabCosmeticoMed.DatosConclusiones.ObservacionesFinales);

                            });


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                
                                table.Cell().AlignLeft().Text("");
                                
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico?.Nombre, inspection.InspGuiBPMFabCosmeticoMed.RegenteFarmaceutico?.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal?.Nombre, inspection.InspGuiBPMFabCosmeticoMed.RepresentLegal?.Cedula));
                                
                                table.Cell().AlignLeft().Text("");
                                
                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspGuiBPMFabCosmeticoMed.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspGuiBPMFabCosmeticoMed.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspGuiBPMFabCosmeticoMed.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //Apertura – Cosméticos Artesanales
        private async Task<Stream> GenerateAperturaCosmeticosArtesanales(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("Evaluación Técnica por Apertura para la Elaboración de Cosméticos Artesanales".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Datos Generales:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre de la empresa: {0}", inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Provincia: {0}", inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Provincia));
                            column.Item().AlignLeft().Text(string.Format("Corregimiento: {0}", inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Corregimiento));
                            column.Item().AlignLeft().Text(string.Format("Ubicación: {0}", inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Telefono));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Propietario Artesano:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspAperturaCosmetArtesanal.Propietario.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspAperturaCosmetArtesanal.Propietario.Cedula));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Documentación:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto para evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cumplimiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspAperturaCosmetArtesanal.Documentacion.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Locales:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto para evaluar".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cumplimiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspAperturaCosmetArtesanal.Locales.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Áreas de Almacenamiento:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Punto para evaluar".ToUpper());
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cumplimiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).AlignCenter().Text("Área para evaluar");
                                table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");


                                foreach (var dat in inspection.InspAperturaCosmetArtesanal.Locales.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                }
                            });

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("CRITERIO TÉCNICO")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Una vez evaluado el cumplimiento de los requerimientos previstos en el Decreto Ejecutivo N° 875 del 18 de noviembre de 2021, que reglamenta la elaboración de productos cosméticos arsenales en la República de Panamá.  Inspectores Farmacéuticos de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud de Panamá concluyen que el establecimiento denominado {0}, ubicado en {1} {2} con los requisitos mínimos para la elaboración de productos cosméticos arsenales.",inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Nombre, inspection.InspAperturaCosmetArtesanal.GeneralesEmpresa.Direccion, (inspection.InspAperturaCosmetArtesanal.DatosConclusiones.CumpleRequisitosMinOperacion ? "SÍ CUMPLE" : "NO CUMPLE")));
                            //0- Nombere, 1- Ubicacion, 2-Cumple 

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Dado en la ciudad de Panamá a los Dado en la ciudad de Panamá a los {0} días del mes de {1} de {2}.", inspection.InspAperturaCosmetArtesanal.DatosConclusiones.FechaFinalizacion?.Day, Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.InspAperturaCosmetArtesanal.DatosConclusiones.FechaFinalizacion?.ToString("MM") ?? "01")), inspection.InspAperturaCosmetArtesanal.DatosConclusiones.FechaFinalizacion?.Year.ToString() ?? ""));

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperturaCosmetArtesanal.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Inconformidades o desviaciones detectadas".ToUpper()).Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspAperturaCosmetArtesanal.DatosConclusiones.Inconformidades);

                            });


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignMiddle().AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspAperturaCosmetArtesanal.Propietario?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperturaCosmetArtesanal.Propietario.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                                table.Cell().AlignMiddle().AlignLeft().Text("");
                                table.Cell().AlignMiddle().AlignLeft().Text("");
                                
                                table.Cell().AlignLeft().AlignMiddle().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspAperturaCosmetArtesanal.Propietario?.Nombre, inspection.InspAperturaCosmetArtesanal.Propietario?.Cedula));
                                
                                table.Cell().AlignMiddle().AlignLeft().Text("");
                                table.Cell().AlignMiddle().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspAperturaCosmetArtesanal.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspAperturaCosmetArtesanal.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignMiddle().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignMiddle().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspAperturaCosmetArtesanal.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //Guia BPM Fabricante Productos Naturales Medicinales
        private async Task<Stream> GenerateGuiaFabricantesProdNaturalesMedicinales(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("GUÍA DE VERIFICACIÓN DEL REGLAMENTO TÉCNICO CENTROAMERICANO (RTCA) 11.03.69:13 PRODUCTOS FARMACÉUTICOS. PRODUCTOS NATURALES MEDICINALES PARA USO HUMANO. BUENAS PRÁCTICAS DE MANUFACTURA".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("CRITERIOS DE EVALUACIÓN:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Los diferentes ítems a evaluar de la Guía de Verificación de Buenas Prácticas de Manufactura (BPM) de Productos Naturales Medicinales para uso Humano, se clasificarán como críticos, calificables e informativos."));
                            
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("CRÍTICO:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Es aquel que, en atención a las BPM, afecta en forma grave e inadmisible la calidad y /o seguridad de los productos y la seguridad de los trabajadores, en su interacción con los productos y procesos."));
                            
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("CALIFICABLE:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Aquellos ítems que no son considerados como críticos, pero deben ser evaluados y valorados para el cumplimiento del presente reglamento"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("INFORMATIVO:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Suministra información de la organización y aspectos relacionados con las BPM, pero no afecta la calidad ni la seguridad de los productos o de los trabajadores en su interacción con los productos y procesos. No se contabiliza para el puntaje total."));
                            
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Los criterios CRÍTICOS y CALIFICABLES se calificarán como cumple (100%), no cumple (0%) o no aplica, según corresponda"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("CRITERIOS PARA LA EMISIÓN DEL CERTIFICADO DE BUENAS PRÁCTICAS DE MANUFACTURA".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Para la emisión del certificado de Buenas Prácticas de Manufactura (BPM) el laboratorio debe obtener un porcentaje de cumplimiento del 95% al 100% para los criterios calificados como críticos y un mínimo del 80 % de los ítems clasificados como calificables en la guía de verificación. Para alcanzar el 100% de cumplimiento para todas las no conformidades críticas y calificables, el laboratorio debe presentar un plan de mejora cuyos plazos de cumplimiento serán aprobados por la autoridad reguladora, según el riesgo sanitario y verificado en inspecciones posteriores. De no cumplir los plazos establecidos en el plan de mejora, se cancelará el certificado de BPM."));

                            column.Item().AlignLeft().Text(string.Format("El plan de mejora se deberá presentar en el plazo que defina la autoridad reguladora, posterior a la entrega del Informe de no conformidades detectadas durante la evaluación técnica"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("NOTAS:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("1) Para el caso de Guatemala y Panamá, el plazo será de 30 días calendario. El incumplimiento a esta disposición será objeto de la sanción correspondiente."));
                            column.Item().AlignLeft().Text(string.Format("2) Para el caso de Honduras, deberán presentar el plan de mejora en los plazos establecidos, pero este no estará sujeto a la aprobación por parte de la autoridad reguladora."));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("VIGENCIA DEL CERTIFICADO DE BUENAS PRÁCTICAS DE MANUFACTURA (BPM)".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("El certificado de BPM tendrá una vigencia de 2 años, esto no exime que la autoridad reguladora desarrolle auditorías durante el período de vigencia."));



                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("DATOS GENERALES:".ToUpper())).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Autoridad Sanitaria:"));
                            foreach (var participant in inspection.InspGuiBPMFabNatMedicina.DatosConclusiones.LParticipantes)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", participant.NombreCompleto));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Por la Empresa:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Representante Legal: {0}", inspection.InspGuiBPMFabNatMedicina.RepresentLegal.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("C.I.P : {0}", inspection.InspGuiBPMFabNatMedicina.RepresentLegal.Cedula));
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabNatMedicina.RepresentLegal.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabNatMedicina.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });
                            column.Item().AlignLeft().Text(string.Format("Regente farmacéutico /Director Técnico y número de Registro:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Lic: {0}", inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Registro : {0}", inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico.NumRegistro));
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Otros funcionarios de la empresa:"));
                            foreach (var persona in inspection.InspGuiBPMFabNatMedicina.OtrosFuncionarios.LPersona)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", persona.Nombre));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("DATOS DEL ESTABLECIMIENTO:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre de la empresa: {0}", inspection.InspGuiBPMFabNatMedicina.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Dirección: {0}", inspection.InspGuiBPMFabNatMedicina.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Ciudad: {0}", inspection.InspGuiBPMFabNatMedicina.GeneralesEmpresa.Ciudad));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiBPMFabNatMedicina.GeneralesEmpresa.Telefono));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiBPMFabNatMedicina.GeneralesEmpresa.Email));
                            column.Item().AlignLeft().Text(string.Format("Razon Social: {0}", inspection.InspGuiBPMFabNatMedicina.GeneralesEmpresa.RazonSocial));
                            column.Item().AlignLeft().Text(string.Format("Motivo de la Inspección: {0}", inspection.InspGuiBPMFabNatMedicina.MotivoInspeccion));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Datos Recolectados:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("5. AUTORIZACIÓN DE FUNCIONAMIENTO ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AuthFuncionamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.1 Organización".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Organizacion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.2 Personal".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Personal.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.3 Responsabilidades del personal ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ResponPersonal.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.4 De la capacitación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Capacitacion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.5 Higiene y salud del personal".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.HigieneSalud.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.1 Ubicación, diseño y características de la construcción".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.2 Almacenes".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Almacenes.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.3 Áreas de recepción, limpieza, segregación y acondicionamiento de materia prima natural".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaRecepLimpieza.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.4 Área de secado, molienda y extracción".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaSecadoMolienda.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.5 Área de dispensado de materias primas".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.6 Áreas de producción".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaProduccion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.7 Área de envasado / empaque".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.8 Áreas auxiliares".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaAuxiliares.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("7.9 Área de control de calidad".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AreaControlCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("8.1 Generalidades".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades8.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("8.2 Calibración ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Calibracion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("8.4 Sistema de agua ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.SistemaAgua.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("8.5 Sistema de aire".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.SistemaAire.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.1 Generalidades".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades9.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.2 Del dispensado de materia prima".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.DispensadoMatPrima.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.3 Materiales de acondicionamiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.MatAcondicionamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.4 Productos a granel".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ProdAGranel.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.5 Productos terminados ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ProdTerminados.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.6 Materiales y productos rechazados ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ProdRechazados.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("9.7 Productos devueltos ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ProdDevueltos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("10.1 Generalidades".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades10.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("10.2 De los documentos exigidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.DocumentosExigido.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("10.3 Procedimientos y registros".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ProcedimientoReg.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("11. Producción y control de procesos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.ProdControlProceso.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("12.1 De las generalidades".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades12.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("12.2 Garantía de calidad".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.GarantiaCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("13.1 Generalidades".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades13.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("13.2 Muestreo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Muestreo.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("13.3 Metodología analítica ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.MetodologiaAnalitica.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("13.4 Materiales de referencia".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.MaterialesReferencia.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("13.5 De la estabilidad ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Estabilidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("14.1 Generalidades ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades14.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("14.2 Retiros ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Retiros.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("15.1 Generalidades".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Generalidades15.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("15.2 Del contratante ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Contratante.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("15.3 Del contratista ".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.Contratista.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Artículo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("16. Auto-inspección y auditorías de calidad".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evalución".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiBPMFabNatMedicina.AuditoriaCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });


                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspGuiBPMFabNatMedicina.DatosConclusiones.ObservacionesFinales);

                            });


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspGuiBPMFabNatMedicina.RepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiBPMFabNatMedicina.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }

                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico?.Nombre, inspection.InspGuiBPMFabNatMedicina.RegenteFarmaceutico?.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiBPMFabNatMedicina.RepresentLegal?.Nombre, inspection.InspGuiBPMFabNatMedicina.RepresentLegal?.Cedula));

                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspGuiBPMFabNatMedicina.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspGuiBPMFabNatMedicina.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspGuiBPMFabNatMedicina.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //RUTINA VIGILANCIA AGENCIA
        private async Task<Stream> GenerateRutinaVigilanciaAgencia(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("INSPECCIÓN DE RUTINA O VIGILANCIA A AGENCIAS DISTRIBUIDORAS".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("DATOS GENERALES:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre del Establecimiento: {0}", inspection.InspRutinaVigAgencia.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Nº de Licencia de operación: {0}, Fecha de vencimiento: {1}", inspection.InspRutinaVigAgencia.GeneralesEmpresa.NumLicOperacion, inspection.InspRutinaVigAgencia.GeneralesEmpresa.FechaVencLicOperacion?.ToString("dd/MM/yyyy")??""));
                            column.Item().AlignLeft().Text(string.Format("Provincia: {0}, Distrito: {1}, Corregimiento: {2}", inspection.InspRutinaVigAgencia.GeneralesEmpresa.Provincia, inspection.InspRutinaVigAgencia.GeneralesEmpresa.Distrito, inspection.InspRutinaVigAgencia.GeneralesEmpresa.Corregimiento));
                            column.Item().AlignLeft().Text(string.Format("Ubicación: {0}", inspection.InspRutinaVigAgencia.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Horario de Operación: {0}", inspection.InspRutinaVigAgencia.GeneralesEmpresa.HorarioOperacion));
                            column.Item().AlignLeft().Text(string.Format("Teléfono(s): {0}, Correo electrónico: {1}", inspection.InspRutinaVigAgencia.GeneralesEmpresa.Telefono, inspection.InspRutinaVigAgencia.GeneralesEmpresa.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Datos del Regente:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre del Regente: {0}", inspection.InspRutinaVigAgencia.DatosRegente.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Nº de Registro: {0}", inspection.InspRutinaVigAgencia.DatosRegente.NumRegistro));
                            column.Item().AlignLeft().Text(string.Format("Horario de Regencia: {0}", inspection.InspRutinaVigAgencia.DatosRegente.HorarioRegencia));
                            column.Item().AlignLeft().Text(string.Format("Otras Funciones del Regente Dentro de la Empresa: {0}", inspection.InspRutinaVigAgencia.DatosRegente.OtrasFunciones));
                            column.Item().AlignLeft().Text(string.Format("Se Encontraba el Regente Farmacéutico en el Local: {0}", DataModel.Helper.Helper.GetDescription(inspection.InspRutinaVigAgencia.DatosRegente.PresenteEnLocal) ));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Propietario o Representante Legal:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspRutinaVigAgencia.DatosRepresentLegal.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Número de Cédula: {0}", inspection.InspRutinaVigAgencia.DatosRepresentLegal.Cedula));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspRutinaVigAgencia.DatosRepresentLegal.Profesion));
                            column.Item().AlignLeft().Text(string.Format("Dirección del área administrativa: {0}", inspection.InspRutinaVigAgencia.DatosRepresentLegal.Ubicacion));

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("GENERALIDADES DEL ESTABLECIMIENTO".ToUpper())).Bold();
                            
                            //column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Área:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaRecepProductos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de Recepción de productos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaRecepProductos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de Almacenamiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaAlmacenamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área para productos Devueltos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaProdDevueltos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de despacho de productos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaDespachoProductos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de almacenamiento de productos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaAlmacenamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Área de almacén de desperdicios".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaDesperdicio.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("SUSTANCIAS CONTROLADAS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.AreaSustanciasControladas.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("PROCEDIMIENTOS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.Procedimientos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("TRANSPORTE".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.Transporte.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("ACTIVIDAD DE DISTRIBUCIóN".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.ActividadDistribucion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("REPORTE DE INVENTARIO DE MEDICAMENTOS DE USO CONTROLADO".ToUpper())).Bold();

                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)3);
                                    columns.RelativeColumn((float)2);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)2);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Nombre del Producto".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Laboratorio Fabricante".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Nº Lote".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Vencimiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Existencia Física".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Registro en Libro o sistema".ToUpper());
                                });
                                foreach (var dat in inspection.InspRutinaVigAgencia.InventarioMedicamento.LProductos)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Nombre);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Fabricante);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Lote);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.FechaVencimiento?.ToString("dd/MM/yyyy")??"");
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Existencia);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(DataModel.Helper.Helper.GetDescription(dat.RegistroSistema));
                                }
                            });


                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspRutinaVigAgencia.DatosConclusiones.ObservacionesFinales);

                            });

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("CRITERIO TÉCNICO")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Según criterio técnico se concluye que, el local {0} con los requisitos mínimos para operar:", (inspection.InspRutinaVigAgencia.DatosConclusiones.CumpleRequisitosMinOperacion ? "SÍ CUMPLE" : "NO CUMPLE")));
                            column.Item().AlignLeft().Text(string.Format("Se re-programará otra inspección para verificar observaciones: {0}", (inspection.InspRutinaVigAgencia.DatosConclusiones.ReprogramaInspeccion?"Si":"No" )));


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspRutinaVigAgencia.DatosRegente?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspRutinaVigAgencia.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspRutinaVigAgencia.DatosRepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspRutinaVigAgencia.DatosRepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }

                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspRutinaVigAgencia.DatosRegente.Nombre, inspection.InspRutinaVigAgencia.DatosRegente.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspRutinaVigAgencia.DatosRepresentLegal.Nombre, inspection.InspRutinaVigAgencia.DatosRepresentLegal.Cedula ));

                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspRutinaVigAgencia.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspRutinaVigAgencia.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspRutinaVigAgencia.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //CIERRE DE OPERACIONES
        private async Task<Stream> GenerateCierreOperaciones(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("ACTA DE CIERRE DE OPERACIONES DE ESTABLECIMIENTOS FARMACEUTICOS".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("DATOS GENERALES:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre del Establecimiento: {0}", inspection.InspCierreOperacion.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Nº de Licencia de Operación: {0}, Fecha de vencimiento: {1}", inspection.InspCierreOperacion.GeneralesEmpresa.NumLicOperacion, inspection.InspCierreOperacion.GeneralesEmpresa.FechaVencLicOperacion?.ToString("dd/MM/yyyy") ?? ""));
                            column.Item().AlignLeft().Text(string.Format("Provincia: {0}, Distrito: {1}, Corregimiento: {2}", inspection.InspCierreOperacion.GeneralesEmpresa.Provincia, inspection.InspCierreOperacion.GeneralesEmpresa.Distrito, inspection.InspCierreOperacion.GeneralesEmpresa.Corregimiento));
                            column.Item().AlignLeft().Text(string.Format("Ubicación: {0}", inspection.InspCierreOperacion.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Teléfono(s): {0}, Correo electrónico: {1}", inspection.InspCierreOperacion.GeneralesEmpresa.Telefono, inspection.InspCierreOperacion.GeneralesEmpresa.Email));

                            //column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Datos del Responsable del Establecimiento:".ToUpper())).Bold();
                            //column.Item().AlignLeft().Text(string.Format("Nombre del Responsable: {0}", inspection.InspCierreOperacion.DatosResponsable.Nombre));
                            //column.Item().AlignLeft().Text(string.Format("Nº de Cédula: {0}", inspection.InspCierreOperacion.DatosResponsable.Cedula));
                            //column.Item().AlignLeft().Text(string.Format("Cargo: {0}", inspection.InspCierreOperacion.DatosResponsable.Cargo));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Siendo las {0} del {1} de {2} de {3}, y actuando como colaboradores de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud, los suscritos:",
                                inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.Day, Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.Year));

                            if (inspection.InspCierreOperacion.DatosConclusiones.LParticipantes != null)
                            {
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    foreach (var participant in inspection.InspCierreOperacion.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(6);
                                                columns.RelativeColumn(4);
                                            });

                                            tbl.Cell().AlignLeft().Text(string.Format("Lic. {0}", participant.NombreCompleto));
                                            tbl.Cell().AlignLeft().Text(string.Format("Idoneidad profesional N°. {0}", participant.RegistroNumero));

                                        });
                                    }
                                });
                            }
                            column.Item().AlignLeft().Text(string.Format("Procedimos a efectuar inspección al establecimiento antes señalado, para constatar “in situ” el CIERRE DE OPERACIONES, para dar respuesta a solicitud de {0}", inspection.InspCierreOperacion.SolicitudCierre));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Observaciones sobre la ubicación:  {0}", inspection.InspCierreOperacion.ObservacionUbicacion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Observaciones sobre el destino de los productos farmacéuticos (incluir los sujetos a control especial y el libro de registro):  {0}", inspection.InspCierreOperacion.DestinoProductos));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Por lo cual, concluyen las operaciones del establecimiento que fueron autorizadas a través de licencia de operación N° {0}, y se procederá a cerrar el expediente  que reposa en la Dirección Nacional de Farmacia y Drogas.", inspection.InspCierreOperacion.GeneralesEmpresa.NumLicOperacion));

                            column.Item().PaddingVertical(5).Text(string.Format("Los abajo firmantes damos fe de lo antes descrito"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspCierreOperacion.DatosResponsable?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspCierreOperacion.DatosResponsable.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text("");
                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspCierreOperacion.DatosResponsable.Nombre, inspection.InspCierreOperacion.DatosResponsable.Cedula));

                                table.Cell().AlignLeft().Text("");
                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspCierreOperacion.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspCierreOperacion.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspCierreOperacion.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //DISPOSICION FINAL DEL PRODUCTO
        private async Task<Stream> GenerateDisposicionFinalProd(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("DISPOSICIÓN FINAL DE DESECHOS FARMACÉUTICOS".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Siendo las {0} del {1} de {2} de {3}, los suscritos:",
                                inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.Day, Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.Year));
                            if (inspection.InspDisposicionFinal.DatosConclusiones.LParticipantes != null)
                            {
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                        columns.RelativeColumn(1);
                                    });

                                    foreach (var participant in inspection.InspDisposicionFinal.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().AlignLeft().Text(string.Format("Lic. {0}", participant.NombreCompleto));
                                        table.Cell().AlignLeft().Text(string.Format("Idoneidad profesional N°. {0}", participant.RegistroNumero));
                                        table.Cell().AlignLeft().Text(" ");
                                        table.Cell().AlignLeft().Text(" ");

                                    }
                                });
                            }
                            
                            column.Item().AlignLeft().Text(string.Format("Actuando como colaboradores de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud, nos apersonamos al establecimiento denominado: {0}, ubicado en: {1}. \r\nCon la finalidad de realizar:", inspection.InspDisposicionFinal.GeneralesEmpresa.Nombre, inspection.InspDisposicionFinal.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Tipo de Inspección: {0}", DataModel.Helper.Helper.GetDescription(inspection.InspDisposicionFinal.TipoInspeccion)));
                            column.Item().AlignLeft().Text(string.Format("Tipo de Producto: {0}", DataModel.Helper.Helper.GetDescription(inspection.InspDisposicionFinal.TipoProduct)));
                            column.Item().AlignLeft().Text(string.Format("Tipo de Verificación: {0}", DataModel.Helper.Helper.GetDescription(inspection.InspDisposicionFinal.TipoVerificacion)));
                            column.Item().AlignLeft().Text(string.Format("Disposición final solicitado por: {0}", inspection.InspDisposicionFinal.SolicitudCierre));
                            column.Item().AlignLeft().Text(string.Format("N° de nota de SDGSA: {0}", inspection.InspDisposicionFinal.NumNotaSDGSA));

                            column.Item().PaddingVertical(5).AlignCenter().Text(" ").Bold();

                            column.Item().AlignLeft().Text(string.Format("La solicitud corresponde al expediente con recibo de pago N°: {0}", inspection.InspDisposicionFinal.NumReciboPago));
                            column.Item().AlignLeft().Text(string.Format("El peso de los productos a destruir es: {0} (Kg)", inspection.InspDisposicionFinal.PesoDestruir));
                            column.Item().AlignLeft().Text(string.Format("Adjunto lista de productos: {0}", inspection.InspDisposicionFinal.Adjunta?"Si":"No"));
                            column.Item().AlignLeft().Text(string.Format("Total: {0} cajas/tarimas/bultos", inspection.InspDisposicionFinal.Total));

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("Lista de Productos".ToUpper())).Bold();

                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cantidad".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Nombre del producto".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Presentación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Motivos".ToUpper());
                                });
                                foreach (var dat in inspection.InspDisposicionFinal.InventarioMedicamento.LProductos)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Cantidad);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Nombre);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Presentacion);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Motivos);
                                }
                            });

                            column.Item().PaddingVertical(5).AlignCenter().Text(string.Format("Conclusiones".ToUpper())).Bold();

                            column.Item().AlignLeft().Text(string.Format("Luego de realizar {0} de los desechos farmacéuticos, se encontró que la existencia física {1} coincide con el registro en la lista que adjuntó el establecimiento a la solicitud.", DataModel.Helper.Helper.GetDescription(inspection.InspDisposicionFinal.TipoInspeccion), inspection.InspDisposicionFinal.Coincide?"Si":"No"));

                            column.Item().PaddingVertical(5).AlignLeft().Text("La Dirección Nacional de Farmacia y Drogas y sus colaboradores quedan relevados de cualquier compromiso y responsabilidad que pudiera derivarse de la destrucción de estos desechos farmacéuticos o del manejo inadecuado de los mismos");

                            column.Item().PaddingVertical(5).Text(string.Format("Los abajo firmantes damos fe de lo antes descrito"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspDisposicionFinal.DatosResponsable?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspDisposicionFinal.DatosResponsable.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text("");
                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspDisposicionFinal.DatosResponsable.Nombre, inspection.InspDisposicionFinal.DatosResponsable.Cedula));

                                table.Cell().AlignLeft().Text("");
                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspDisposicionFinal.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspDisposicionFinal.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspDisposicionFinal.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf de BPM Guia Fabricante de Cosmeticos y Desinfectantes
        private async Task<Stream> GenerateGuiaFabricantesMedicamentos(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("GUÍA DE VERIFICACIÓN DEL REGLAMENTO TECNICO CENTROAMERICANO RTCA 11.03.42:07 REGLAMENTO TÉCNICO SOBRE BUENAS PRÁCTICAS DE MANUFACTURA PARA LA INDUSTRIA FARMACÉUTICA. PRODUCTOS FARMACÉUTICOS Y MEDICAMENTOS DE USO HUMANO.".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("I. INTRODUCCIÓN".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("El RTCA 11.03.42:07 Reglamento Técnico sobre Buenas Prácticas de Manufactura para la Industria Farmacéutica. Productos Farmacéuticos y Medicamentos de Uso Humano, establece que la verificación de su cumplimiento le corresponde a la Autoridad Reguladora de cada Estado Parte, lo que implica la revisión de todos los elementos relacionados con las BPM implementados en la industria, destinados a garantizar la producción de lotes uniformes de productos farmacéuticos con el fin de asegurar la calidad, seguridad y eficacia de los mismos."));
                            column.Item().AlignLeft().Text(string.Format("El presente documento consiste en el instrumento oficial para verificar el cumplimiento de las BPM en la industria farmacéutica, por parte de la Autoridad Reguladora de cada Estado Parte, con el cual se pretende homologar y armonizar los criterios de inspección y establecer una lista de puntos a verificar de todas las operaciones y procesos de la industria. Puede sertambién de utilidad para los laboratorios fabricantes en lo que respecta a la autoinspección."));
                            column.Item().AlignLeft().Text(string.Format("Cada ítem tiene asignada una calificación con la finalidad de que las inspecciones a realizar, respondan a criterios uniformes de evaluación, dichos criterios se definen en el glosario del presente documento"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("II. OBJETIVO".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Establecer los criterios de evaluación a seguir por parte de la Autoridad Reguladora, para verificar el cumplimiento del RTCA 11.03.42:07Reglamento Técnico sobre Buenas Prácticas de Manufactura para la Industria Farmacéutica. Productos Farmacéuticos y Medicamentos de Uso Humano. "));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("III. ALCANCE".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Esta guía es de aplicación a todos los laboratorios farmacéuticos establecidos en el territorio de los Estados Parte."));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("IV. DOCUMENTOS A CONSULTAR".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("El RTCA 11.03.42:07 Reglamento Técnico sobre Buenas Prácticas de Manufactura para la Industria Farmacéutica. Productos Farmacéuticos y Medicamentos de Uso Humano"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("V. RESPONSABLE".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Autoridad Reguladora de cada Estado Parte."));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("VI. GLOSARIO".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("CRITERIO CRÍTICO: aquel que en atención a las recomendaciones de las Buenas Prácticas de Manufactura, afecta en forma grave e inadmisible la calidad, seguridad de los productos y la seguridad de los trabajadores, en su interacción con los productos y procesos."));
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("CRITERIO MAYOR: aquel que en atención a las recomendaciones de las Buenas Prácticas de Manufactura, puede afectar en forma grave la calidad, seguridad de los productos y seguridad de los trabajadores, en su interacción con los productos y procesos."));
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("CRITERIO MENOR: aquel que en atención a las recomendaciones de las Buenas Prácticas de Manufactura, puede afectar en forma leve la calidad, seguridad de los productos y seguridad de los trabajadores, en su interacción con los productos y procesos."));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("I. PARTICIPANTES EN LA INSPECCIÓN:".ToUpper())).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Autoridad Sanitaria:"));
                            foreach (var participant in inspection.InspGuiaBPMFabricanteMed.DatosConclusiones.LParticipantes)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", participant.NombreCompleto));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Por la Empresa:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Representante Legal: {0}", inspection.InspGuiaBPMFabricanteMed.RepresentLegal.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("C.I.P : {0}", inspection.InspGuiaBPMFabricanteMed.RepresentLegal.Cedula));
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMFabricanteMed.RepresentLegal.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMFabricanteMed.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });
                            column.Item().AlignLeft().Text(string.Format("Regente farmacéutico /Director Técnico y número de Registro:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Lic: {0}", inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Registro : {0}", inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico.NumRegistro));
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Otros funcionarios de la empresa:"));
                            foreach (var persona in inspection.InspGuiaBPMFabricanteMed.OtrosFuncionarios.LPersona)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", persona.Nombre));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("II. GENERALIDADES:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre de la empresa: {0}", inspection.InspGuiaBPMFabricanteMed.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Dirección: {0}", inspection.InspGuiaBPMFabricanteMed.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Ciudad: {0}", inspection.InspGuiaBPMFabricanteMed.GeneralesEmpresa.Ciudad));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiaBPMFabricanteMed.GeneralesEmpresa.Telefono));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiaBPMFabricanteMed.GeneralesEmpresa.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("RESPONSABLE DE PRODUCCIÓN:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspGuiaBPMFabricanteMed.RespProduccion.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspGuiaBPMFabricanteMed.RespProduccion.Profesion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("RESPONSABLE DE CONTROL DE CALIDAD:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspGuiaBPMFabricanteMed.RespControlCalidad.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspGuiaBPMFabricanteMed.RespControlCalidad.Profesion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("REQUISITOS LEGALES:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.6);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.1".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("De la autorización de funcionamiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                });

                                var i = 0;
                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.RequisitosLegales.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(i > 0 ? "" : "6.1.1");
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    });
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    i++;
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Observaciones:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(inspection.InspGuiaBPMFabricanteMed.Observaciones);

                            column.Item().AlignLeft().Text(string.Format("¿Está el establecimiento sometido a un proceso periódico de vigilancia y control sanitario por la autoridad competente?"));
                            column.Item().AlignLeft().Text(string.Format(DataModel.Helper.Helper.GetDescription(inspection.InspGuiaBPMFabricanteMed.ProcesoVigilanciaSanit)));

                            column.Item().AlignLeft().Text(string.Format("Fecha de la última visita: {0}", inspection.InspGuiaBPMFabricanteMed.FechaUltimaVista?.ToString("dd/MM/yyyy") ?? ""));

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("CLASIFICACIÓN DE LA ACTIVIDAD COMERCIAL:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Objetivos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.ClasifActComerciales.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Clasificación del Establecimiento".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Objetivos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.ClasifEstablecimiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Organización y Personal".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.OrganizacionPersonal.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Edificios e Instalaciones".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.EdifInstalaciones.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Almacenes".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Materia Prima".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Material Acondic.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Producto A Granel".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Producto Terminado".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Inflamables".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Rechazados".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Devoluciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.Almacenes.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion4));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion5));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion6));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion7));

                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Area de Dispensado de Materia Prima".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.AreaDispMatPrima.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Area de Producción".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Líquidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Semisólidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Sólidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.AreaDispMatPrima.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Area de Acondicionamiento para Empaque Secundario".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.AreaAcondicionamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Equipos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Líquidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Semisólidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Sólidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.EquiposGeneralidades.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.Equipos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Materiales y Productos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.MatProducts.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Documentación".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.Documentacion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Producción".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Líquidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Semisólidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Sólidos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.Produccion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Garantía de Calidad".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.GarantiaCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Control de Calidad".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.ControlCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Producción y Análisis por Contrato".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.ProdAnalisisContrato.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Validación".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.ValGenerales.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Quejas y Reclamos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.QuejasGenerales.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Autoinspección y Auditoría de Calidad".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.AutoInspecAuditCal.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Fabricación de Productos Farmacéuticos Estériles".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Esterilización Terminal".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Filtración Esterilizante".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Llenado Aséptico".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_Gen.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Esterilización Terminal".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Filtración Esterilizante".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Llenado Aséptico".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A2.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A3.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Fabricación de Productos Farmacéuticos Lactímicos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.Lactamicos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Fabricación de Productos con Hormonas y Productos Citostáticos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMFabricanteMed.ProdCitostatico.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspGuiaBPMFabricanteMed.DatosConclusiones.ObservacionesFinales);

                            });


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMFabricanteMed.RepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMFabricanteMed.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico?.Nombre, inspection.InspGuiaBPMFabricanteMed.RegenteFarmaceutico?.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiaBPMFabricanteMed.RepresentLegal?.Nombre, inspection.InspGuiaBPMFabricanteMed.RepresentLegal?.Cedula));

                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspGuiaBPMFabricanteMed.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspGuiaBPMFabricanteMed.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspGuiaBPMFabricanteMed.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf de BPM Guia Laboratorios Acondicionadores
        private async Task<Stream> GenerateGuiaLabAcondicionadores(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("GUÍA de Laboratorio Acondicionador.".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("I. PARTICIPANTES EN LA INSPECCIÓN:".ToUpper())).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Autoridad Sanitaria:"));
                            foreach (var participant in inspection.InspGuiaBPMLabAcondicionador.DatosConclusiones.LParticipantes)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", participant.NombreCompleto));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Por la Empresa:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Representante Legal: {0}", inspection.InspGuiaBPMLabAcondicionador.RepresentLegal.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("C.I.P : {0}", inspection.InspGuiaBPMLabAcondicionador.RepresentLegal.Cedula));
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMLabAcondicionador.RepresentLegal.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMLabAcondicionador.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });
                            column.Item().AlignLeft().Text(string.Format("Regente farmacéutico /Director Técnico y número de Registro:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Lic: {0}", inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico.Nombre));
                                table.Cell().AlignMiddle().AlignLeft().Text(string.Format("Registro : {0}", inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico.NumRegistro));
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico.Firma))
                                {
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignMiddle().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().AlignMiddle().AlignLeft().Text("");
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Otros funcionarios de la empresa:"));
                            foreach (var persona in inspection.InspGuiaBPMLabAcondicionador.OtrosFuncionarios.LPersona)
                            {
                                column.Item().AlignLeft().Text(string.Format("Lic. {0}", persona.Nombre));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("II. GENERALIDADES:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre de la empresa: {0}", inspection.InspGuiaBPMLabAcondicionador.GeneralesEmpresa.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Dirección: {0}", inspection.InspGuiaBPMLabAcondicionador.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Ciudad: {0}", inspection.InspGuiaBPMLabAcondicionador.GeneralesEmpresa.Ciudad));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiaBPMLabAcondicionador.GeneralesEmpresa.Telefono));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiaBPMLabAcondicionador.GeneralesEmpresa.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("RESPONSABLE DE PRODUCCIÓN:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspGuiaBPMLabAcondicionador.RespProduccion.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspGuiaBPMLabAcondicionador.RespProduccion.Profesion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("RESPONSABLE DE CONTROL DE CALIDAD:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre: {0}", inspection.InspGuiaBPMLabAcondicionador.RespControlCalidad.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Profesión: {0}", inspection.InspGuiaBPMLabAcondicionador.RespControlCalidad.Profesion));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("REQUISITOS LEGALES:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.6);
                                    columns.RelativeColumn((float)0.1);
                                    columns.RelativeColumn((float)0.1);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("6.1".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("De la autorización de funcionamiento".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("".ToUpper());
                                });

                                var i = 0;
                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.RequisitosLegales.LContenido)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(i > 0 ? "" : "6.1.1");
                                    //table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Titulo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).Table(tbl =>
                                    {
                                        tbl.ColumnsDefinition(columns =>
                                        {
                                            columns.RelativeColumn(7);
                                            columns.RelativeColumn(3);
                                        });

                                        tbl.Cell().ColumnSpan(2).AlignLeft().Text(dat.Titulo);
                                        foreach (var subdt in dat.LSubContenido)
                                        {
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}:", subdt.Titulo));
                                            tbl.Cell().AlignLeft().Text(DataModel.Helper.Helper.GetDescription(subdt.Seleccion));
                                        }
                                    });
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                    i++;
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Observaciones:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(inspection.InspGuiaBPMLabAcondicionador.Observaciones);

                            column.Item().AlignLeft().Text(string.Format("¿Está el establecimiento sometido a un proceso periódico de vigilancia y control sanitario por la autoridad competente?"));
                            column.Item().AlignLeft().Text(string.Format(DataModel.Helper.Helper.GetDescription(inspection.InspGuiaBPMLabAcondicionador.ProcesoVigilanciaSanit)));

                            column.Item().AlignLeft().Text(string.Format("Fecha de la última visita: {0}", inspection.InspGuiaBPMLabAcondicionador.FechaUltimaVista?.ToString("dd/MM/yyyy") ?? ""));

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("CLASIFICACIÓN DE LA ACTIVIDAD COMERCIAL:".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Objetivos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.ClasifActComerciales.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Clasificación del Establecimiento".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.2);
                                    columns.RelativeColumn((float)0.3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Objetivos".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Organización y Personal".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Edificios e Instalaciones".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.EdifInstalaciones.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Almacenes".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Materia Prima".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Material Acondic.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Producto A Granel".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Producto Terminado".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Inflamables".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Rechazados".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Devoluciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.Almacenes.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion2));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion3));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion4));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion5));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion6));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion7));

                                    }
                                }
                            });

                            
                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Area de Acondicionamiento".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.AreaAcondicionamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Equipos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.EquiposGeneralidades.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Materiales y Productos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.MatProducts.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Documentación".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.Documentacion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Acondicionamiento".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.Acondicionamiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Garantía de Calidad".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.GarantiaCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Control de Calidad".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.ControlCalidad.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Producción y Análisis por Contrato".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.ProdAnalisisContrato.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Validación".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.ValGenerales.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Quejas y Reclamos".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.QuejasReclamos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("Autoinspección y Auditoría de Calidad".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)1);
                                    columns.RelativeColumn((float)3);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Título".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Criterio".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPMLabAcondicionador.AutoInspecAuditCal.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });


                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspGuiaBPMLabAcondicionador.DatosConclusiones.ObservacionesFinales);

                            });


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPMLabAcondicionador.RepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPMLabAcondicionador.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }

                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico?.Nombre, inspection.InspGuiaBPMLabAcondicionador.RegenteFarmaceutico?.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiaBPMLabAcondicionador.RepresentLegal?.Nombre, inspection.InspGuiaBPMLabAcondicionador.RepresentLegal?.Cedula));

                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspGuiaBPMLabAcondicionador.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspGuiaBPMLabAcondicionador.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspGuiaBPMLabAcondicionador.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }
        //generamos el pdf de BPM Guia BPA
        private async Task<Stream> GenerateGuiaBPM_BPA(AUD_InspeccionTB inspection)
        {
            try
            {
                //var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignLeft().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            table.Cell().ColumnSpan(3).AlignCenter().Text("Guía para las Buenas Prácticas de Almacenamiento, Distribución y Transporte de Medicamentos y Otros Productos para la Salud Humana".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(8).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Hora de Inicio: {0}", inspection.FechaInicio.ToString("hh:mm tt")));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", inspection.FechaInicio.ToString("dd/MM/yyyy")));

                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN: {0}", DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO: {0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("I. INTRODUCCIÓN".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Con el propósito de establecer un documento oficial utilizado como apoyo en la realización de las inspecciones por parte de la Autoridad Reguladora y en el proceso de autoinspección en cada establecimiento farmacéutico que se dedica al Almacenamiento, Distribución y Transporte de Medicamentos y otros Productos para la Salud Humana, la Dirección Nacional de Farmacia y Drogas presenta el documento denominado Guía de Buenas Prácticas de Almacenamiento, Distribución y Transporte de Medicamentos y Otros Productos para la Salud Humana."));
                            column.Item().AlignLeft().Text(string.Format("Los ítems contemplados en la presente Guía se sustentan en la Ley No. 1 de 10 de enero de 2001 sobre Medicamentos y Otros Productos para la Salud Humana, en el Título III de la Comercialización, Capítulo I, artículo 67 y su Reglamentación contempladas en el Decreto Ejecutivo N° 115 de 16 de agosto de 2022 que reglamenta la Ley N° 1 sobre Medicamentos y Otros Productos para la Salud Humana."));
                            column.Item().AlignLeft().Text(string.Format("La Autoridad de Salud, realizará inspecciones para la evaluación de las Buenas Prácticas de Almacenamiento, Distribución y Transporte de Medicamentos y otros Productos para la Salud Humana, y al final levanta un acta de lo actuado.  Según los resultados se procederá a emitir la certificación correspondiente o en su defecto podrá amonestar, sancionar, retener o decomisar mediante resolución motivada lo que corresponda.  Por tanto, todo establecimiento farmacéutico que se dedica al Almacenamiento, Distribución y Transporte de Medicamentos y otros productos competencia de la Dirección Nacional de Farmacia y Drogas queda sujeto a inspecciones periódicas por parte de la Autoridad Reguladora."));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("II. CLASIFICACIÓN DE LOS CRITERIOS DE EVALUACIÓN".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("CRITERIO CRÍTICO: aquel que en atención a la normativa vigente sobre las Buenas Prácticas de Almacenamiento y Distribución (BPA y BPD) establecidas en la República de Panamá, su no cumplimiento afecta en forma grave e inadmisible la calidad, seguridad de los productos."));
                            column.Item().AlignLeft().Text(string.Format("CRITERIO MAYOR: aquel que en atención a la normativa vigente sobre las Buenas Prácticas de Almacenamiento y Distribución (BPA y BPD) establecidas en la República de Panamá, su no cumplimiento puede afectar en forma grave la calidad, seguridad de los productos."));
                            column.Item().AlignLeft().Text(string.Format("CRITERIO MENOR: aquel que en atención a la normativa vigente sobre las Buenas Prácticas de Almacenamiento y Distribución (BPA y BPD) establecidas en la República de Panamá, su no cumplimiento puede afectar en forma leve la calidad de los productos o puede ser sólo un tema de forma."));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("III. CRITERIO DE APROBACIÓN".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Para aprobar el cumplimiento de las Buenas Prácticas de Almacenamiento y distribución establecidas en el Decreto Ejecutivo Nº 115 del 16 de agosto de 2022, la Agencia Distribuidora debe cumplir con los porcentajes mínimos establecidos en la normativa vigente"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("IV. SOLICITUD PARA OBTENCIÓN DEL CERTIFICADO DE BUENAS PRÁCTICAS DE ALMACENAMIENTO Y DISTRIBUCIÓN".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("el interesado debe realizar la solicitud con el formulario destinado para tal fin"));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("V. DATOS GENERALES DEL ESTABLECIMIENTO".ToUpper())).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Establecimiento Farmacéutico:")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Nombre de la empresa: {0}, {1}, {2}, {3}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Provincia, inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Distrito, inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Corregimiento, inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Direccion));
                            column.Item().AlignLeft().Text(string.Format("Provincia: {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Provincia));
                            column.Item().AlignLeft().Text(string.Format("Distrito: {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Distrito));
                            column.Item().AlignLeft().Text(string.Format("Corregimiento: {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Corregimiento));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Telefono));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.Email));
                            column.Item().AlignLeft().Text(string.Format("Licencia de Operación Nº:  {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.NumLicOperacion));
                            column.Item().AlignLeft().Text(string.Format("Fecha de Expiración:  {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.FechaVencLicOperacion?.ToString("dd/MM/yyyy")));
                            column.Item().AlignLeft().Text(string.Format("Licencia Especial de Sustancias Controladas Nº:  {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.NumLicEspecial));
                            column.Item().AlignLeft().Text(string.Format("Fecha de Expiración:  {0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.FechaVencLicEspecial?.ToString("dd/MM/yyyy")));
                            
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Actividad Comercial aprobada (Ley 1 Art. 172):")).Bold();
                            column.Item().AlignLeft().Text(string.Format("{0}", inspection.InspGuiaBPM_Bpa.GeneralesEmpresa.ActComercialAprobada));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Regente Farmacéutico")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Lic: {0}", inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico.Nombre));
                            column.Item().AlignLeft().Text(string.Format("N° Idoneidad: {0}", inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico.NumRegistro));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico.TelefonoMovil));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Representante Legal")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Lic: {0}", inspection.InspGuiaBPM_Bpa.RepresentLegal.Nombre));
                            column.Item().AlignLeft().Text(string.Format("Cédula: {0}", inspection.InspGuiaBPM_Bpa.RepresentLegal.Cedula));
                            column.Item().AlignLeft().Text(string.Format("Teléfono: {0}", inspection.InspGuiaBPM_Bpa.RepresentLegal.TelefonoMovil));
                            column.Item().AlignLeft().Text(string.Format("Correo electrónico: {0}", inspection.InspGuiaBPM_Bpa.RepresentLegal.Email));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Fecha de la última Inspección por BPAD Oficial realizada: {0}", inspection.InspGuiaBPM_Bpa.FechaUltimaInspeccion?.ToString("dd/MM/yyyy") ?? ""));

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("DATOS GENERALES DE LA INSPECCIÓN".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Propósito de la Inspección de Buenas Prácticas de Almacenamiento y Distribución")).Bold();
                            foreach (var propos in inspection.InspGuiaBPM_Bpa.PropositoInsp.LPropositos)
                            {
                                column.Item().AlignLeft().Text(string.Format("{0}", propos.Nombre));
                            }

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Participantes de la inspección:".ToUpper())).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Dirección Nacional de Farmacia y Drogas:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)2.5);
                                    columns.RelativeColumn((float)2.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Nombre".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cargo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Area Evakuada".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.NombreCompleto);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Cargo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.AreaEvaluada);
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Establecimiento:"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)5);
                                    columns.RelativeColumn((float)2.5);
                                    columns.RelativeColumn((float)2.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Nombre".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cargo".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Area Evakuada".ToUpper());
                                });
                                foreach (var dat in inspection.InspGuiaBPM_Bpa.OtrosFuncionarios.LPersona)
                                {
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Nombre);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Cargo);
                                    table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.AreaEvaluada);
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format("Horarios verificados durante la inspección:")).Bold();
                            column.Item().AlignLeft().Text(string.Format("Establecimiento Farmacéutico: {0}", inspection.InspGuiaBPM_Bpa.HorarioEstFarmaceutico));
                            column.Item().PaddingVertical(5).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Regencia Farmacéutica: {0}", inspection.InspGuiaBPM_Bpa.HorarioRegFarmaceutica));


                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("1. DISPOSICIONES GENERALES DEL ESTABLECIMIENTO FARMACÉUTICO".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("No.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITOS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CRITERIO".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evidencias / Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPM_Bpa.DispGenerlestablecimiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Numero);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("2. AREAS DEL ESTABLECIMIENTO".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("No.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITOS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CRITERIO".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evidencias / Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPM_Bpa.AreasEstablecimiento.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Numero);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("3. DISTRIBUCIÓN".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("No.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITOS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CRITERIO".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evidencias / Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPM_Bpa.Distribucion.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(""); 
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Numero);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("4. TRANSPORTE PARA LOS PRODUCTOS FARMACÉUTICOS".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("No.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITOS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CRITERIO".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evidencias / Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPM_Bpa.TransProdFarmaceuticos.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Numero);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });

                            column.Item().PaddingVertical(5).AlignLeft().Text(" ");
                            column.Item().AlignLeft().Text(string.Format("5. AUTO-INSPECCIÓN".ToUpper())).Bold();
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)4);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)0.5);
                                    columns.RelativeColumn((float)3.5);
                                });
                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("No.".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("REQUISITOS".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("CRITERIO".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Cap".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Art".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evaluación".ToUpper());
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("Evidencias / Observaciones".ToUpper());
                                });

                                foreach (var dat in inspection.InspGuiaBPM_Bpa.AutoInspec.LContenido)
                                {
                                    if (dat.IsHeader)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text("");
                                    }
                                    else
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Numero);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Titulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(dat.Criterio);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Capitulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Articulo);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(DataModel.Helper.Helper.GetDescription(dat.Evaluacion));
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(dat.Observaciones);
                                    }
                                }
                            });


                            column.Item().PaddingVertical(5).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("OBSERVACIONES GENERALES").Bold();
                                });

                                table.Cell().Border(1).BorderColor(Colors.Black).AlignLeft().Text(inspection.InspGuiaBPM_Bpa.DatosConclusiones.ObservacionesFinales);

                            });


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(3).AlignLeft().Text("Por el Establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream,ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspGuiaBPM_Bpa.RepresentLegal?.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspGuiaBPM_Bpa.RepresentLegal.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }

                                table.Cell().AlignLeft().Text("");

                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico?.Nombre, inspection.InspGuiaBPM_Bpa.RegenteFarmaceutico?.Cedula));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}", inspection.InspGuiaBPM_Bpa.RepresentLegal?.Nombre, inspection.InspGuiaBPM_Bpa.RepresentLegal?.Cedula));

                                table.Cell().AlignLeft().Text("");

                                table.Cell().ColumnSpan(3).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(3).AlignLeft().Text("Por la Dirección Nacional de Farmacia y Drogas:").Bold();

                                    foreach (var participant in inspection.InspGuiaBPM_Bpa.DatosConclusiones.LParticipantes)
                                    {
                                        table.Cell().Table(tbl =>
                                        {
                                            tbl.ColumnsDefinition(columns =>
                                            {
                                                columns.RelativeColumn(1);
                                            });
                                            if (!string.IsNullOrEmpty(participant.Firma))
                                            {
                                                byte[] data = Convert.FromBase64String(participant.Firma.Split("image/png;base64,")[1]);
                                                MemoryStream memoryStream = new MemoryStream(data);
                                                tbl.Cell().AlignLeft().Image(memoryStream, ImageScaling.FitWidth);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1} | Reg.:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Fecha y Hora de finalizada la inspección: {0}", inspection.InspGuiaBPM_Bpa.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt") ?? ""));

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(6);
                                columns.RelativeColumn(4);
                            });

                            //table.Header(header =>
                            //{
                            //    header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                            //    header.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                            //});

                            table.Cell().Table(tbl => {
                                tbl.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                    cols.RelativeColumn();
                                });
                                tbl.Cell().AlignLeft().Text("S. Inspecciones");
                                tbl.Cell().AlignLeft().Text("512-9168/62 (Ext. 1126)");
                                tbl.Cell().AlignLeft().Text("inspeccionesfyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("S. Auditorías");
                                tbl.Cell().AlignLeft().Text("512-9168/62");
                                tbl.Cell().AlignLeft().Text("auditoriafyd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Veraguas");
                                tbl.Cell().AlignLeft().Text("935-0316/18");
                                tbl.Cell().AlignLeft().Text("orvdnfd@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Chiriquí");
                                tbl.Cell().AlignLeft().Text("774-7410");
                                tbl.Cell().AlignLeft().Text("fydchiriqui@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Colón");
                                tbl.Cell().AlignLeft().Text("475-2060 Ext. 5021");
                                tbl.Cell().AlignLeft().Text("mbramwell@minsa.gob.pa");

                                tbl.Cell().AlignLeft().Text("OR Panamá Pacífico");
                                tbl.Cell().AlignLeft().Text("504-2565");
                                tbl.Cell().AlignLeft().Text("rlquiros@minsa.gob.pa");
                            });

                            table.Cell().AlignRight().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
                        });


                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch(Exception ex) 
            { }
            return null;
        }


        ///////////////////////////
        ///

        public async Task<Stream> GenerateCorrespondencia(long Id)
        {
            try
            {
                var correspondencia = DalService.Get<AUD_CorrespondenciaTB>(Id);

                // code in your main method
                var byteArray = QuestPDF.Fluent.Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(5, Unit.Millimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(8));
                        //page.DefaultTextStyle(x => x.Color("Black"));

                        var path = System.IO.Path.Combine(env.WebRootPath, "img", "pdf", "Header.png");

                        page.Header().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Image(path);
                                header.Cell().AlignCenter().Text("");
                                header.Cell().AlignCenter().Text("");
                                //header.Cell().AlignRight().AlignMiddle().Text(string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones)));
                            });

                            table.Cell().ColumnSpan(3).AlignLeft().Text("DIRECCIÓN NACIONAL DE FARMACIA Y DROGAS").Bold();
                            table.Cell().ColumnSpan(3).AlignCenter().Text("Departamento de Auditorías de Calidad a Establecimientos Farmacéuticos y No Farmacéuticos");
                            //table.Cell().ColumnSpan(3).AlignCenter().Text("Guía para las Buenas Prácticas de Almacenamiento, Distribución y Transporte de Medicamentos y Otros Productos para la Salud Humana".ToUpper()).Bold();
                        });

                        page.Content().PaddingVertical(20).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("Para: {0} \r\n{1}", correspondencia.NombreDirigido, correspondencia.DptoSeccion));
                            column.Item().AlignLeft().Text(string.Format("Fecha: {0}", DateTime.Now.ToString("dd/MM/yyyy")));

                            
                            column.Item().PaddingVertical(10).AlignLeft().Text(string.Format(" ".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(string.Format("Asunto:".ToUpper())).Bold();
                            column.Item().AlignLeft().Text(correspondencia.Asunto);
                            
                        });

                        page.Footer().Column(column =>
                        {
                            column.Item().AlignLeft().Text("De: ______________________________________");
                            column.Item().AlignLeft().Text("Ana Belén Gonzáles");
                            column.Item().AlignLeft().Text("Jefa del Dpto. Auditorías de Calidad a \r\nEstablecimientos Farmacéuticos y NF");

                        });

                    });
                })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch (Exception ex)
            { }
            return null;
        }

    }

}
