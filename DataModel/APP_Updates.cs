using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Updates : SystemId
	{
        public DateTime? InspectionsUpdate { get; set; }
        public DateTime? SettingsUpdate { get; set; }        

    }
}
