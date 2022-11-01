using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace Aig.Farmacoterapia.Infrastructure.Files
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile<T, TMap>(IEnumerable<T> records, TMap map) where T : class where TMap : ClassMap;
    }

}
