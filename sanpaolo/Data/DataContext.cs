using Microsoft.EntityFrameworkCore;
using sanpaolo.Models;

namespace sanpaolo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Utente> Utenti{ get; set; }
        public DbSet<Banca> Banca{ get; set; }
        public DbSet<Conto> Conti { get; set; }
        public DbSet<Salvadanaio> Salvadanaio { get; set; }
        //public DbSet<Transazione> Transazioni { get; set; }
    }
}
