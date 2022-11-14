using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace Aig.Farmacoterapia.Infrastructure.Extensions
{
    public static class JsonValueConverterExtensions
    {
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder)
        {
            var converter = new ValueConverter<T, string>(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
#pragma warning disable CS8603 // Possible null reference return.
                v => JsonConvert.DeserializeObject<T>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
#pragma warning restore CS8603 // Possible null reference return.

            var comparer = new ValueComparer<T>(
                (o1, o2) => JsonConvert.SerializeObject(o1) == JsonConvert.SerializeObject(o2),
                v => v == null ? 0 : JsonConvert.SerializeObject(v).GetHashCode(),
#pragma warning disable CS8603 // Possible null reference return.
                v => JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(v)));
#pragma warning restore CS8603 // Possible null reference return.

            propertyBuilder.HasConversion(converter, comparer);
            propertyBuilder.HasColumnType("nvarchar(max)");
            return propertyBuilder;
        }
    }
}
