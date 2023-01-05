using Microsoft.AspNetCore.Mvc;
using sanpaolo.Data;
using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;
using sanpaolo.Utility;
using System.Threading.Tasks;

namespace sanpaolo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UtenteLoginDto request)
        {
            Response<string> response = await _authRepo.Login(
                request.Email, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UtenteRegisterDto request)
        {
            Response<int> response = await _authRepo.Register(
            new Utente {
                Nome = request.Nome,
                Cognome = request.Cognome,
                Email = request.Email,
                DataDiNascita = request.DataDiNascita,
                CodiceFiscale = request.CodiceFiscale,
                NumeroCartaIdentita = request.NumeroCartaIdentita,
                Nazionalita = request.Nazionalita,
                Paese = request.Paese,
                Regione = request.Regione,
                Provincia = request.Provincia,
                Comune = request.Comune,
                Cap = request.Cap,
                Via = request.Via
            },
            request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
