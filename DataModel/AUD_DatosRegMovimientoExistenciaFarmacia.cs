using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class AUD_DatosRegMovimientoExistenciaFarmacia : SystemId
    {
        // Se encuentra el Libro Récord en el establecimiento a disposición del inspector
        private enumAUD_TipoSeleccion libroRecordDisposicion;
        public enumAUD_TipoSeleccion LibroRecordDisposicion { get => libroRecordDisposicion; set => SetProperty(ref libroRecordDisposicion, value); }

        // El establecimiento cuenta con Libro Récord numerado y foliado por la DNFD
        private enumAUD_TipoSeleccion libroRecordNumeradoFoliado;
        public enumAUD_TipoSeleccion LibroRecordNumeradoFoliado { get => libroRecordNumeradoFoliado; set => SetProperty(ref libroRecordNumeradoFoliado, value); }

        // Libro Record para el registro de recetas corrientes está al día hasta el
        private DateTime? libroRecordRecetaActualizadoHasta;
        public DateTime? LibroRecordRecetaActualizadoHasta { get => libroRecordRecetaActualizadoHasta; set => SetProperty(ref libroRecordRecetaActualizadoHasta, value); }

        // Esta anota las recetas corriente y Antibióticos dispensadas en este libro
        private enumAUD_TipoSeleccion anotaRecetaCorrienteAntiEnLibro;
        public enumAUD_TipoSeleccion AnotaRecetaCorrienteAntiEnLibro { get => anotaRecetaCorrienteAntiEnLibro; set => SetProperty(ref anotaRecetaCorrienteAntiEnLibro, value); }

        // Todas las recetas se encuentran archivadas en orden cronológico, mensual o trimestral
        private enumAUD_TipoSeleccion recetaarchivadaOrdenCronolog;
        public enumAUD_TipoSeleccion RecetaarchivadaOrdenCronolog { get => recetaarchivadaOrdenCronolog; set => SetProperty(ref recetaarchivadaOrdenCronolog, value); }


    }
}
