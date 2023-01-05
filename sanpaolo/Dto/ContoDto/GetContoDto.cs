using sanpaolo.Dto.SalvadanaioDto;
using sanpaolo.Dto.TransazioneDto;
using System.Collections.Generic;

namespace sanpaolo.Dto.ContoDto
{
    public class GetContoDto
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public int NConto { get; set; }
        public float Saldo { get; set; }
        public int UtenteId { get; set; }
        public GetSalvadanaioDto Salvadanaio { get; set; }
        public List<GetTransazioneDto> Transazioni { get; set; }
    }
}
