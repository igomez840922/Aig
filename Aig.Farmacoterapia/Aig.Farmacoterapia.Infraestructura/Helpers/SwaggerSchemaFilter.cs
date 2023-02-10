using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Aig.Farmacoterapia.Infrastructure.Helpers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerOrder : Attribute
    {
        public int Order { get; }
        public SwaggerOrder(int order) { Order = order; }
    }
    public class SwaggerOrderingFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument openApiDoc, DocumentFilterContext context)
        {
            Dictionary<KeyValuePair<string, OpenApiPathItem>, int> paths = new();
            foreach (var path in openApiDoc.Paths)
            {

                if (context.ApiDescriptions.FirstOrDefault(x => x.RelativePath.Replace("/", string.Empty)
                  .Equals(path.Key.Replace("/", string.Empty), StringComparison.InvariantCultureIgnoreCase))?
                  .ActionDescriptor?.EndpointMetadata?.FirstOrDefault(x => x is SwaggerOrder) is not SwaggerOrder attribute) throw new ArgumentNullException($"Not found: {path.Key}");

                var order = attribute.Order;
                paths.Add(path, order);
            }
            var orderedPaths = paths.OrderBy(x => x.Value).ToList();
            openApiDoc.Paths.Clear();
            orderedPaths.ForEach(x => openApiDoc.Paths.Add(x.Key.Key, x.Key.Value));
        }

    }
    public class SwaggerIgnoreFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
                return;
            var ignoreDataMemberProperties = context.Type.GetProperties()
                .Where(t => t.GetCustomAttribute<IgnoreDataMemberAttribute>() != null);
            foreach (var ignoreDataMemberProperty in ignoreDataMemberProperties)
            {
                var propertyToHide = schema.Properties.Keys
                    .SingleOrDefault(x => string.Equals(x, ignoreDataMemberProperty.Name, StringComparison.CurrentCultureIgnoreCase));
                if (propertyToHide != null)
                    schema.Properties.Remove(propertyToHide);
            }
        }
    }
}
