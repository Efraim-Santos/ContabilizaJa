using ContabilizaJa.Movimentacao.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Data.Mappings
{
    public class TransacoesMapping : IEntityTypeConfiguration<Transacoes>
    {
        public void Configure(EntityTypeBuilder<Transacoes> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Tipo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(t => t.Valor)
                .IsRequired()
                .HasColumnType("decimal(5, 2)");

            builder.HasOne(t => t.Extrato)
                .WithMany(e => e.Transaction)
                .HasForeignKey(t => t.Id);

            builder.ToTable("Transacoes");
        }
    }
}
