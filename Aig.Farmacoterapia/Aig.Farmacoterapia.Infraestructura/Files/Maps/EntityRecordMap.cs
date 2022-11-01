using System.Globalization;
using Aig.Farmacoterapia.Infrastructure.Identity;
using CsvHelper.Configuration;

namespace Aig.Farmacoterapia.Infrastructure.Files.Maps
{
    public sealed class UserRecordMap : ClassMap<ApplicationUser>
    {
        public UserRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.EmailConfirmed).Convert(c => c.Value.EmailConfirmed ? "Yes" : "No");
        }
    }
}


