namespace Aig.Auditoria.Helper
{
    public static class Helper
    {
        public static IServiceProvider serviceProvider { get; set; }
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

        public static byte[] ReturnByteArrayFromBase64(string base64String)
        {
            try
            {
                byte[] fileBytes = Convert.FromBase64String(base64String);
                return fileBytes;
            }
            catch { }
            return null;
        }

    }
}
