using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosPersonalTecnico:SystemId
    {
        public AUD_DatosPersonalTecnico()
        {
            LPersonalTecnico = new List<PersonalTecnico>();
        }

        //Lista de Personal Tecnico
        private List<PersonalTecnico> lPersonalTecnico;
        [StringLength(250)]
        public List<PersonalTecnico> LPersonalTecnico { get => lPersonalTecnico; set => SetProperty(ref lPersonalTecnico, value); }

    }


}
