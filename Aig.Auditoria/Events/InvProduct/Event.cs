using Aig.Auditoria.Components.InvProduct;
using DataModel;

namespace Aig.Auditoria.Events.InvProduct
{       
    public class CloseEvent
    {
        public AUD_InvProducto Data { get; set; }
    }

    public class OpenEvent
    {
        public AUD_InvProducto Data { get; set; }
    }
}
