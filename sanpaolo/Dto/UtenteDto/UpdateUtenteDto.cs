using sanpaolo.Dto.ContoDto;
using sanpaolo.Models;
using System;

namespace sanpaolo.Dto.UtenteDto
{
    public class UpdateUtenteDto
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; } = "Emanuel Andrei";
        public string Cognome { get; set; } = "Petrut";
        public DateTime DataDiNascita { get; set; } = new DateTime(2001, 02, 24);
        public string CodiceFiscale { get; set; } = "PTRMLN01B24Z129Q";
        public string NumeroCartaIdentita { get; set; } = "IE456DA";
        public string Nazionalita { get; set; } = "Rumena";
        public string Paese { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public string Comune { get; set; }
        public string Cap { get; set; }
        public string Via { get; set; }
        public Ruolo Ruolo { get; set; } = Ruolo.Contista;
        public GetContoDto Conto { get; set; } = new GetContoDto { Iban = "IT09000456GH234405640000027" };
    }
}
