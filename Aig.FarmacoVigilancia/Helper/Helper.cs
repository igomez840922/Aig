using Aig.FarmacoVigilancia.Nomenclators;
using System.Reflection;
using System.Text.Json;

namespace Aig.FarmacoVigilancia.Helper
{
    public static class Helper
    {
        //retorna el nombre del Mes por su numero
        public static string GetMonthNameByMonthNumber(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    {
                        return "Enero";
                    }
                case 2:
                    {
                        return "Febrero";
                    }
                case 3:
                    {
                        return "Marzo";
                    }
                case 4:
                    {
                        return "Abril";
                    }
                case 5:
                    {
                        return "Mayo";
                    }
                case 6:
                    {
                        return "Junio";
                    }
                case 7:
                    {
                        return "Julio";
                    }
                case 8:
                    {
                        return "Agosto";
                    }
                case 9:
                    {
                        return "Septiembre";
                    }
                case 10:
                    {
                        return "Octubre";
                    }
                case 11:
                    {
                        return "Noviembre";
                    }
                case 12:
                    {
                        return "Diciembre";
                    }
            }

            return "";
        }

        public static string GetNomenclatorValue(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{assembly.GetName().Name}.Nomenclators.{file}";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) return string.Empty;
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static string GetATC2doNivel(string term)
        {
            string value = string.Empty;
            if (string.IsNullOrEmpty(term)) return value;
            var search = term.Trim();
            if (search.Length > 3)
                search = term.Trim()[..3].ToString();
            var result = GetNomenclatorValue("ATC2doNivel.json");
            if (string.IsNullOrEmpty(result)) return value;
            var jsonData = JsonSerializer.Deserialize<List<ATC2doNivelModel>>(result);
            ATC2doNivelModel find;
            if ((find = jsonData!.FirstOrDefault(p => p.ATC2doNivel.ToLower().StartsWith(search.ToLower()))) != null)
                value = find.Subgrupo;
            return value;
        }

    }
}
