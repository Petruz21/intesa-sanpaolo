using sanpaolo.Dto.ContoDto;
using System;

namespace sanpaolo.Dto.SalvadanaioDto
{
    public class GetSalvadanaioDto
    {
        public float SaldoAttuale { get; set; }
        public string Info { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime DataScadenza { get; set; }
        public float AmmontareObbiettivo { get; set; }
        public GetContoDto Conto { get; set; }
        public int ContoId { get; set; }
    }
}
