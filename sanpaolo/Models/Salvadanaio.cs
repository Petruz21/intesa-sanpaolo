using System;

namespace sanpaolo.Models
{
    public class Salvadanaio
    {
        public int Id { get; set; }
        public float SaldoAttuale { get; set; }
        public string Info { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime DataScadenza { get; set; }
        public float AmmontareObbiettivo { get; set; }
        public Conto Conto { get; set; }
        public int ContoId { get; set; }
    }
}
