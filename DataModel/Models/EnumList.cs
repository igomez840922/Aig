using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class EnumDataType
    {
        public System.Enum mEnum { get; set; }
        public string Name
        {
            get 
            {
                return DataModel.Helper.Helper.GetDescription(mEnum);
            }
            set { }
        }
    }
}
