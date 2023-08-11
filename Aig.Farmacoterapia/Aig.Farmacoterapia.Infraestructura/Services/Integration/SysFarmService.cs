using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Integration.SysFarm;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient;
using AutoMapper;
using RestSharp;
using System.Text.Json.Serialization;

namespace Aig.Farmacoterapia.Infrastructure.Services.Integration.SysFarm
{
    public class Distribuidor
    {
        [JsonPropertyName("NombreDistribuidorNacional")]
        public string NombreDistribuidorNacional { get; set; }

        [JsonPropertyName("NombreTitular")]
        public string NombreTitular { get; set; }

        [JsonPropertyName("NombreAcondicionadorPrimario")]
        public string NombreAcondicionadorPrimario { get; set; }

        [JsonPropertyName("NombreAcondicionadorSecundario")]
        public string NombreAcondicionadorSecundario { get; set; }
    }

    public class Excipiente
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("Concentracion")]
        public string Concentracion { get; set; }
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
        [JsonPropertyName("IdTipoTabla")]
        public int IdTipoTabla { get; set; }

        [JsonPropertyName("TipoTabla")]
        public object TipoTabla { get; set; }

        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("IdEvaluacion")]
        public int IdEvaluacion { get; set; }

        [JsonPropertyName("IdProducto")]
        public int IdProducto { get; set; }

        [JsonPropertyName("Numero")]
        public string Numero { get; set; }

        [JsonPropertyName("RenovacionNumero")]
        public int RenovacionNumero { get; set; }

        [JsonPropertyName("RenovacionTexto")]
        public string RenovacionTexto { get; set; }

        [JsonPropertyName("Libro")]
        public string Libro { get; set; }

        [JsonPropertyName("Folio")]
        public string Folio { get; set; }

        [JsonPropertyName("Producto")]
        public Producto Producto { get; set; }

        [JsonPropertyName("Fabricante")]
        public Fabricante Fabricante { get; set; }

        [JsonPropertyName("Distribuidor")]
        public Distribuidor Distribuidor { get; set; }

        [JsonPropertyName("Presentaciones")]
        public List<Presentacione> Presentaciones { get; set; }

        [JsonPropertyName("Excipientes")]
        public List<Excipiente> Excipientes { get; set; }

        [JsonPropertyName("FechaExpedicion")]
        public string FechaExpedicion { get; set; }

        [JsonPropertyName("FechaVencimiento")]
        public string FechaVencimiento { get; set; }

        [JsonPropertyName("FechaUltimaActualizacion")]
        public string FechaUltimaActualizacion { get; set; }

        [JsonPropertyName("IdEstado")]
        public int IdEstado { get; set; }

        [JsonPropertyName("Estado")]
        public string Estado { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }

        [JsonPropertyName("registros")]
        public List<Registro> Registros { get; set; }
    }

    public class SysFarmService : BaseRestService, ISysFarmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string _code = "SYSFARM";
        public SysFarmService(IRestApiClient requester, IUnitOfWork unitOfWork, IMapper mapper, ISystemLogger logger):base(requester, logger)
        {    
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            AigService? item;
            if((item= _unitOfWork.Repository<AigService>().Entities.FirstOrDefault(p => p.Code == _code)) != null) {
                _config = new SysFarmConfiguration(){
                    Host = item.Host,
                    Port = item.Port,
                    Token = item.Token,
                    User = item.User,
                    Password = item.Password,
                    Https = item.Https,
                };
            }           
        }
        public async Task<SysFarmResponse?> GetRecords(CancellationToken cancellationToke = default)
        {
            AigService? item;
            if ((item = _unitOfWork.Repository<AigService>().Entities.FirstOrDefault(p => p.Code == _code)) != null) {
                if (item.LastRun == null) return await GetAllRecords(cancellationToke);
                var date = item.LastRun?.ToString("yyyy-MM-dd");
                var request = CreateRequest("api/registros", Method.GET, new Dictionary<string, string> { { "fechaConsulta", date } });
                var response = await _requester.ExecuteAsync<Root>(request, cancellationToke);
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content) || response.Data == null){
                    _logger.Error(new Exception(response.Content).ToMessageAndCompleteStacktrace());
                    return null;
                }
                else
                {
                    item.LastRun = DateTime.Now;
                    item.LastRetrieved = response.Data.Cantidad;
                    await _unitOfWork.Repository<AigService>().UpdateAsync(item);
                    await _unitOfWork.CommitAsync(cancellationToke);
                    return _mapper.Map<SysFarmResponse>(response.Data);
                }
            }
            return null;
        }
        private async Task<SysFarmResponse?> GetAllRecords(CancellationToken cancellationToke = default)
        {
            try
            {
                var request = CreateRequest("api/registros", Method.GET);
                var response = await _requester.ExecuteAsync<Root>(request, cancellationToke);
                if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content) || response.Data == null){
                    _logger.Error(new Exception(response.Content).ToMessageAndCompleteStacktrace());
                    return null;
                }
                else {
                    AigService? item;
                    if ((item = _unitOfWork.Repository<AigService>().Entities.FirstOrDefault(p => p.Code == _code)) != null) {
                        item.LastRun = DateTime.Now;
                        item.LastRetrieved = response.Data.Cantidad;
                        await _unitOfWork.Repository<AigService>().UpdateAsync(item);
                        await _unitOfWork.CommitAsync(cancellationToke);
                    }
                    return _mapper.Map<SysFarmResponse>(response.Data);
                }
            }
            catch (Exception ex) {
                _logger.Error(ex.ToMessageAndCompleteStacktrace());
                return null;
            }
        }
    }
}
