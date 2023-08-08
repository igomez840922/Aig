using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;

namespace Aig.Farmacoterapia.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Encrypt(this string input)
        {
            string key = "@dse-dff*&-plgh$";
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            var tripleDES = TripleDES.Create(); //new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(this string input)
        {
            string key = "@dse-dff*&-plgh$";
            byte[] inputArray = Convert.FromBase64String(input);
            var tripleDES = TripleDES.Create(); //new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}