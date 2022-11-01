using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories
{
    public class ContryRepository : IContryRepository
    {
        private readonly IRepositoryAsync<AigPais> _repository;
        public ContryRepository(IRepositoryAsync<AigPais> repository)
        {
            _repository = repository;
        }

    }
}
