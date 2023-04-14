using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Identity;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
namespace Aig.Farmacoterapia.Infrastructure.Services
{
    public class ReportService : IReportService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter _converter;
        private readonly ISystemLogger _logger;
        public ReportService(UserManager<ApplicationUser> userManager,
            IUnitOfWork unitOfWork,
            IConverter converter,
            ISystemLogger logger) {
            _userManager = userManager;
            _converter = converter;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task<byte[]> GetNotePdfAsync(long studyId)
        {
            try
            {
                var dateFormatInfo = CultureInfo.CreateSpecificCulture("es-PAN").DateTimeFormat;
                var item = await _unitOfWork.Repository<AigEstudio>().GetByIdAsync(studyId);
                item!.EvaluatorToShow = EvaluatorToShow(item.EstudioEvaluador.Select(s => s.UserId).ToList(), item.Nota?.Jefe);
                if (item == null) return new byte[0];
                var html = "<html>" +
                              "<body style=\"margin: 40px !important;padding: 40px !important;text-align: justify;font-family: Arial;font-size: 18px;\">" +
                              $" <div style=\"font-weight: bold !important;\">{item.Nota?.GetNoteCode(item.Id)}</div>" +
                              $" <div style=\"font-weight: bold !important;\">Panamá, {item.Nota?.FechaEvaluacion!.Value.ToString("dd 'de' MMMM 'de' yyyy", dateFormatInfo) ?? ""} </div>" +
                              $" <div style=\"margin-top:20px !important;font-weight: bold !important;\">{item.Tramitante.Nombre} </div> " +
                              $" <div style=\"font-weight: bold !important;\"> {item.AgenciaDistribuidora} </div>" +
                              $"{BuildTitle(item)}" +
                              $"{BuildTable(item)}" +
                              $"{BuildNote(item)}" +
                              " <div style=\"page-break-inside: avoid;margin-top:40px !important;\">Atentamente</div>" +
                              "  <div style=\"font-family:'Arial';font-size: 14px;font-weight: bold;margin-top:50px\">" +
                              "    <div>----------------------------------------------------------------------</div>" +
                              $"   <div>{item.Nota?.DirectoraNacional?.ToUpper()}</div>" +
                              "    <div> Director(a) Nacional de Farmacia y Drogas</div>" +
                              $"    <div style=\"font-size: 10px;\"> { item!.EvaluatorToShow} </div>" +
                              "  </div>" +
                              "</body>" +
                            "</html>";
              
                var settings = new GlobalSettings();
                settings.ColorMode = ColorMode.Color;
                settings.Orientation = Orientation.Portrait;
                settings.PaperSize = PaperKind.Letter;
                //settings.Margins = new MarginSettings { Left=0, Right = 0, Top = 40, Bottom = 6.2 };
                settings.Margins = new MarginSettings { Left = 0, Right = 0, Top = 50, Bottom = 15 };
                var objectSettings = BuildSettings(html);
                var doc = new HtmlToPdfDocument() { GlobalSettings = settings, Objects = { objectSettings } };
                return _converter.Convert(doc);
            }
            catch (Exception ex){;}
            return new byte[0];
        }
        private string EvaluatorToShow(List<string> evaluators, string jefe)
        {
            string result = string.Empty;
            try
            {
                var list = _userManager.Users.Where(p => evaluators.Contains(p.Id)).ToList()
                                              .Select(w => { w.FirstName = w.FirstName[..1].ToLower(); w.LastName = w.LastName[..1].ToLower(); return $"{ w.FirstName}{ w.LastName}"; }).ToList();
                if (list != null && !string.IsNullOrEmpty(jefe) && !list.Any(p => p == jefe.ToLower()))
                    list.Insert(0,jefe);
               result = string.Join(" / ", list);
            }
            catch (Exception exc)
            {
                _logger.Error(exc.Message, exc);
            }
            return result;
        }
        private static ObjectSettings BuildSettings(string html)
        {
            var header = Path.Combine(Directory.GetCurrentDirectory(), "DinkToPdf.v0.12.4", "resources", "header.html");
            var footer = Path.Combine(Directory.GetCurrentDirectory(), "DinkToPdf.v0.12.4", "resources", "footer.html");


            ObjectSettings objectSettings = new ObjectSettings();
            objectSettings.PagesCount = true;
            objectSettings.HtmlContent = html;
            WebSettings webSettings = new WebSettings();
            webSettings.DefaultEncoding = "utf-8";

            HeaderSettings headerSettings = new HeaderSettings();
            headerSettings.HtmUrl = header;
            //headerSettings.FontSize = 11;
            //headerSettings.FontName = "Arial";
            //headerSettings.Right = "Página [page] de [toPage]";



            FooterSettings footerSettings = new FooterSettings();
            footerSettings.HtmUrl = footer;

            footerSettings.FontSize = 10;
            footerSettings.FontName = "Arial";
            footerSettings.Right = "Página [page] de [toPage]        ";
            footerSettings.Spacing = 2.5;

            objectSettings.HeaderSettings = headerSettings;
            objectSettings.FooterSettings = footerSettings;
            objectSettings.WebSettings = webSettings;
            return objectSettings;
        }

        private static string BuildTitle(AigEstudio model)
        {
            var item = model.Medicamentos.FirstOrDefault();
            string facture = item != null ? item.Factura : "--";
            StringBuilder sb = new StringBuilder();
            var title = model.Estado == EstadoEstudio.Authorized ? $"En referencia al Protocolo de Investigación del estudio clínico {model?.Codigo}" +
                                      $" titulado \"{model?.Titulo}\" cuyo investigador principal es: {model?.InvestigadorPrincipal}," +
                                      $" a realizarse en {model?.CentroInvestigacion}, le informamos que autorizamos la introducción al país" +
                                      $" de los siguientes productos, exclusivamente para el fin indicado." :
                                      $"En referencia al Protocolo de Investigación del estudio clínico {model?.Codigo}" +
                                      $" titulado \"{model?.Titulo}\" cuyo investigador principal es: {model?.InvestigadorPrincipal}," +
                                      $" a realizarse en {model?.CentroInvestigacion}, correspondiente a la Factura: {facture}," +
                                      $" le informamos los siguientes aspectos:";

            sb.AppendLine("<div style=\"margin-top:20px !important\">");
            sb.AppendLine("<p  style=\"white-space: pre-line;text-align: justify;font-family: Arial; font-size: 18px;line-height: 24px\">");
            sb.AppendLine(title);
            sb.AppendLine("</p>");
            sb.AppendLine("<div/>");
            return sb.ToString();
        }
        private static string BuildTable(AigEstudio model)
        {
            if (model.Estado== EstadoEstudio.NotAuthorized) return "";
            StringBuilder sb = new StringBuilder();
            foreach (var item in model.Medicamentos)
            {
                sb.AppendLine("<div style=\"margin-top: 20px;\">");
                sb.AppendLine("<table style=\"page-break-inside: avoid;font-family:'Arial';font-size: 18px; border: 1px solid #797575;padding: 10px; width: 100%;\">");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Factura N°</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Factura}</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Cantidad</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Cantidad}</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Producto</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Nombre} {item.PrincipioActivo} {item.FormaFarmaceutica} {item.ViaAdministracion} {item.Presentacion}</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Fabricante</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Fabricante?.Nombre} {item.Fabricante?.Direccion} / {item.Fabricante?.Pais}</td>");
                sb.AppendLine("</tr>");

                if (!string.IsNullOrEmpty(item.Acondicionador?.Nombre))
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Acondicionador</td>");
                    sb.AppendLine($"<td style=\"padding: 5px;\">{item.Acondicionador?.Nombre} {item.Acondicionador?.Direccion} / {item.Acondicionador?.Pais}  </td>");
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Lote</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Lote}</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">Fecha de vencimiento</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Expiracion:d}</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td style=\"font-weight: bold;width: 100px;\">País de origen</td>");
                sb.AppendLine($"<td style=\"padding: 5px;\">{item.Fabricante?.Pais}</td>");
                sb.AppendLine("</tr>");
                sb.AppendLine("<table/>");
                sb.AppendLine("<div/>");
            }


            return sb.ToString();
        }
        private static string BuildNote(AigEstudio model)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("<div style=\"page-break-inside: avoid;margin-top:20px !important\">");
            sb.AppendLine("<p style=\"white-space: pre-line;text-align: justify;font-family: 'Arial';font-size: 18px;line-height: 24px\">");
            sb.AppendLine(model.Nota?.Observaciones);
            sb.AppendLine("</p>");
            sb.AppendLine("<div/>");
            return sb.ToString();
        }
    }

    //public class ReportService : IReportService
    //{
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly ISystemLogger _logger;
    //    public ReportService(UserManager<ApplicationUser> userManager,IUnitOfWork unitOfWork, ISystemLogger logger){
    //        _userManager = userManager;
    //        _unitOfWork = unitOfWork;
    //        _logger = logger;
    //    }
    //    public async Task<byte[]> GetNotePdfAsync(long studyId) {
    //        var item = await _unitOfWork.Repository<AigEstudio>().GetByIdAsync(studyId);
    //        item!.EvaluatorToShow = EvaluatorToShow(item.EstudioEvaluador.Select(s => s.UserId).ToList());
    //        if (item == null) return new byte[0];
    //        var document = new NoteReport(item);
    //        return document.GeneratePdf();
    //    }
    //   private string EvaluatorToShow(List<string> evaluators)
    //    {
    //        string result = string.Empty;
    //        try
    //        {
    //            var list = _userManager.Users.Where(p => evaluators.Contains(p.Id)).ToList()
    //                                          .Select(w => { w.FirstName = w.FirstName[..1].ToLower(); w.LastName = w.LastName[..1].ToLower(); return $"{ w.FirstName}{ w.LastName}"; });
    //            result = string.Join(" / ", list);
    //        }
    //        catch (Exception exc)
    //        {
    //            _logger.Error(exc.Message, exc);
    //        }
    //        return result;
    //    }
    //}
    //public class NoteReport : IDocument
    //{
    //    AigEstudio Model { get; }
    //    public NoteReport(AigEstudio model)
    //    {
    //        Model = model;
    //    }
    //    public DocumentMetadata GetMetadata() => new DocumentMetadata();

    //    public void Compose(IDocumentContainer container)
    //    {
    //        container.Page(page =>
    //        {
    //            page.DefaultTextStyle(x => x.FontFamily("Arial").FontSize(12));
    //            page.MarginVertical(10);
    //            page.MarginHorizontal(25);
    //            page.Size(PageSizes.A4);
    //            page.Header().Element(HeaderBody);
    //            page.Content().Element(ContentBody1);
    //            page.Footer().PaddingTop(10).PaddingBottom(5).AlignCenter().Text(x =>
    //              {
    //                  x.Span("Página ");
    //                  x.CurrentPageNumber();
    //              });
    //        });

    //    }
    //    void LogoBody(IContainer container)
    //    {
    //        container.ShowEntire().Row(row =>
    //        {
    //            var base64 = "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";
    //            var data = Convert.FromBase64String(base64);
    //            row.RelativeItem().AlignLeft().Width(200).Height(60).Image(data);
    //        });
    //    }
    //    void HeaderBody(IContainer container)
    //    {
    //        container.ShowEntire().Column(column =>
    //        {
    //            column.Item().Row(row =>
    //            {
    //                row.RelativeItem().Element(LogoBody);
    //            });
    //            column.Item().Row(row =>
    //            {
    //                row.RelativeItem().AlignLeft()
    //                    .Text($"Dirección Nacional de Farmacia y Drogas")
    //                    .FontColor("#383838")
    //                    .FontSize(14)
    //                    .Style(TextStyle.Default.Bold());
    //            });
    //            column.Item().Row(row =>
    //            {
    //                row.RelativeItem().PaddingTop(10).PaddingLeft(1).PaddingRight(1).BorderBottom(0.5f).BorderColor("#A2A2A2");
    //            });
    //        });
    //        //container.Row(row =>
    //        //{
    //        //    row.RelativeItem().Element(LogoBody);
    //        //    row.RelativeItem().AlignLeft()
    //        //            .Text($"Dirección Nacional de Farmacia y Drogas")
    //        //            .FontColor("#383838")
    //        //            .FontSize(14)
    //        //            .Style(TextStyle.Default.Bold());
    //        //    row.RelativeItem().PaddingTop(10).PaddingLeft(1).PaddingRight(1).BorderBottom(0.5f).BorderColor("#A2A2A2");
    //        //});
    //        //container.Grid(grid =>
    //        //{
    //        //    grid.Item(12).Row(row => row.RelativeItem().Element(LogoBody));
    //        //    grid.Item(12).Row(row =>
    //        //    {
    //        //        row.RelativeItem()
    //        //            .AlignLeft()
    //        //            .Text($"Dirección Nacional de Farmacia y Drogas")
    //        //            .FontColor("#383838")
    //        //            .FontSize(14)
    //        //            .Style(TextStyle.Default.Bold());
    //        //    });
    //        //    grid.Item(12).Row(row =>
    //        //    {
    //        //        row.RelativeItem().PaddingTop(10).PaddingLeft(1).PaddingRight(1).BorderBottom(0.5f).BorderColor("#A2A2A2");
    //        //    });
    //        //});
    //    }
    //    void RowBody1(IContainer container)
    //    {
    //        container.ShowEntire().Column(column =>
    //        {
    //            column.Item().Row(row =>
    //            {
    //                row.RelativeItem().Column(column =>
    //                {
    //                    column.Spacing(2);
    //                    column.Item().Text(text =>
    //                   {
    //                     text.Span(Model.Nota?.GetNoteCode(Model.Id)).SemiBold().FontColor("#383838");
    //                   });

    //                   column.Item().PaddingBottom(10).Text(text =>
    //                   {
    //                       text.Span($"Panamá, {Model.Nota?.FechaEvaluacion!.Value.ToLongDateString()}").SemiBold().FontColor("#383838").FontSize(11);
    //                   });
    //                    if (Model.Tramitante != null)
    //                    {
    //                        column.Spacing(2);
    //                        if (!string.IsNullOrEmpty(Model.Tramitante.Nombre))
    //                        {
    //                            column.Item().Text(text =>
    //                            {
    //                                //text.Span("Tramitante: ").SemiBold();
    //                                text.Span(Model.Tramitante.Nombre).SemiBold().FontColor("#383838");
    //                            });
    //                        }
    //                        if (!string.IsNullOrEmpty(Model.AgenciaDistribuidora))
    //                        {
    //                            column.Item().Text(text =>
    //                            {
    //                                //text.Span("Agencia distribuidora: ").SemiBold();
    //                                text.Span(Model.AgenciaDistribuidora).SemiBold().FontColor("#383838");
    //                            });
    //                        }

    //                    }
    //                });
    //            });
    //        });
    //    }
    //    void AuthorizedIntroRowBody(IContainer container)
    //    {
    //        //column.Item().Text(text).DirectionFromLeftToRight();
    //        container.ShowEntire().Row(row =>
    //        {
    //            row.Spacing(2);
    //            row.RelativeItem(4).Text(text =>
    //            {
    //                text.Span($"En referencia al Protocolo de Investigación del estudio clínico {Model?.Codigo}  " +
    //                          $"titulado \"{Model?.Titulo}\" cuyo investigador principal es: {Model?.InvestigadorPrincipal},  " +
    //                          $"a realizarse en {Model?.CentroInvestigacion},  le informamos que autorizamos la introducción al país " +
    //                          $"de los siguientes productos, exclusivamente para el fin indicado.")
    //                         .DirectionFromLeftToRight();
    //            });
    //        });
    //    }

    //    void NotAuthorizedIntroRowBody(IContainer container)
    //    {
    //        var item = Model.Medicamentos.FirstOrDefault();
    //        string facture = item != null ? item.Factura : "--";
    //        container.ShowEntire().Row(row =>
    //        {
    //            row.Spacing(2);
    //            row.RelativeItem(4).Text(text =>
    //            {
    //                text.Span($"En referencia al Protocolo de Investigación del estudio clínico {Model?.Codigo}  " +
    //                          $"titulado \"{Model?.Titulo}\" cuyo investigador principal es: {Model?.InvestigadorPrincipal},  " +
    //                          $"a realizarse en {Model?.CentroInvestigacion}, correspondiente a la Factura: {facture},  " +
    //                          $"le informamos los siguientes aspectos:");
    //            });
    //        });
    //    }
    //    void RowBody3(IContainer container)
    //    {

    //        container.ShowEntire().Row(row => {
    //            row.Spacing(2);
    //            row.RelativeItem(4).Text(text =>
    //            {
    //                text.Span(Model.Nota?.Observaciones);
    //            });
    //        });
    //    }
    //    void RowTable(IContainer container)
    //    {
    //        container.Table(table =>
    //        {

    //            table.ColumnsDefinition(columns =>
    //            {
    //                columns.RelativeColumn(12);
    //                columns.RelativeColumn(12);
    //                columns.RelativeColumn(15);
    //                columns.RelativeColumn(20);
    //                columns.RelativeColumn(20);
    //                columns.RelativeColumn(12);
    //                columns.RelativeColumn(9);
    //            });
    //            table.Header(header =>
    //            {

    //                header.Cell().Element(CellStyle).Text("Factura N°");
    //                header.Cell().Element(CellStyle).Text("Cantidad");
    //                header.Cell().Element(CellStyle).Text("Producto");
    //                header.Cell().Element(CellStyle).PaddingBottom(10).Text("Fabricante / Acondicionador");
    //                header.Cell().Element(CellStyle).Text("Lote");
    //                header.Cell().Element(CellStyle).Text("Fecha de vencimiento");
    //                header.Cell().Element(CellStyle).Text("País de origen");
    //                static IContainer CellStyle(IContainer container)
    //                {
    //                    return container.DefaultTextStyle(x => x.FontSize(10).SemiBold()).PaddingVertical(10).BorderBottom(0.5f).BorderColor("#A2A2A2");
    //                }
    //            });
    //            foreach (var item in Model.Medicamentos)
    //            {
    //                table.Cell().Element(CellStyle).ShowOnce().Text(item.Factura);
    //                table.Cell().Element(CellStyle).ShowOnce().Text(item.Cantidad);
    //                table.Cell().BorderBottom(0.5f).BorderColor("#A2A2A2").Padding(10).Element(hdl =>
    //                {
    //                    hdl.ShowEntire().Column(column =>
    //                    {
    //                        column.Item().ShowOnce().Text(text =>
    //                        {
    //                            text.Span(item.Nombre);
    //                        });
    //                        column.Item().ShowOnce().Text(text =>
    //                        {
    //                            text.Span(item.PrincipioActivo);
    //                        });
    //                        column.Item().ShowOnce().Text(text =>
    //                        {
    //                            text.Span(item.FormaFarmaceutica);
    //                        });
    //                        column.Item().ShowOnce().Text(text =>
    //                        {
    //                            text.Span(item.ViaAdministracion);
    //                        });
    //                        column.Item().ShowOnce().Text(text =>
    //                        {
    //                            text.Span(item.Presentacion);
    //                        });
    //                    });
    //                });
    //                table.Cell().BorderBottom(0.5f).BorderColor("#A2A2A2").Padding(10).Element(hdl =>
    //                {
    //                    hdl.ShowEntire().Column(column =>
    //                    {
    //                        if (!string.IsNullOrEmpty(item.Fabricante?.Nombre))
    //                        {
    //                            column.Item().ShowOnce().Text(text =>
    //                            {
    //                                text.Span(item.Fabricante?.Nombre);
    //                            });
    //                        }
    //                        if (!string.IsNullOrEmpty(item.Fabricante?.Direccion))
    //                        {
    //                            if (!string.IsNullOrEmpty(item.Fabricante?.Pais))
    //                            {
    //                                column.Item().ShowOnce().BorderBottom(0.5f).BorderColor("#A2A2A2").PaddingBottom(5).Text(text =>
    //                                {
    //                                    text.Span($"{item.Fabricante?.Direccion} / {item.Fabricante?.Pais}");
    //                                });
    //                            }
    //                            else
    //                            {
    //                                column.Item().ShowOnce().BorderBottom(0.5f).BorderColor("#A2A2A2").PaddingBottom(5).Text(text =>
    //                                {
    //                                    text.Span($"{item.Fabricante?.Direccion}");
    //                                });
    //                            }

    //                        }
    //                        if (!string.IsNullOrEmpty(item.Acondicionador?.Nombre))
    //                        {
    //                            column.Item().ShowOnce().Text(text =>
    //                            {
    //                                text.Span(item.Acondicionador?.Nombre);
    //                            });
    //                        }
    //                        if (!string.IsNullOrEmpty(item.Acondicionador?.Direccion))
    //                        {
    //                            if (!string.IsNullOrEmpty(item.Acondicionador?.Pais))
    //                            {
    //                                column.Item().ShowOnce().BorderBottom(0.5f).BorderColor("#A2A2A2").PaddingBottom(5).Text(text =>
    //                                {
    //                                    text.Span($"{item.Acondicionador?.Direccion} / {item.Acondicionador?.Pais}");
    //                                });
    //                            }
    //                            else
    //                            {
    //                                column.Item().BorderBottom(0.5f).BorderColor("#A2A2A2").PaddingBottom(5).Text(text =>
    //                                {
    //                                    text.Span($"{item.Acondicionador?.Direccion}");
    //                                });
    //                            }

    //                        }
    //                    });
    //                });
    //                table.Cell().Element(CellStyle).ShowOnce().Text(item.Lote);
    //                table.Cell().Element(CellStyle).ShowOnce().Text($"{item.Expiracion:d}");
    //                table.Cell().Element(CellStyle).ShowOnce().Text(item.Fabricante?.Pais);
    //                static IContainer CellStyle(IContainer container)
    //                {
    //                    return container.BorderBottom(0.5f).BorderColor("#A2A2A2").Padding(10);
    //                }
    //            }
    //        });
    //    }

    //    void RowBody4(IContainer container)
    //    {
    //        container.ShowEntire().Row(row =>
    //        {
    //            row.RelativeItem().Column(column =>
    //            {
    //                column.Spacing(2);

    //                column.Item().Text(text =>
    //                {
    //                    text.Span("Atentamente,");
    //                });
    //                column.Item().PaddingTop(15).Text(text =>
    //                {
    //                    text.Span("_____________________________________________________________");
    //                });
    //                column.Item().Text(text =>
    //                {
    //                    text.Span("Director(a) Nacional de Farmacia y Drogas ").SemiBold();
    //                });
    //                //column.Item().Text(text =>
    //                //{
    //                //    text.Span("Ciudad de Panamá");
    //                //});
    //                if (!string.IsNullOrEmpty(Model.EvaluatorToShow))
    //                {
    //                    column.Item().Text(text =>
    //                    {
    //                        text.Span(Model.EvaluatorToShow).FontSize(10);
    //                    });
    //                }

    //            });
    //        });
    //    }
    //    void ContentBody1(IContainer container)
    //    {
    //        container.Grid(grid =>
    //        {
    //            grid.Item(12).PaddingTop(20).Row(row =>
    //            {
    //                row.RelativeItem().Element(RowBody1);
    //            });
    //            if (Model.Estado == EstadoEstudio.Authorized)
    //            {
    //                grid.Item(12).PaddingTop(20).Row(row =>
    //                {
    //                    row.RelativeItem().Element(AuthorizedIntroRowBody);
    //                });
    //            }
    //            else
    //            {
    //                grid.Item(12).PaddingTop(20).Row(row =>
    //                {
    //                    row.RelativeItem().Element(NotAuthorizedIntroRowBody);
    //                });
    //            }
    //            grid.Item(12).ShowIf(Model.Estado == EstadoEstudio.Authorized).PaddingTop(20).Row(row =>
    //            {
    //                row.RelativeItem().Element(RowTable);
    //            });
    //            if (!string.IsNullOrEmpty(Model.Nota?.Observaciones))
    //            {
    //                grid.Item(12).PaddingTop(20).Row(row =>
    //                {
    //                    row.RelativeItem().Element(RowBody3);
    //                });
    //            }
    //            grid.Item(12)
    //                .ExtendVertical()
    //                .AlignBottom()
    //                .ExtendHorizontal()
    //                .Height(100).Row(row => { row.RelativeItem().Element(RowBody4); });
    //        });
    //    }
    //    void ContentBody2(IContainer container)
    //    {
    //        container.Grid(grid =>
    //        {
    //            if (!string.IsNullOrEmpty(Model.Nota?.Observaciones))
    //            {
    //                grid.Item(12).PaddingTop(20).Row(row =>
    //                {
    //                    row.RelativeItem().Element(RowBody3);
    //                });
    //            }
    //            grid.Item(12)
    //                .ExtendVertical()
    //                .AlignBottom()
    //                .ExtendHorizontal()
    //                .Height(100).Row(row => { row.RelativeItem().Element(RowBody4); });
    //        });
    //    }
    //}
}
