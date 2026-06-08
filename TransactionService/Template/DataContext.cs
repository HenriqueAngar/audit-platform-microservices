using Microsoft.EntityFrameworkCore;
using TransactionService.Infra.Entidades;

namespace TransactionService
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>()
                .HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}