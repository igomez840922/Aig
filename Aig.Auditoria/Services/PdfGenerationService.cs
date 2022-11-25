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
using Microsoft.Net.Http.Headers;

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
                            return await GenerateAperturaCambioUbicacionPDF(inspection);
                        }
                    case DataModel.Helper.enumAUD_TipoActa.AA:
                    case DataModel.Helper.enumAUD_TipoActa.CUA:
                        {
                            return await GenerateAperturaCambioUbicacionPDF(inspection);
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
        private async Task<Stream> GenerateAperturaCambioUbicacionPDF(AUD_InspeccionTB inspection)
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

                        page.Content().PaddingVertical(15).Column(column =>
                        {
                            column.Item().AlignLeft().Text(string.Format("TIPO DE INSPECCIÓN:{0}",DataModel.Helper.Helper.GetDescription(inspection.TipoActa)));
                            column.Item().AlignLeft().Text(string.Format("TIPO DE ESTABLECIMIENTO:{0}", DataModel.Helper.Helper.GetDescription(inspection.Establecimiento.TipoEstablecimiento)));


                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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
                                    footer.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ley 66 de 10 de noviembre de 1947. Código Sanitario de la República de Panamá. (G.O. 10467 de 6 de diciembre de 1947). Artículo 200. Prohíbese ejercer conjuntamente las \r\nprofesiones de médico-cirujano y farmacéutico. A partir de la aprobación de este código, ningún médico que ejerza la profesión podrá ser dueño por sí mismo o por interpuesta persona, accionista o tener participación comercial cualquiera en establecimientos en que se fabriquen, preparen o vendan medicinas y artículos de cualquier clase que se usen para la prevención o curación de enfermedades, corrección de defectos o para el diagnóstico");
                                });
                            });

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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

                                table.Footer(footer =>
                                {
                                    footer.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Ley 66 de 10 de noviembre de 1947. Código Sanitario de la República de Panamá. (G.O. 10467 de 6 de diciembre de 1947). Artículo 200. Prohíbese ejercer conjuntamente las \r\nprofesiones de médico-cirujano y farmacéutico. A partir de la aprobación de este código, ningún médico que ejerza la profesión podrá ser dueño por sí mismo o por interpuesta persona, accionista o tener participación comercial cualquiera en establecimientos en que se fabriquen, preparen o vendan medicinas y artículos de cualquier clase que se usen para la prevención o curación de enfermedades, corrección de defectos o para el diagnóstico");
                                });
                            });

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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
                                
                                table.Cell().ColumnSpan(1).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Firma del Regente");
                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosRegente.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().ColumnSpan(2).AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().ColumnSpan(2).Text("");
                                }

                            });

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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
                                    header.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Background(Colors.Grey.Lighten1).AlignCenter().Text("INFRAESTRUCTURA DE LA FARMACIA").Bold();
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

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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
                                table.Cell().ColumnSpan(2).Border(1).BorderColor(Colors.Black).AlignLeft().Text("Firma del Regente");
                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosRegente.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosRegente.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().Text("");
                                }
                            });

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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

                            column.Item().PaddingVertical(10).AlignTop().Table(table =>
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

                            column.Item().PaddingVertical(10).Text("OBSERVACIÓN:").Bold();
                            column.Item().Text("El Acta original se mantendrá en el expediente del establecimiento que permanece en la Dirección Nacional de Farmacia y Drogas y se hace entrega de una copia al firmante de esta acta, al finalizar la inspección").Bold();

                            column.Item().PaddingVertical(10).Text("DE NO CUMPLIR CON LOS REQUISITOS MÍNIMOS ESTRUCTURALES EN ESTA ACTA, EL USUARIO DEBERÁ SUBSANAR TODOS LOS PUNTOS PENDIENTES, PARA SU DEBIDA VERIFICACIÓN EN UNA SEGUNDA INSPECCIÓN. DE REINCIDIR EN LAS DESVIACIONES IDENTIFICADAS EN LA PRIMERA INSPECCIÓN, SE PROCEDERÁ A LA DEVOLUCIÓN DE LA SOLICITUD Y EL INTERESADO DEBERÁ REINICIAR EL TRÁMITE CON TODOS LOS REQUISITOS ESTABLECIDOS PARA EL MISMO").Bold();


                            column.Item().PaddingVertical(5).Text(string.Format("Esta Acta se levanta en presencia de los abajo firmantes\r\n"));
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(1);
                                    columns.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(2).AlignLeft().Text("Por el establecimiento:").Bold();
                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosAtendidosPor.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosAtendidosPor.Firma.Split("image/png;base64,")[1]);
                                    MemoryStream memoryStream = new MemoryStream(data);
                                    table.Cell().AlignLeft().Image(memoryStream);
                                }
                                else
                                {
                                    table.Cell().AlignLeft().Text("");
                                }
                                if (!string.IsNullOrEmpty(inspection.InspAperCambUbicFarm.DatosRegente.Firma))
                                {
                                    //var bytes = Convert.FromBase64String(base64encodedstring);
                                    //var contents = new StreamContent(new MemoryStream(bytes));
                                    byte[] data = Convert.FromBase64String(inspection.InspAperCambUbicFarm.DatosRegente.Firma.Split("image/png;base64,")[1]);
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
                                if (inspection.InspAperCambUbicFarm.DatosConclusiones.LParticipantes != null)
                                {
                                    table.Cell().ColumnSpan(2).AlignLeft().Text("Por el Ministerio de Salud (DNFD):").Bold();

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
                                                tbl.Cell().AlignLeft().Image(memoryStream);
                                            }
                                            tbl.Cell().AlignLeft().Text(string.Format("{0}\r\nCédula:{1}  |  No. Registro:{2}", participant.NombreCompleto, participant.CedulaIdentificacion, participant.RegistroNumero));

                                        });
                                    }
                                }

                            });

                            column.Item().PaddingVertical(5).Text(string.Format("Hora de finalización de inspección: {0}", inspection.InspAperCambUbicFarm.DatosConclusiones.FechaFinalizacion?.ToString("dd/MM/yyyy hh:mm tt")??""));

                            column.Item().PaddingVertical(5).Text("Fundamento Legal").Bold();
                            column.Item().Text("Ley 66 de 10 de noviembre de 1947 \r\nLey 1 de 10 de enero de 2001 \r\nLey 17 de 12 de septiembre de 2014 \r\nLey 24 de 29 de enero de 1963 \r\nDecreto Ejecutivo 115 de 16 de agosto de 2022 \r\nResolución No. 774 de 7 de octubre de 2019");

                        });

                        page.Footer().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().AlignLeft().AlignBottom().Text("Teléfono de Oficina 512-9168\r\nCorreo Electrónico: inspeccionesfyd@minsa.gob.pa");
                                header.Cell().AlignLeft().AlignBottom().Text(string.Format("Confeccionado: Sección de Inspecciones {0}", DateTime.Now.ToString("dd/MM/yyyy")));
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
