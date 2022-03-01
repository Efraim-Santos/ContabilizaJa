using ContabilizaJa.Movimentacao.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContabilizaJa.Movimentacao.Data.Mappings
{
    public class ExtratoBancarioMapping : IEntityTypeConfiguration<ExtratoBancario>
    {
        public void Configure(EntityTypeBuilder<ExtratoBancario> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataInicio)
                .IsRequired();
            
            builder.Property(e => e.DataFim)
                .IsRequired();

            builder.HasMany(e => e.Transaction)
                .WithOne(t => t.Extrato)
                .HasForeignKey(e => e.Id);

            builder.ToTable("ExtratosBancarios");
        }
    }
}
