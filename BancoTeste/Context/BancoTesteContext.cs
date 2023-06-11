using BancoTeste.Context.Mappings;
using BancoTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoTeste.Context
{
    public class BancoTesteContext : DbContext
    {
        public BancoTesteContext(DbContextOptions<BancoTesteContext> options) : base(options) { }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());
        }       
    }
}

// foi realizada o relacionamento na Appsettings.jon e a dependencia no Program