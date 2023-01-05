using sanpaolo.Models;
using System;

namespace sanpaolo.Dto.UtenteDto
{
    public class AddUtenteDto
    {
        public string Nome { get; set; } = "Emanuel Andrei";
        public string Cognome { get; set; } = "Petrut";
        public DateTime DataDiNascita { get; set; } = new DateTime(2001, 02, 24);
        public string CodiceFiscale { get; set; } = "PTRMLN01B24Z129Q";
        public string NumeroCartaIdentita { get; set; } = "IE456DA";
        public string Nazionalita { get; set; } = "Rumena";
        public Ruolo Ruolo { get; set; } = Ruolo.Contista;
        public string Paese { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public string Comune { get; set; }
        public string Cap { get; set; }
        public string Via { get; set; }
    }
}

