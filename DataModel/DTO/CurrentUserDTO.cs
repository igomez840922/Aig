using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.DTO
{
    public class CurrentUserDTO
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
