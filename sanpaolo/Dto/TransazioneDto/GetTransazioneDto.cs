using sanpaolo.Models;
using System;

namespace sanpaolo.Dto.TransazioneDto
{
    public class GetTransazioneDto
    {
        public int Id { get; set; }
        public string Ordinante { get; set; }
        public string Beneficiario { get; set; }
        public float Ammontare { get; set; }
        public DateTime data { get; set; }
        public string Info { get; set; }
    }
}
