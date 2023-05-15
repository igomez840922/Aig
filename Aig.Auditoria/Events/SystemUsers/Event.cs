using DataModel;
using DataModel.Models;

namespace Aig.Auditoria.Events.SystemUsers
{       
    public class ChangePswEvent
    { 
        public ChangePswModel Data { get; set; }
    }
    
    public class RegisterEvent
    {
        public RegisterModel Data { get; set; }
    }
    public class EditEvent
    {
        public ApplicationUser Data { get; set; }
    }
}
