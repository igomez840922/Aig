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
using System.Collections;

namespace Aig.FarmacoVigilancia.Services
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
                                  if (inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes != null)
                                  {
                                      foreach (var partic in inspection.InspRetiroRetencion.DatosConclusiones.LParticipantes)
                                      {
                                          participantes += partic.NombreCompleto + ", ";
                                      }
                                  }
                                  column.Item().Text(string.Format("Siendo las {0} del día {1} de {2} de {3}, actuando en representación de la Dirección Nacional de Farmacia y Drogas del Ministerio de Salud, procedimos a efectuar la {4}, de los productos a continuación descritos y que fueron localizados en el establecimiento denominado: {5}, ubicado en: {6}, con Aviso de Operación No. {7} y Licencia de operación {8}/DNFD. Y cuyo Representante Legal es {9} con documento de identidad personal N° {10}. Por la Dirección Nacional de Farmacia y Drogas, participamos: {11}. Y fuimos atendidos por: {12}, con cargo {13} cip: {14}\r\n",
                                      inspection.FechaInicio.ToString("hh:mm tt"), inspection.FechaInicio.ToString("dd"), Helper.Helper.GetMonthNameByMonthNumber(int.Parse(inspection.FechaInicio.ToString("MM"))), inspection.FechaInicio.ToString("yyyy"), DataModel.Helper.Helper.GetDescription(inspection.InspRetiroRetencion.RetiroRetencionType), inspection.Establecimiento?.Nombre??"", inspection.UbicacionEstablecimiento,inspection.AvisoOperacion, inspection.LicenseNumber, inspection.RepreLegal,inspection.RepreLegalIdentificacion, participantes, inspection.ParticEstablecimiento, inspection.ParticEstablecimientoCargo, inspection.ParticEstablecimientoCIP));

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
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.CantidadRetirada);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.CantidadRetenida);
                                              table.Cell().Border(1).BorderColor(Colors.Black).AlignCenter().Text(prod.Motivo);

                                              static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                                          }
                                      }  
                                  
                                  });

                                  column.Item().PaddingVertical(10).Text(string.Format("Los productos retenidos y retirados del establecimiento se mantendrán bajo custodia en las instalaciones de la Dirección Nacional de Farmacia y Drogas, hasta culminar las investigaciones.\r\nLos productos farmacéuticos que se mantengan retenidos en el local no podrán ser movidos del lugar donde se fijó su ubicación al momento de levantar este documento.\r\n"));

                              });

                          //page.Footer().AlignBottom().Column(column =>
                          //   {
                          //       column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                          //       column.Item().Table(table =>
                          //       {
                          //           table.ColumnsDefinition(columns =>
                          //           {
                          //               columns.RelativeColumn();
                          //               columns.RelativeColumn();
                          //               columns.RelativeColumn();
                          //           });

                          //           table.Cell().AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();
                          //           table.Cell().Text("");
                          //           table.Cell().AlignLeft().Text("Por el establecimiento:").Bold();

                          //           if (!string.IsNullOrEmpty(inspection.InspRetiroRetencion.DatosConclusiones.FirmaInspector1))
                          //           {
                          //               //var bytes = Convert.FromBase64String(base64encodedstring);
                          //               //var contents = new StreamContent(new MemoryStream(bytes));
                          //               byte[] data = Convert.FromBase64String(inspection.InspRetiroRetencion.DatosConclusiones.FirmaInspector1.Split("image/png;base64,")[1]);
                          //               MemoryStream memoryStream = new MemoryStream(data);
                          //               table.Cell().AlignLeft().Image(memoryStream);
                          //           }
                          //           else
                          //           {
                          //               table.Cell().AlignLeft().Text("");
                          //           }
                          //           table.Cell().Text("");
                          //           if (!string.IsNullOrEmpty(inspection.InspRetiroRetencion.DatosConclusiones.FirmaRepresentanteLegal))
                          //           {
                          //               //var bytes = Convert.FromBase64String(base64encodedstring);
                          //               //var contents = new StreamContent(new MemoryStream(bytes));
                          //               byte[] data = Convert.FromBase64String(inspection.InspRetiroRetencion.DatosConclusiones.FirmaRepresentanteLegal.Split("image/png;base64,")[1]);
                          //               MemoryStream memoryStream = new MemoryStream(data);
                          //               table.Cell().AlignLeft().Image(memoryStream);
                          //           }
                          //           else
                          //           {
                          //               table.Cell().AlignLeft().Text("");
                          //           }

                          //           table.Cell().AlignLeft().Text(string.Format("Cédula:{0}  No. Registro:{1}", inspection.InspRetiroRetencion.DatosConclusiones.CedulaInspector1, inspection.InspRetiroRetencion.DatosConclusiones.RegistroInspector1));
                          //           table.Cell().Text("");
                          //           table.Cell().AlignLeft().Text(string.Format("Cédula:{0}  Cargo: {1}", inspection.InspRetiroRetencion.DatosConclusiones.CedulaRepresentanteLegal, inspection.InspRetiroRetencion.DatosConclusiones.CargoRepresentanteLegal));

                          //       });
                          //       column.Item().PaddingVertical(10).Text(" ");
                          //       column.Item().AlignBottom().Table(table =>
                          //       {
                          //           table.ColumnsDefinition(columns =>
                          //           {
                          //               columns.RelativeColumn(1);
                          //               columns.RelativeColumn((float)1.5);
                          //           });

                          //           table.Cell().AlignLeft().Text(" ");                                     

                          //           table.Cell().Border(1).BorderColor(Colors.Black).Padding(10).AlignBottom().AlignLeft().Column(col =>
                          //           {
                          //               col.Item().AlignLeft().Text("Para uso de la Administración de la DNFD:").Bold();
                          //               col.Item().PaddingTop(5).Text("Productos recibidos por (nombre): _____________________________________________________________");
                          //               col.Item().PaddingTop(15).Text("(firma): ___________________________________________________________________________________________");
                          //               col.Item().PaddingTop(15).Text("Fecha (dd/MM/yyyy): __________________________     Hora: __________________________");
                          //           });

                          //       });

                          //   });
                          
                      
                      });
                  })
                  .GeneratePdf();

                Stream stream = new MemoryStream(byteArray);

                return stream;
            }
            catch { }
            return null;
        }

        //generamos el pdf del Acta de Retiro y Retencion de Productos
        public async Task<Stream> GenerateNotePDF(long IdNote)
        {
            try
            {
                var note = DalService.Get<FMV_NotaTB>(IdNote);

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
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("{0}\r\n{1}", 
                                    note.NumNota,
                                    string.Format("{0} de {1} de {2}", note.Fecha?.ToString("dd") ?? "", Helper.Helper.GetMonthNameByMonthNumber(int.Parse(note.Fecha?.ToString("MM") ?? "0")), note.Fecha?.ToString("yyyy") ?? DateTime.Now.Year.ToString()))).Bold();//string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones))
                            });

                            //table.Cell().ColumnSpan(3).AlignLeft().Text(note.NumNota).Bold();
                            //table.Cell().ColumnSpan(3).AlignLeft().Text("");
                            //table.Cell().ColumnSpan(3).AlignCenter().Text("").Bold();

                            //table.Cell().ColumnSpan(3).AlignLeft().Text("").Bold();
                            //table.Cell().ColumnSpan(3).AlignLeft().Text("");
                            //table.Cell().ColumnSpan(3).AlignCenter().Text("").Bold();
                        });

                        page.Content().PaddingVertical(15).Column(column =>
                        {
                            column.Item().Text(string.Format("Para: {0}", note.Destinatario?.ToUpper() ??""));

                            column.Item().PaddingVertical(20).Text(string.Format("De: {0}{1}", "MAGISTRA ELVIA C. LAU\r\n", "Directora Nacional de Farmacias y Drogas"));

                            column.Item().PaddingVertical(5).AlignCenter().AlignMiddle().Text("NOTA DE SEGURIDAD DE MEDICAMENTOS").Bold();

                            column.Item().PaddingVertical(5).AlignLeft().AlignMiddle().Text("EL DEPARTAMENTO DE FARMACOVIGILANCIA DE LA DIRECCIÓN NACIONAL DE FARMACIAS Y DROGAS DEL MINISTERIO DE SALUD EN MATERIA DE MEDICAMENTOS CONSIDERA PERTINENTE COMUNICARLES LA SIGUIENTE INFORMACIÓN:").Bold();

                            column.Item().PaddingVertical(5).AlignLeft().AlignMiddle().Text(string.Format("{0}", note.Descripcion));

                            column.Item().PaddingVertical(10).AlignLeft().AlignMiddle().Text("");

                            ////////////////////////////
                            ///

                            //column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                            //column.Item().Table(table =>
                            //{
                            //    table.ColumnsDefinition(columns =>
                            //    {
                            //        columns.RelativeColumn();
                            //        columns.RelativeColumn();
                            //        columns.RelativeColumn();
                            //    });

                            //    table.Cell().AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("Por el establecimiento:").Bold();

                            //    table.Cell().AlignLeft().Text(string.Format("No. Registro: {0}", inspection.NumRegDNFD1));
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text(string.Format("Cédula: {0}  Cargo: {1}", inspection.ParticEstablecimientoCIP, inspection.ParticEstablecimientoCargo));


                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD1))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD1.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    if (!string.IsNullOrEmpty(inspection.FirmaEstablec1))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaEstablec1.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD2))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD2.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    if (!string.IsNullOrEmpty(inspection.FirmaEstablec2))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaEstablec2.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD3))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD3.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("");

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD4))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD4.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("");

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD5))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD5.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("");

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD6))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD6.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("");

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD7))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD7.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("");

                            //    if (!string.IsNullOrEmpty(inspection.FirmaDNFD8))
                            //    {
                            //        //var bytes = Convert.FromBase64String(base64encodedstring);
                            //        //var contents = new StreamContent(new MemoryStream(bytes));
                            //        byte[] data = Convert.FromBase64String(inspection.FirmaDNFD8.Split("image/png;base64,")[1]);
                            //        MemoryStream memoryStream = new MemoryStream(data);
                            //        table.Cell().AlignLeft().Image(memoryStream);
                            //    }
                            //    else
                            //    {
                            //        table.Cell().AlignLeft().Text("");
                            //    }
                            //    table.Cell().Text("");
                            //    table.Cell().AlignLeft().Text("");

                            //});
                            //column.Item().PaddingVertical(10).Text(" ");
                            //column.Item().AlignBottom().Table(table =>
                            //{
                            //    table.ColumnsDefinition(columns =>
                            //    {
                            //        columns.RelativeColumn(1);
                            //        columns.RelativeColumn((float)1.5);
                            //    });

                            //    table.Cell().AlignLeft().Text(" ");

                            //    table.Cell().Border(1).BorderColor(Colors.Black).Padding(10).AlignBottom().AlignLeft().Column(col =>
                            //    {
                            //        col.Item().AlignLeft().Text("Para uso de la Administración de la DNFD:").Bold();
                            //        col.Item().PaddingTop(5).Text("Productos recibidos por (nombre): _____________________________________________________________");
                            //        col.Item().PaddingTop(15).Text("(firma): ___________________________________________________________________________________________");
                            //        col.Item().PaddingTop(15).Text("Fecha (dd/MM/yyyy): __________________________     Hora: __________________________");
                            //    });

                            //});


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

        public async Task<Stream> GenerateAlertPDF(long IdAlert)
        {
            try
            {
                var alerta = DalService.Get<FMV_AlertaTB>(IdAlert);

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
                                header.Cell().AlignRight().AlignMiddle().Text(string.Format("{0}\r\n{1}",
                                    alerta.NumNota,
                                    string.Format("{0} de {1} de {2}", alerta.FechaRecepcion?.ToString("dd") ?? "", Helper.Helper.GetMonthNameByMonthNumber(int.Parse(alerta.FechaRecepcion?.ToString("MM") ?? "0")), alerta.FechaRecepcion?.ToString("yyyy") ?? DateTime.Now.Year.ToString()))).Bold();//string.Format("Acta N°: {0}\r\nEstatus: {1}", inspection.NumActa, DataModel.Helper.Helper.GetDescription(inspection.StatusInspecciones))
                            });

                        });

                        page.Content().PaddingVertical(15).Column(column =>
                        {
                            //column.Item().Text(string.Format("Para: {0}", alerta.Destinatario?.ToUpper() ?? ""));

                            column.Item().PaddingVertical(20).Text(string.Format("De: {0}{1}", "MAGISTRA ELVIA C. LAU\r\n", "Directora Nacional de Farmacias y Drogas"));

                            column.Item().PaddingVertical(5).AlignCenter().AlignMiddle().Text("ALERTA DE SEGURIDAD DE MEDICAMENTOS").Bold();

                            column.Item().PaddingVertical(5).AlignCenter().AlignMiddle().Text(string.Format("{0} - {1}", alerta.Producto, alerta.DCI)).Bold();

                            column.Item().PaddingVertical(5).AlignLeft().AlignMiddle().Text("EL DEPARTAMENTO DE FARMACOVIGILANCIA DE LA DIRECCIÓN NACIONAL DE FARMACIAS Y DROGAS DEL MINISTERIO DE SALUD EN MATERIA DE MEDICAMENTOS CONSIDERA PERTINENTE COMUNICARLES LA SIGUIENTE INFORMACIÓN:").Bold();

                            column.Item().PaddingVertical(5).AlignLeft().AlignMiddle().Text(string.Format("{0}", alerta.Descripcion));

                            column.Item().PaddingVertical(10).AlignLeft().AlignMiddle().Text("");

                            ////////////////////////////
                            ///
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

        public async Task<Stream> GetStreamsFromFile(string filePath)
        {
            try
            {
                if(File.Exists(filePath))
                {
                    MemoryStream ms = new MemoryStream();
                    using (FileStream fStream = new FileStream(filePath, FileMode.Open))
                    {
                        fStream.CopyTo(ms);
                    }                    
                    return ms;
                }               
            }
            catch { }
            return null;
        }

    }

}
