using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Interfaces
{
    public interface IReportService : IReport {
        Task<byte[]> GetNotePdfAsync(long studyId);
    }
}
