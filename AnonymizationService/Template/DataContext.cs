using Microsoft.EntityFrameworkCore;
using AnonymizationService.Infra.Entidades;

namespace AnonymizationService
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RegistroAnonimizacao> RegistrosAnonimizacao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroAnonimizacao>()
            .HasKey(r => r.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
