﻿using DataModel;

namespace Aig.Auditoria.Events.DeleteConfirmationDlg
{
    public class DeleteConfirmationOpenEvent
    {
        public string Caption { get; set; } = "Eliminar";
        public string Message { get; set; } = "Está seguro desea eliminar el dato seleccionado?";
    }
}
