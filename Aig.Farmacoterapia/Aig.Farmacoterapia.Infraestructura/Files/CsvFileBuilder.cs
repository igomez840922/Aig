using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Aig.Farmacoterapia.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile<T, TMap>(IEnumerable<T> records, TMap map) where T : class where TMap:ClassMap
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<TMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }

}
