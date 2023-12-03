using DataModel.DTO;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace Aig.FarmacoVigilancia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public FileUploadController(IWebHostEnvironment env)
        {
            this.env = env;
        }

        [HttpPost("UploadFile")]
        //[DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFile(IFormFile file)//([FromForm] IEnumerable<IFormFile> files)
        {
            try
            {
                if (file!=null)
                {
                    //foreach (var file in Request.Form.Files)
                    {
                        var dir = Path.Combine(env.WebRootPath, "files");//Path.GetRandomFileName()
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), file.FileName.Split(".").LastOrDefault());
                        var path = System.IO.Path.Combine(dir, fileName);

                        //var path = Path.Combine(dir, file.FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        var model = new FileUploadResult() 
                        {
                            AbsolutePath = path,
                            Url = string.Format("./files/{0}", fileName),
                            FileName = fileName
                        };

                        return Ok(model);
                    }
                }
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return BadRequest("Error al cargar el Fichero");
        }


        ////Return all subdirectories xlt
        //[HttpGet("GetFiles")]
        //public async Task<List<string>> GetFiles()
        //{
        //    try
        //    {
        //        var dir = Path.Combine(env.WebRootPath, "uploads");

        //        //string[] folders = System.IO.Directory.GetDirectories(@"C:\My Sample Path\","*", System.IO.SearchOption.AllDirectories);
        //        var allfiles = Directory.GetFiles(dir, "*.gltf", SearchOption.AllDirectories).ToList();

        //        return allfiles;
        //    }
        //    catch (Exception ex) { }

        //    return null;
        //    //return new CreatedResult(resourcePath, uploadResults);
        //}

    }
}
