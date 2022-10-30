using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class GenericModel<T> where T : class
    {
        public GenericModel()
        {
            Ldata = null;
            Total = 0;
            PagAmt = 20;
            PagIdx = 0;
            Filter = "";
        }

        public int PagAmt { get; set; }
        public int PagIdx { get; set; }
        public string Filter { get; set; }
        public string ErrorMsg { get; set; }  

        public long ParentId { get; set; }
        public long Parent2Id { get; set; }
        public long Parent3Id { get; set; }

        public List<T> Ldata { get; set; }

        public int Total { get; set; }
        private int pagesCount=0;
		public int PagesCount
        {
            get
            {
                try
                {
					pagesCount = ((int)Math.Ceiling((decimal)Total / (decimal)PagAmt));
                }
                catch { }
                return pagesCount > 1? pagesCount:1;
            }
            set { }
        }
        public T Data { get; set; }

        public enumAUD_TipoActa TipoActa { get; set; } = enumAUD_TipoActa.None;
        public enum_StatusInspecciones StatusInspecciones { get; set; } = enum_StatusInspecciones.None;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }
        public enumFMV_IpsStatusRevision? IpsStatusRevision { get; set; } = null;
        public long? EvaluatorId { get; set; } = null;
        public long? RegisterId { get; set; } = null;

    }

}
