using AnonymizationService.Infra.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Exemplo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RegistroAnonimizacao> RegistrosAnonimizacao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroAnonimizacao>().HasKey(r => r.Id); ;
            

            base.OnModelCreating(modelBuilder);
        }
    }
}
