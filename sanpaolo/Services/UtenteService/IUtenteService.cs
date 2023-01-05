using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;
using sanpaolo.Utility;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sanpaolo.Services.UtenteService
{
    public interface IUtenteService
    {
        Task<Response<List<GetUtenteDto>>> GetAllUtenti();
        Task<Response<GetUtenteDto>> GetSingle(int id);
        Task<Response<List<GetUtenteDto>>> AddUtente(AddUtenteDto newUtente);
        Task<Response<GetUtenteDto>> UpdateUtente(UpdateUtenteDto updateUtente);
        Task<Response<List<GetUtenteDto>>> DeleteUtente(int id);
    }
}
