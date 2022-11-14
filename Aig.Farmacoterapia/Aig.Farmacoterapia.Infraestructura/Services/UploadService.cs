using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Extensions;
using Aig.Farmacoterapia.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Infrastructure.Services
{
    public class UploadService : IUploadService
    {
        private readonly IWebHostEnvironment _environment;
        public UploadService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
      
        public async Task<string> UploadAsync(UploadObject request)
        {
            if (request.Data == null) return string.Empty;
            if (request.Data.Length > 0) {
                var folder = request.UploadType.ToDescriptionString();
                var folderName = Path.Combine("files", folder);
                var pathToSave = Path.Combine(_environment.WebRootPath, folderName);
                bool exists = Directory.Exists(pathToSave);
                if (!exists) Directory.CreateDirectory(pathToSave);
                var fileName = request.FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                if (File.Exists(dbPath)){
                    dbPath = NextAvailableFilename(dbPath);
                    fullPath = NextAvailableFilename(fullPath);
                }
                FileStream fs = File.Create(fullPath);
                await request.Data.CopyToAsync(fs);
                request.Data.Close();
                fs.Close();
                return dbPath;
            }
            else
                return string.Empty;
        }

#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<bool> DeleteAsync(string relativePath)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            if (string.IsNullOrEmpty(relativePath)) return false;
            var path= Path.Combine(_environment.WebRootPath, relativePath);
            if (File.Exists(path)) { 
                File.Delete(path);
                return true;
            }
            return false;
        }

        private static string numberPattern = " ({0})";

        public static string NextAvailableFilename(string path)
        {
            // Short-cut if already available
            if (!File.Exists(path))
                return path;

            // If path has extension then insert the number pattern just before the extension and return next filename
            if (Path.HasExtension(path))
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

            // Otherwise just append the pattern to the path and return next filename
            return GetNextFilename(path + numberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);
            //if (tmp == pattern)
            //throw new ArgumentException("The pattern must include an index place-holder", "pattern");

            if (!File.Exists(tmp))
                return tmp; // short-circuit if no matches

            int min = 1, max = 2; // min is inclusive, max is exclusive/untested

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                    min = pivot;
                else
                    max = pivot;
            }

            return string.Format(pattern, max);
        }

    }

}
