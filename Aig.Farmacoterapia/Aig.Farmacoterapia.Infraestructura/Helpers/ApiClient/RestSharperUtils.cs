using RestSharp;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Aig.Farmacoterapia.Infrastructure.Helpers.ApiClient
{
    public class RestSharperJsonSerializer : IRestSerializer
    {
        public string? Serialize(object obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ContentType { get; set; } = string.Empty;

        public T? Deserialize<T>(IRestResponse response)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(response.Content);
            }
            catch(Exception ex)
            {
                return default;
            }
        }

        public string? Serialize(Parameter parameter)
        {
            return parameter.Value != null
                ? JsonSerializer.Serialize(parameter.Value)
                : null;
        }

        public string[] SupportedContentTypes => new[] { "text/json", "application/json" };
        public DataFormat DataFormat => DataFormat.Json;
    }

    public class RestSharperXmlSerializer : IRestSerializer
    {
        public string? Serialize(object obj)
        {
            return SerializationUtils.SerializeXml(obj);
        }

        public string ContentType { get; set; } = string.Empty;
        public T? Deserialize<T>(IRestResponse response)
        {
            using var reader = new StringReader(response.Content);
            var serializer = new XmlSerializer(typeof(T));
            return (T?)serializer.Deserialize(reader);
        }

        public string? Serialize(Parameter parameter)
        {
            return parameter.Value != null
                ? Serialize(parameter.Value)
                : null;
        }

        public string[] SupportedContentTypes => new[] { "application/xml", "text/xml" };
        public DataFormat DataFormat => DataFormat.Xml;
    }
}
