namespace Aig.Farmacoterapia.Public.Extensions
{
    public static class StringExtensions
    {
       
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.Trim().First().ToString().ToUpper() + input.Trim().Substring(1).ToLower();
        }
    }
}
