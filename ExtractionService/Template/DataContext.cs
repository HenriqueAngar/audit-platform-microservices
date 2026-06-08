using Microsoft.EntityFrameworkCore;
using ExtractionService.Infra.Entidades;

namespace Exemplo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RegistroExtracao> RegistrosExtracao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroExtracao>()
            .HasKey(r => r.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
