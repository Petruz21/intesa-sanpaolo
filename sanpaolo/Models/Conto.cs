using System.Collections.Generic;

namespace sanpaolo.Models
{
    public class Conto
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public int NConto { get; set; }
        public float Saldo { get; set; }
        public Utente Utente { get; set; }
        public int UtenteId { get; set; }
        public Salvadanaio Salvadanaio { get; set; }
    }
}
