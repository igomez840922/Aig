﻿using DataModel;

namespace Aig.Auditoria2.Events.ColaboratorFile
{       
    public class ColaboratorFileAddEdit_CloseEvent
    {
        public ExpedienteColaborador Data { get; set; }
    }

    public class ColaboratorFileAddEdit_OpenEvent
    {
        public ExpedienteColaborador Data { get; set; }
    }
}