using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sanpaolo.Data;
using sanpaolo.Dto.ContoDto;
using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;
using sanpaolo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanpaolo.Services.UtenteService
{
    public class UtenteService : IUtenteService
    {

        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public UtenteService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Response<List<GetUtenteDto>>> AddUtente(AddUtenteDto newUtente)
        {
            Response<List<GetUtenteDto>> response = new Response<List<GetUtenteDto>>();
            Utente utente = _mapper.Map<Utente>(newUtente); // Mappiamo in Utente perchè ci arriva sottoforma di AddUtenteDto ma la lista è di tipo Utenti
            // utente.Id = utenti.Max(u => u.Id) + 1; // Imposto l'id per il nuovo utente creato
            await _context.Utenti.AddAsync(utente); // Aggiungo l'utente alla lista statica utenti
            await _context.SaveChangesAsync();
            response.Data = _context.Utenti.Select(u => _mapper.Map<GetUtenteDto>(u)).ToList(); // Mapping della lista di utenti in GetUtenteDto
            
            return response;
        }

        public async Task<Response<List<GetUtenteDto>>> GetAllUtenti()
        {
            Response<List<GetUtenteDto>> response = new Response<List<GetUtenteDto>>();
            
            try
            {
                List<Utente> dbUtenti = await _context.Utenti.Include(u => u.Conto).Include(u => u.Conto.Salvadanaio).Where(u => u.Id == u.Conto.UtenteId).ToListAsync();
                response.Data = dbUtenti.Select(u => _mapper.Map<GetUtenteDto>(u)).ToList();

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
            return response;
        }

        public async Task<Response<GetUtenteDto>> GetSingle(int id)
        {
            Response<GetUtenteDto> response = new Response<GetUtenteDto>();
            
            try
            {
                Utente dbUtente = await _context.Utenti.Include(u => u.Conto).Include(u => u.Conto.Salvadanaio).FirstOrDefaultAsync(u => u.Id == id);
                response.Data = _mapper.Map<GetUtenteDto>(dbUtente);
                

                if (response.Data == null)
                {
                    response.Message = "L'utente non esiste, controlla i dati inseriti";
                    response.Success = false;
                    return response;
                }

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }

            return response;
        }

        public async Task<Response<GetUtenteDto>> UpdateUtente(UpdateUtenteDto updatedUtente)
        {
            Response<GetUtenteDto> response = new Response<GetUtenteDto>();

            try
            {
                Utente dbUtente = await _context.Utenti.Include(u => u.Conto).FirstOrDefaultAsync(u => u.Id == updatedUtente.Id);

                dbUtente.Nome = updatedUtente.Nome;
                dbUtente.Cognome = updatedUtente.Cognome;
                dbUtente.DataDiNascita = updatedUtente.DataDiNascita;
                dbUtente.CodiceFiscale = updatedUtente.CodiceFiscale;
                dbUtente.NumeroCartaIdentita = updatedUtente.NumeroCartaIdentita;
                dbUtente.Nazionalita = updatedUtente.Nazionalita;
                dbUtente.Ruolo = updatedUtente.Ruolo;
                dbUtente.Conto.Iban = updatedUtente.Conto.Iban;

                _context.Utenti.Update(dbUtente);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetUtenteDto>(dbUtente);

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
            
            return response;
        }

        public async Task<Response<List<GetUtenteDto>>> DeleteUtente(int id)
        {
            Response<List<GetUtenteDto>> response = new Response<List<GetUtenteDto>>();


            try
            {
                Utente dbUtente = await _context.Utenti.Include(u => u.Conto).FirstOrDefaultAsync(u => u.Id == id);

                if (dbUtente == null)
                {
                    response.Message = "L'utente non esiste, controlla i dati inseriti";
                    response.Success = false;
                    return response;
                }

                _context.Utenti.Remove(dbUtente);
                await _context.SaveChangesAsync();

                response.Data = await _context.Utenti.Select(u => _mapper.Map<GetUtenteDto>(u)).ToListAsync();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }

            return response;
        }
    }
}
