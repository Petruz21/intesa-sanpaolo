using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;
using sanpaolo.Services.UtenteService;
using sanpaolo.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanpaolo.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UtenteController : ControllerBase
    {
        private readonly IUtenteService _utenteService;
        public UtenteController(IUtenteService utenteService)
        {
            _utenteService = utenteService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUtenti()
        {
            return Ok(await _utenteService.GetAllUtenti());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getSingle(int id)
        {
            Response<GetUtenteDto> response = await _utenteService.GetSingle(id);
            
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddUtente(AddUtenteDto newUtente)
        {
            return Ok(await _utenteService.AddUtente(newUtente));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUtente(UpdateUtenteDto updatedUtente)
        {
            Response<GetUtenteDto> response = await _utenteService.UpdateUtente(updatedUtente);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUtente(int id)
        {
            Response<List<GetUtenteDto>> response = await _utenteService.DeleteUtente(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
