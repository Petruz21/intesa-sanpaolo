using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sanpaolo.Dto.Banca;
using sanpaolo.Services.BancaService;
using System.Threading.Tasks;

namespace sanpaolo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BancaController : ControllerBase
    {
        private readonly IBancaService _bancaService;

        public BancaController(IBancaService bancaService)
        {
            _bancaService = bancaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBanca()
        {
            return Ok(await _bancaService.GetBanca());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBanca(UpdateBancaDto updatedBanca)
        {
            return Ok(await _bancaService.UpdateBanca(updatedBanca));
        }
    }
}
