using Aig.Auditoria.Pages.Inspections;
using DataAccess;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Aig.Auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActasController : ControllerBase
    {
        private readonly IDalService dalService;
        public ActasController(IDalService dalService)
        {
            this.dalService= dalService;
        }

        [HttpGet("GetByNumber")]
        public async Task<IActionResult> GetByNumber(string number)
        {
            try {
                if (!string.IsNullOrEmpty(number))
                {
                    var data = dalService.Find<AUD_InspeccionTB>(x => x.NumActa == number);
                    if(data!=null)
                    {
                        return Ok(data);
                    }
                }
            }
            catch(Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "data not found" });
        }
    }
}
