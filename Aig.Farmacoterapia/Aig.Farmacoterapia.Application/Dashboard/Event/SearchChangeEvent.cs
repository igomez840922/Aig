﻿using Aig.Farmacoterapia.Application.Medicament.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Dashboard.Event
{
    public class SearchChangeEvent
    {
        public HomeFilter Filter { get; set; } = new HomeFilter();
    }
}
