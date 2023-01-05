using Microsoft.AspNetCore.Mvc;
using System;

namespace sanpaolo.Dto.UtenteDto
{
    public class UtenteRegisterDto
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public DateTime DataDiNascita { get; set; }
        public string CodiceFiscale { get; set; }
        public string NumeroCartaIdentita { get; set; }
        public string Nazionalita { get; set; }
        public string Paese { get; set; }
        public string Regione { get; set; }
        public string Provincia { get; set; }
        public string Comune { get; set; }
        public string Cap { get; set; }
        public string Via { get; set; }
        public string Password { get; set; }
    }        

}
