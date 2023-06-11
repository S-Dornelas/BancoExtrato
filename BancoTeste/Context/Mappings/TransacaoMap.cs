using BancoTeste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BancoTeste.Context.Mappings
{
    public partial class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> entity)
        {
            entity.Property(e => e.Id)
                .HasColumnName("ID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.CategoriaId).HasColumnName("CategoriaID");

            entity.Property(e => e.ContaId).HasColumnName("ContaID");

            entity.Property(e => e.Credito).HasColumnType("money");

            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.Property(e => e.Debito).HasColumnType("money");

            entity.Property(e => e.Historico)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false);

            entity.Property(e => e.Notas)
                .IsRequired()
                .HasColumnType("text");

            entity.HasOne(d => d.Categoria)
                .WithMany(p => p.Transacao)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transacao_Categoria");

            entity.HasOne(d => d.Conta)
                .WithMany(p => p.Transacao)
                .HasForeignKey(d => d.ContaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transacao_Conta");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Transacao> entity);
    }
}
