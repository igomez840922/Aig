﻿using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IMakerRepository
    {
        Task<PaginatedResult<AigFabricante>> ListAsync(PageSearchArgs args);
    }
}
