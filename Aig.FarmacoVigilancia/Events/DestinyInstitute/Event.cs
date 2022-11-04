using DataModel;

namespace Aig.FarmacoVigilancia.Events.DestinyInstitute
{       
    public class DestinyInstituteAddEdit_CloseEvent
    {
        public InstitucionDestinoTB Data { get; set; }
    }

    public class DestinyInstituteAddEdit_OpenEvent
    {
        public InstitucionDestinoTB Data { get; set; }
    }
}
