using Aig.Farmacoterapia.Application.Medicament.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Dashboard.Event
{
    public class SearchChangeEvent
    {
        public string SearchText { get; set; }
    }
    public class SearchTermEvent
    {
        public string Term { get; set; }
        public bool Refresh { get; set; } = true;
    }
}
