using sanpaolo.Dto.UtenteDto;
using sanpaolo.Models;
using System.Collections.Generic;

namespace sanpaolo.Dto.Banca
{
    public class GetBancaDto
    {
        public string Nome { get; set; }
        public string Sede { get; set; }
        public List<GetUtenteDto> Contisti { get; set; }
    }
}
