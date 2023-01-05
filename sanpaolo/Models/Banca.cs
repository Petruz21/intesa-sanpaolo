using System.Collections.Generic;

namespace sanpaolo.Models
{
    public class Banca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sede { get; set; }
        public List<Utente> Contisti { get; set; }
    }
}
