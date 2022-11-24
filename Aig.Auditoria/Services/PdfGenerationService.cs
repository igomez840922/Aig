using DataAccess.Auditoria;
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
               
        //generamos el pdf del Acta de Retiro y Retencion de Productos
        public async Task<Stream> GenerateRetentionReceptionPDF(long InspectionId)
        {
            try
            {
                var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

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
                                                   
                          page.Content().PaddingVertical(15).Column(column =>
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
                                      inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.ToString("dd"), Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.ToString("yyyy"), DataModel.Helper.Helper.GetDescription(inspection.InspRetiroRetencion.RetiroRetencionType), inspection.Establecimiento?.Nombre??"", inspection.UbicacionEstablecimiento,inspection.AvisoOperación, inspection.LicenseNumber, inspection.InspRetiroRetencion.DatosRepresentLegal.Nombre, inspection.InspRetiroRetencion.DatosRepresentLegal.Cedula, participantes, inspection.InspRetiroRetencion.DatosAtendidosPor.Nombre, inspection.InspRetiroRetencion.DatosAtendidosPor.Cargo, inspection.InspRetiroRetencion.DatosAtendidosPor.Cedula));

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

                                  column.Item().PaddingVertical(10).Text(string.Format("Los productos retenidos y retirados del establecimiento se mantendrán bajo custodia en las instalaciones de la Dirección Nacional de Farmacia y Drogas, hasta culminar las investigaciones.\r\nLos productos farmacéuticos que se mantengan retenidos en el local no podrán ser movidos del lugar donde se fijó su ubicación al momento de levantar este documento.\r\n"));

                                  ////////////////////////////
                                  ///

                                  column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                                  column.Item().Table(table =>
                                  {
                                      table.ColumnsDefinition(columns =>
                                      {
                                          columns.RelativeColumn(1);
                                          columns.RelativeColumn(1);
                                      });
                                      
                                      table.Cell().ColumnSpan(2).AlignLeft().Text("Por el establecimiento:").Bold();
                                      if (!string.IsNullOrEmpty(inspection.InspRetiroRetencion.DatosAtendidosPor.Firma))
                                      {
                                          //var bytes = Convert.FromBase64String(base64encodedstring);
                                          //var contents = new StreamContent(new MemoryStream(bytes));
                                          byte[] data = Convert.FromBase64String(inspection.InspRetiroRetencion.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                          MemoryStream memoryStream = new MemoryStream(data);
                                          table.Cell().AlignLeft().Image(memoryStream);
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
                                          table.Cell().AlignLeft().Image(memoryStream);
                                      }
                                      else
                                      {
                                          table.Cell().AlignLeft().Text("");
                                      }
                                      table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  Cargo:{2}", inspection.InspRetiroRetencion.DatosAtendidosPor.Nombre, inspection.InspRetiroRetencion.DatosAtendidosPor.Cedula, inspection.InspRetiroRetencion.DatosAtendidosPor.Cargo));
                                      table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  Cargo:{2}  |  No. Registro:{3}", inspection.InspRetiroRetencion.DatosRegente.Nombre, inspection.InspRetiroRetencion.DatosRegente.Cedula, inspection.InspRetiroRetencion.DatosRegente.Cargo, inspection.InspRetiroRetencion.DatosRegente.NumRegistro));

                                      table.Cell().ColumnSpan(2).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                      if (inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes !=null)
                                      {
                                          table.Cell().ColumnSpan(2).AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();

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
                                                      tbl.Cell().AlignLeft().Image(memoryStream);
                                                  }
                                                  tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  No. Registro:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                              });
                                          }                                          
                                      }

                                  });

                                  column.Item().PaddingVertical(10).Text(" ");
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
        public async Task<Stream> GenerateAperturaCambioUbicacionPDF(long InspectionId)
        {
            try
            {
                var inspection = DalService.Get<AUD_InspeccionTB>(InspectionId);

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

                        page.Content().PaddingVertical(15).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN:{0}",DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO:{0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn((float)0.3);
                                    columns.RelativeColumn((float)1);
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


                                table.Cell().AlignLeft().Text(" ");


                            });



                            string participantes = "";
                            if (inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes != null)
                            {
                                foreach (var partic in inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes)
                                {
                                    participantes += partic.NombreCompleto + ", ";
                                }
                            }

                            column.Item().Text(string.Format("Siendo las {0} del día {1} de {2} de {3}, actuando en representación de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud, procedimos a efectuar la {4}, de los productos a continuación descritos y que fueron localizados en el establecimiento denominado: {5}, ubicado en: {6}, con Aviso de Operación No. {7} y Licencia de operación {8}/DNFD. Y cuyo Representante Legal es {9} con documento de identidad personal N° {10}. Por la Dirección Nacional de Farmacia y Drogas, participamos: {11}. Y fuimos atendidos por: {12}, con cargo {13} cip: {14}\r\n",
                                inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.ToString("dd"), Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.ToString("yyyy"), DataModel.Helper.Helper.GetDescription(inspection.InspRetiroRetencion.RetiroRetencionType), inspection.Establecimiento?.Nombre ?? "", inspection.UbicacionEstablecimiento, inspection.AvisoOperación, inspection.LicenseNumber, inspection.InspRetiroRetencion.DatosRepresentLegal.Nombre, inspection.InspRetiroRetencion.DatosRepresentLegal.Cedula, participantes, inspection.InspRetiroRetencion.DatosAtendidosPor.Nombre, inspection.InspRetiroRetencion.DatosAtendidosPor.Cargo, inspection.InspRetiroRetencion.DatosAtendidosPor.Cedula));

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
                                if (inspection.InspRetiroRetencion != null && inspection.InspRetiroRetencion.LProductos != null)
                                {
                                    foreach (var prod in inspection.InspRetiroRetencion.LProductos)
                                    {
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Nombre);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.PresentacionComercial);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Fabricante);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Pais);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Lote);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.FechaExp?.ToString("dd/MM/yyyy") ?? "");
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.CantidadRetenida);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.CantidadRetirada);
                                        table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Motivo);

                                        static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                                    }
                                }

                            });

                            column.Item().PaddingVertical(10).Text(string.Format("Los productos retenidos y retirados del establecimiento se mantendrán bajo custodia en las instalaciones de la Dirección Nacional de Farmacia y Drogas, hasta culminar las investigaciones.\r\nLos productos farmacéuticos que se mantengan retenidos en el local no podrán ser movidos del lugar donde se fijó su ubicación al momento de levantar este documento.\r\n"));

                            ////////////////////////////
                            ///

                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(2).AlignLeft().Text("Por el establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspRetiroRetencion.DatosAtendidosPor.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspRetiroRetencion.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream);
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
                                    table.Cell().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  Cargo:{2}", inspection.InspRetiroRetencion.DatosAtendidosPor.Nombre, inspection.InspRetiroRetencion.DatosAtendidosPor.Cedula, inspection.InspRetiroRetencion.DatosAtendidosPor.Cargo));
                                table.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  Cargo:{2}  |  No. Registro:{3}", inspection.InspRetiroRetencion.DatosRegente.Nombre, inspection.InspRetiroRetencion.DatosRegente.Cedula, inspection.InspRetiroRetencion.DatosRegente.Cargo, inspection.InspRetiroRetencion.DatosRegente.NumRegistro));

                                table.Cell().ColumnSpan(2).AlignLeft().PaddingVertical(5).Text(" ").Bold();
                                if (inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(2).AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();

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
                                                tbl.Cell().AlignLeft().Image(memoryStream);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  No. Registro:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(10).Text(" ");
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

    }

}
