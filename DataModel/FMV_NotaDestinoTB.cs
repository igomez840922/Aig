using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_NotaDestinoTB:SystemId
    {
        public FMV_NotaDestinoTB()
        {
            NotaClasificacion = new FMV_NotaClasificacion();
            NotaContactos = new FMV_NotaContactos();    
        }

        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        private string descripcion;
        [StringLength(500)]
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string NotasAsociadas { 
            get {
                string desc = null;
                if(NotaClasificacion?.LClasificaciones?.Count > 0)
                {
                    foreach(var nt in NotaClasificacion.LClasificaciones)
                    {
                        desc += nt.Nombre + " - ";
                    }

                    desc.Remove(desc.LastIndexOf('-'));
                }
                return desc;
            }
            set { }
        }


        //Tipos de Notas
        private FMV_NotaClasificacion notaClasificacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual FMV_NotaClasificacion NotaClasificacion { get => notaClasificacion; set => SetProperty(ref notaClasificacion, value); }
        
        //loa contactos de correos
        private FMV_NotaContactos notaContactos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual FMV_NotaContactos NotaContactos { get => notaContactos; set => SetProperty(ref notaContactos, value); }

    }
}
