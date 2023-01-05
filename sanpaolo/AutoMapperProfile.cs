using AutoMapper;
using sanpaolo.Dto.Banca;
using sanpaolo.Dto.ContoDto;
using sanpaolo.Dto.SalvadanaioDto;
using sanpaolo.Dto.TransazioneDto;
using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;

namespace sanpaolo
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Utente, GetUtenteDto>();
            CreateMap<AddUtenteDto, Utente>();
            CreateMap<Banca, GetBancaDto>();
            CreateMap<UpdateBancaDto, Banca>();
            CreateMap<Conto, GetContoDto>();
            CreateMap<Salvadanaio, GetSalvadanaioDto>();
            CreateMap<Transazione, GetTransazioneDto>();
        }
    }
}
