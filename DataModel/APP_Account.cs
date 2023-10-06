using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Account : SystemId
	{
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string BasicToken { get; set; }

    }
}
