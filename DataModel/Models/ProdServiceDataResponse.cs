using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class ProdServiceDataRequest
    {
        public string term { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    public class ProdServiceDataResponse
    {
        public List<string> messages { get; set; }
        public bool succeeded { get; set; }
        public List<ProdServiceData> data { get; set; }
        public int currentPage { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public bool hasPreviousPage { get; set; }
        public bool hasNextPage { get; set; }
    }

    public class ProdServiceData
    {
        public int id { get; set; }
        public DateTime? created { get; set; }
        public string createdBy { get; set; }
        public DateTime? lastModified { get; set; }
        public string lastModifiedBy { get; set; }
        public string numReg { get; set; }
        public string numRen { get; set; }
        public string nombre { get; set; }
        public string presentacion { get; set; }
        public bool vigente { get; set; }
        public string envase { get; set; }
        public string tipoEquivalencia { get; set; }
        public string tipoMedicamento { get; set; }
        public string condicionVenta { get; set; }
        public string principio { get; set; }
        public string excipientes { get; set; }
        public string concentracion { get; set; }
        public FormaFarmaceutica formaFarmaceutica { get; set; }
        public ViaAdministracion viaAdministracion { get; set; }
        public Fabricante fabricante { get; set; }
        public bool showDetails { get; set; }
        public string dataSheetURL { get; set; }
        public string prospectusURL { get; set; }
        public string pictureData { get; set; }
    }

    public class Fabricante
    {
        public int id { get; set; }
        public DateTime? created { get; set; }
        public string createdBy { get; set; }
        public DateTime? lastModified { get; set; }
        public string lastModifiedBy { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
        public Pais pais { get; set; }
    }

    public class FormaFarmaceutica
    {
        public int id { get; set; }
        public DateTime? created { get; set; }
        public string createdBy { get; set; }
        public DateTime? lastModified { get; set; }
        public string lastModifiedBy { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }

    public class Pais
    {
        public int id { get; set; }
        public DateTime? created { get; set; }
        public string createdBy { get; set; }
        public DateTime? lastModified { get; set; }
        public string lastModifiedBy { get; set; }
        public string iso { get; set; }
        public string nombre { get; set; }
    }        

    public class ViaAdministracion
    {
        public int id { get; set; }
        public DateTime? created { get; set; }
        public string createdBy { get; set; }
        public DateTime? lastModified { get; set; }
        public string lastModifiedBy { get; set; }
        public string nombre { get; set; }
        public string estado { get; set; }
    }
}
