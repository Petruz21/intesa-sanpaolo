using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sanpaolo.Data;
using sanpaolo.Dto.Banca;
using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;
using sanpaolo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanpaolo.Services.BancaService
{
    public class BancaService : IBancaService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public BancaService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<Response<GetBancaDto>> GetBanca()
        {
            Response<GetBancaDto> response = new Response<GetBancaDto>();
            
            try
            {

                Banca dbBanca = await _context.Banca.FirstOrDefaultAsync();
                response.Data = _mapper.Map<GetBancaDto>(dbBanca);
                List<GetUtenteDto> dbUtenti = await _context.Utenti.Select(u => _mapper.Map<GetUtenteDto>(u)).ToListAsync();
                response.Data.Contisti = dbUtenti;

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            } 

            return response;
        }

        public async Task<Response<GetBancaDto>> UpdateBanca(UpdateBancaDto updatedBanca)
        {
            Response<GetBancaDto> response = new Response<GetBancaDto>();

            try
            {

                Banca dbBanca = _context.Banca.FirstOrDefault(b => b.Id == updatedBanca.Id);

                dbBanca.Nome = updatedBanca.Nome;
                dbBanca.Sede = updatedBanca.Sede;

                _context.Banca.Update(dbBanca);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetBancaDto>(dbBanca);

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }

            return response;
        }
    }
}
