using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditoriaApp.Helper
{
    public static class Helper
    {
        public static string ReturnBase64FromFilePath(string filePath)
        {
            try {
                // Read the file content into a byte array
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Convert the byte array to a Base64 string
                string base64String = Convert.ToBase64String(fileBytes);

                return base64String;
            }
            catch { }
            return null;
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
