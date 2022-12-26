using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class PropositoInspeccion:SystemId
    {
        private string nombre;
        [StringLength(250)]
        public string Nombre
        {
            get { return Helper.Helper.GetDescription(PropositoType); }
            set { SetProperty(ref nombre, value); }
        }

        private enum_PropositoInspec propositoType;
        public enum_PropositoInspec PropositoType { get => propositoType; set => SetProperty(ref propositoType, value); }

    }
}
