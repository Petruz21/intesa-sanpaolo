using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sanpaolo.Services.ContoService;
using System.Threading.Tasks;

namespace sanpaolo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContoController : ControllerBase
    {
        private readonly IContoService _contoService;
        public ContoController(IContoService contoService)
        {
            _contoService = contoService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllConti()
        {
            return Ok(await _contoService.GetAll());
        }

        [HttpGet]
        [Route("{IdUtente}")]
        public async Task<IActionResult> GetSingle(int IdUtente)
        {
            return Ok(await _contoService.GetSingle(IdUtente));
        }
       
    }
}
