using DataModel;

namespace Aig.Auditoria2.Events.DeleteConfirmationDlg
{
    public class DeleteConfirmationOpenEvent
    {
        public string Caption { get; set; } = "Confirmar Desición";
        public string Message { get; set; } = "Está seguro desea eliminar el dato seleccionado?";
    }
}
