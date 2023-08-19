using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Integration.SirFad;
using Aig.Farmacoterapia.Domain.Integration.SysFarm;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.SirFad
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Acondicionador
    {
        [JsonPropertyName("Version")]
        public int Version { get; set; }

        [JsonPropertyName("AconAntiguoTipo")]
        public string AconAntiguoTipo { get; set; }

        [JsonPropertyName("AconAntiguoTipoDetalle")]
        public string AconAntiguoTipoDetalle { get; set; }

        [JsonPropertyName("AconAntiguo")]
        public string AconAntiguo { get; set; }

        [JsonPropertyName("AconAntiguoPais")]
        public string AconAntiguoPais { get; set; }

        [JsonPropertyName("AconNuevoTipo")]
        public int AconNuevoTipo { get; set; }

        [JsonPropertyName("AconNuevoTipoDetalle")]
        public string AconNuevoTipoDetalle { get; set; }

        [JsonPropertyName("AconNuevoPrimario")]
        public string AconNuevoPrimario { get; set; }

        [JsonPropertyName("AconNuevoPrimarioPais")]
        public string AconNuevoPrimarioPais { get; set; }

        [JsonPropertyName("AconNuevoSecundario")]
        public string AconNuevoSecundario { get; set; }

        [JsonPropertyName("AconNuevoSecundarioPais")]
        public string AconNuevoSecundarioPais { get; set; }
    }

    public class Distribuidore
    {
        [JsonPropertyName("CodigoSolucion")]
        public int CodigoSolucion { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("Licencia")]
        public string Licencia { get; set; }

        [JsonPropertyName("Correo")]
        public string Correo { get; set; }
    }

    public class Fabricante
    {
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("Direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("Correo")]
        public string Correo { get; set; }

        [JsonPropertyName("Pais")]
        public string Pais { get; set; }

        [JsonPropertyName("PaisISO2")]
        public string PaisISO2 { get; set; }

        [JsonPropertyName("PaisISO3")]
        public string PaisISO3 { get; set; }
    }

    public class Presentacione
    {
        [JsonPropertyName("CodigoSolucion")]
        public int CodigoSolucion { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Tipo")]
        public string Tipo { get; set; }

        [JsonPropertyName("Presentacion")]
        public string Presentacion { get; set; }
    }

    public class Producto
    {
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("DescripcionEnvase")]
        public string DescripcionEnvase { get; set; }

        [JsonPropertyName("ClasificacionMedica")]
        public string ClasificacionMedica { get; set; }

        [JsonPropertyName("CondicionVenta")]
        public string CondicionVenta { get; set; }

        [JsonPropertyName("PrincipioActivo")]
        public string PrincipioActivo { get; set; }

        [JsonPropertyName("ViaAdministracion")]
        public string ViaAdministracion { get; set; }

        [JsonPropertyName("FormaFarmaceutica")]
        public string FormaFarmaceutica { get; set; }

        [JsonPropertyName("VidaUtil")]
        public string VidaUtil { get; set; }
    }

    public class Registro
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("NumeroRegistro")]
        public string NumeroRegistro { get; set; }

        [JsonPropertyName("NumeroRegistroCompleto")]
        public string NumeroRegistroCompleto { get; set; }

        [JsonPropertyName("Libro")]
        public string Libro { get; set; }

        [JsonPropertyName("Folio")]
        public string Folio { get; set; }

        [JsonPropertyName("TitularNombre")]
        public string TitularNombre { get; set; }

        [JsonPropertyName("TitularPais")]
        public string TitularPais { get; set; }

        [JsonPropertyName("Producto")]
        public Producto Producto { get; set; }

        [JsonPropertyName("Fabricante")]
        public Fabricante Fabricante { get; set; }

        [JsonPropertyName("Acondicionador")]
        public Acondicionador Acondicionador { get; set; }

        [JsonPropertyName("Presentaciones")]
        public List<Presentacione> Presentaciones { get; set; }

        [JsonPropertyName("Distribuidores")]
        public List<Distribuidore> Distribuidores { get; set; }

        [JsonPropertyName("FechaExpedicion")]
        public string FechaExpedicion { get; set; }

        [JsonPropertyName("FechaVencimiento")]
        public string FechaVencimiento { get; set; }

        [JsonPropertyName("FechaUltimaActualizacion")]
        public string FechaUltimaActualizacion { get; set; }

        [JsonPropertyName("Estado")]
        public string Estado { get; set; }

        [JsonPropertyName("EstadoDetalles")]
        public string EstadoDetalles { get; set; }
    }

    public class Root
    {
        //[JsonPropertyName("status")]
        //public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("registros")]
        public List<Registro> Registros { get; set; }
    }

    public class SirFadServices : BaseRestService, ISirFadServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _code = "SIRFAD";
        public SirFadServices(IRestApiClient requester, IUnitOfWork unitOfWork, IMapper mapper, ISystemLogger logger):base(requester, logger)
        {    
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            AigService? item;
            if((item= _unitOfWork.Repository<AigService>().Entities.FirstOrDefault(p => p.Code == _code)) != null) {
                _config = new SirFadConfiguration(){
                    Host = item.Host,
                    Port = item.Port,
                    Token = item.Token,
                    User = item.User,
                    Password = item.Password,
                    Https = item.Https,
                };
            }           
        }
        public async Task GetRecords(CancellationToken cancellationToke = default)
        {
            try
            {
                //    //try
                //    //{
                //    //    var jsonString = "{\"status\":{\"status\":true,\"message\":\"Registroscargadosexitosamente.\",\"cantidad\":1152,\"registros\":[{\"Id\":2,\"NumeroRegistro\":\"200832\",\"NumeroRegistroCompleto\":\"---200832---\",\"Libro\":\"CC\",\"Folio\":\"1\",\"TitularNombre\":\"AlimentosHyH,S.A.\",\"TitularPais\":\"Guatemala\",\"Producto\":{\"Nombre\":\"VIUCOLÁGENO+TÉVERDE\",\"DescripcionEnvase\":\"Envasedehojalata,contapaquecierraapresión.recubiertointernamenteconepóxicomodificadogradoalimenticioysobresPlásticoflexiblerecubiertodepoliésterconpropiedadesantimicrobiana.\",\"ClasificacionMedica\":\"SuplementosAlimenticios\",\"CondicionVenta\":\"PrescripciónMédica\",\"PrincipioActivo\":\"ColágenoHidrolizado\",\"ViaAdministracion\":\"ORAL\",\"FormaFarmaceutica\":\"POLVOPARASOLUCIONORALENSOBRE\",\"VidaUtil\":\"24meses\"},\"Fabricante\":{\"Nombre\":\"AlimentosHyH,S.A.\",\"Direccion\":\"Kilometro6,5CarreteraalAtlántico,Zona18,Guatemala,Guatemala\",\"Correo\":\"calidad@alimentoshyh.com\",\"Pais\":\"Guatemala\",\"PaisISO2\":\"GT\",\"PaisISO3\":\"\"},\"Acondicionador\":{\"Version\":1,\"AconAntiguoTipo\":\"SE\",\"AconAntiguoTipoDetalle\":\"Primario/Secundario\",\"AconAntiguo\":\"AlimentosHyH,S.A.\",\"AconAntiguoPais\":\"Guatemala\",\"AconNuevoTipo\":-1,\"AconNuevoTipoDetalle\":\"\",\"AconNuevoPrimario\":\"\",\"AconNuevoPrimarioPais\":\"\",\"AconNuevoSecundario\":\"\",\"AconNuevoSecundarioPais\":\"\"},\"Presentaciones\":[{\"CodigoSolucion\":2,\"Id\":4124,\"Tipo\":\"Comercial\",\"Presentacion\":\"Envasecon300g\"},{\"CodigoSolucion\":2,\"Id\":4975,\"Tipo\":\"MuestraMédica\",\"Presentacion\":\"Carpetillaysachetcon2g\"}],\"Distribuidores\":[{\"CodigoSolucion\":2,\"Nombre\":\"DROGUERÍASARO,S.A.\",\"Licencia\":\"8-020A/DNFD\",\"Correo\":\"--\"}],\"FechaExpedicion\":\"2023-04-24\",\"FechaVencimiento\":\"2028-04-24\",\"FechaUltimaActualizacion\":\"2023-04-26\",\"Estado\":\"SF\",\"EstadoDetalles\":\"SOLICITUDFINALIZADA\"}]},\"message\":\"Registroscargadosexitosamente.\",\"cantidad\":1152,\"registros\":[{\"Id\":2,\"NumeroRegistro\":\"200832\",\"NumeroRegistroCompleto\":\"---200832---\",\"Libro\":\"CC\",\"Folio\":\"1\",\"TitularNombre\":\"AlimentosHyH,S.A.\",\"TitularPais\":\"Guatemala\",\"Producto\":{\"Nombre\":\"VIUCOLÁGENO+TÉVERDE\",\"DescripcionEnvase\":\"Envasedehojalata,contapaquecierraapresión.recubiertointernamenteconepóxicomodificadogradoalimenticioysobresPlásticoflexiblerecubiertodepoliésterconpropiedadesantimicrobiana.\",\"ClasificacionMedica\":\"SuplementosAlimenticios\",\"CondicionVenta\":\"PrescripciónMédica\",\"PrincipioActivo\":\"ColágenoHidrolizado\",\"ViaAdministracion\":\"ORAL\",\"FormaFarmaceutica\":\"POLVOPARASOLUCIONORALENSOBRE\",\"VidaUtil\":\"24meses\"},\"Fabricante\":{\"Nombre\":\"AlimentosHyH,S.A.\",\"Direccion\":\"Kilometro6,5CarreteraalAtlántico,Zona18,Guatemala,Guatemala\",\"Correo\":\"calidad@alimentoshyh.com\",\"Pais\":\"Guatemala\",\"PaisISO2\":\"GT\",\"PaisISO3\":\"\"},\"Acondicionador\":{\"Version\":1,\"AconAntiguoTipo\":\"SE\",\"AconAntiguoTipoDetalle\":\"Primario/Secundario\",\"AconAntiguo\":\"AlimentosHyH,S.A.\",\"AconAntiguoPais\":\"Guatemala\",\"AconNuevoTipo\":-1,\"AconNuevoTipoDetalle\":\"\",\"AconNuevoPrimario\":\"\",\"AconNuevoPrimarioPais\":\"\",\"AconNuevoSecundario\":\"\",\"AconNuevoSecundarioPais\":\"\"},\"Presentaciones\":[{\"CodigoSolucion\":2,\"Id\":4124,\"Tipo\":\"Comercial\",\"Presentacion\":\"Envasecon300g\"},{\"CodigoSolucion\":2,\"Id\":4975,\"Tipo\":\"MuestraMédica\",\"Presentacion\":\"Carpetillaysachetcon2g\"}],\"Distribuidores\":[{\"CodigoSolucion\":2,\"Nombre\":\"DROGUERÍASARO,S.A.\",\"Licencia\":\"8-020A/DNFD\",\"Correo\":\"--\"}],\"FechaExpedicion\":\"2023-04-24\",\"FechaVencimiento\":\"2028-04-24\",\"FechaUltimaActualizacion\":\"2023-04-26\",\"Estado\":\"SF\",\"EstadoDetalles\":\"SOLICITUDFINALIZADA\"}]}";
                //    //    var dta = JsonSerializer.Deserialize<Root>(jsonString);
                //    //    return _mapper.Map<SirFadResponse>(dta);

                //    //}
                //    //catch (Exception ex)
                //    //{

                //    //    return null;
                //    //}

                SirFadResponse? result = null;
                AigService? service;
                if ((service = _unitOfWork.Repository<AigService>().Entities.FirstOrDefault(p => p.IsActive && p.Code == _code)) != null)
                {
                    if (service.LastRun == null)
                        result = await GetAllRecords(cancellationToke);
                    else {
                        var date = service.LastRun?.ToString("yyyy-MM-dd");
                        var request = CreateRequest("sirfadwebapi/api/dnfdaig/GetRegistrosFarmacovigilancia", Method.GET, new Dictionary<string, string> { { "fechaConsulta", date } });
                        var response = await _requester.ExecuteAsync<Root>(request, cancellationToke);
                        if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content) || response.Data == null)
                            throw new Exception(response.Content);
                        else
                            result = _mapper.Map<SirFadResponse>(response.Data);
                    }
                }
                if (result?.Cantidad > 0)
                {
                    await _unitOfWork.ExecuteInTransactionAsync(async (cc) => {
                        await _unitOfWork.BeginTransactionAsync(cc);
                        AigRecord record;
                        foreach (var item in result.Registros) {
                            item.Servicio = ServiceType.SIRFAD;
                            if ((record = _unitOfWork.Repository<AigRecord>().Entities.AsNoTracking().FirstOrDefault(p => p.Numero == item.Numero)) != null){
                                item.Id = record.Id;
                                item.DataSheetURL = record.DataSheetURL;
                                item.ProspectusURL = record.ProspectusURL;
                                item.PictureData = record.PictureData;
                            }
                            if (item.Distribuidor == null)
                                item.Distribuidor = record?.Distribuidor??new AigDistributor();
                            if (item.Fabricante == null)
                                item.Fabricante = record?.Fabricante ?? new AigMaker();
                            var product = new Tuple<Expression<Func<AigRecord, object>>, object>(p => p.Producto, item.Producto);
                            var maker = new Tuple<Expression<Func<AigRecord, object>>, object>(p => p.Fabricante, item.Fabricante);
                            var distributor = new Tuple<Expression<Func<AigRecord, object>>, object>(p => p.Distribuidor, item.Distribuidor);
                            await _unitOfWork.Repository<AigRecord>().UpdateDeepAsync(item, product, maker, distributor);
                        }
                        // updated last run
                        service.LastRun = DateTime.Now;
                        service.LastRetrieved = result.Cantidad;
                        await _unitOfWork.Repository<AigService>().UpdateDeepAsync(service);
                        var commit = await _unitOfWork.CommitAsync(cc);
                    }, default);
                }
                else if(result?.Cantidad == 0)
                {
                    //updated last run
                    service.LastRun = DateTime.Now;
                    service.LastRetrieved = result.Cantidad;
                    await _unitOfWork.Repository<AigService>().UpdateDeepAsync(service);
                    var commit = await _unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToMessageAndCompleteStacktrace());
            }

        }
        private async Task<SirFadResponse?> GetAllRecords(CancellationToken cancellationToke = default)
        {
            try
            {
                var request = CreateRequest("sirfadwebapi/api/dnfdaig/GetRegistrosFarmacovigilancia", Method.GET);
                var response = await _requester.ExecuteAsync<Root>(request, cancellationToke);
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content) || response.Data == null)
                    throw new Exception(response.Content);
                else
                    return _mapper.Map<SirFadResponse>(response.Data);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToMessageAndCompleteStacktrace());
                return null;
            }
        }

    }
}
