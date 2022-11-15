using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAreaAdministrativa : SystemId
    {
        // ÁREA ADMINISTRATIVA
        // ¿Dispone de área administrativa?
        private enumAUD_TipoSeleccion areaAdminDispone;
        public enumAUD_TipoSeleccion AreaAdminDispone { get => areaAdminDispone; set => SetProperty(ref areaAdminDispone, value); }
        // Observación
        private string areaAdminDisponeDesc;
        [StringLength(500)]
        public string AreaAdminDisponeDesc { get => areaAdminDisponeDesc; set => SetProperty(ref areaAdminDisponeDesc, value); }

        // Identificada
        private enumAUD_TipoSeleccion areaAdminIdentificada;
        public enumAUD_TipoSeleccion AreaAdminIdentificada { get => areaAdminIdentificada; set => SetProperty(ref areaAdminIdentificada, value); }

        // Observación
        private string areaAdminIdentificadaDesc;
        [StringLength(500)]
        public string AreaAdminIdentificadaDesc { get => areaAdminIdentificadaDesc; set => SetProperty(ref areaAdminIdentificadaDesc, value); }

        // Dirección de área administrativa
        private enumAUD_TipoSeleccion areaAdminDir;
        public enumAUD_TipoSeleccion AreaAdminDir { get => areaAdminDir; set => SetProperty(ref areaAdminDir, value); }

        // Observación
        private string areaAdminDirDesc;
        [StringLength(500)]
        public string AreaAdminDirDesc { get => areaAdminDirDesc; set => SetProperty(ref areaAdminDirDesc, value); }

        // Dispone de servicios sanitarios y lavamanos
        private enumAUD_TipoSeleccion areaAdminDisponeServSanitario;
        public enumAUD_TipoSeleccion AreaAdminDisponeServSanitario { get => areaAdminDisponeServSanitario; set => SetProperty(ref areaAdminDisponeServSanitario, value); }

        // Observación
        private string areaAdminDisponeServSanitarioDesc;
        [StringLength(500)]
        public string AreaAdminDisponeServSanitarioDesc { get => areaAdminDisponeServSanitarioDesc; set => SetProperty(ref areaAdminDisponeServSanitarioDesc, value); }


    }
}
