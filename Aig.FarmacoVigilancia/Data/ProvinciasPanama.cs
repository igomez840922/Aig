namespace Aig.FarmacoVigilancia.Data
{    
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Distrito
    {
        public string nombre { get; set; }
        public string cabecera { get; set; }
        public List<string> corregimientos { get; set; }
    }

    public class Provincium
    {
        public string nombre { get; set; }
        public string ced { get; set; }
        public string iso_3166_2 { get; set; }
        public string capital { get; set; }
        public List<Distrito> distrito { get; set; }
    }

    public class MainProvincias
    {
        public List<Provincium> provincia { get; set; }
    }

    public class ProvinciaTipoOrga
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idTipoOrg { get; set; }
    }

    public class OrganizacionProvinciaTipoOrga
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idProvinciaTipoOrga { get; set; }
    }
}
