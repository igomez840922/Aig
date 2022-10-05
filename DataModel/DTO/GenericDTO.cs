using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DTO
{
    public class GenericDTO<T> where T : class
    {
        public GenericDTO()
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

        public List<T> Ldata { get; set; }

        public int Total { get; set; }
        public int PagesCount
        {
            get
            {
                try
                {
                    return (int)Math.Ceiling(Total / (decimal)PagAmt);
                }
                catch { }
                return 0;
            }
            set { }
        }
        public T Data { get; set; }


    }

}
