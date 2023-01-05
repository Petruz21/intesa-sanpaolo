using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sanpaolo.Data;
using sanpaolo.Dto.ContoDto;
using sanpaolo.Models;
using sanpaolo.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanpaolo.Services.ContoService
{
    public class ContoService : IContoService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ContoService (DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<List<GetContoDto>>> GetAll()
        {
            Response<List<GetContoDto>> response = new Response<List<GetContoDto>>();
            List<Conto> dbConti = await _context.Conti.Include(c => c.Salvadanaio).ToListAsync();
            response.Data = dbConti.Select(c => _mapper.Map<GetContoDto>(c)).ToList();
            return response;

        }

        public async Task<Response<GetContoDto>> GetSingle(int IdUtente)
        {
            Response<GetContoDto> response = new Response<GetContoDto>();
            Conto DbConto = await _context.Conti.Include(c => c.Salvadanaio).FirstOrDefaultAsync(c => c.UtenteId == IdUtente);
            response.Data = _mapper.Map<GetContoDto>(DbConto);

            return response;
        }
    }
}
