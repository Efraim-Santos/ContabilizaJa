using ContabilizaJa.Movimentacao.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Data
{
    public class MovimentacaoContext : DbContext
    {
        public MovimentacaoContext(DbContextOptions<MovimentacaoContext> options) : base(options) { }

        public DbSet<ExtratoBancario> ExtratoBancario { get; set; }
        public DbSet<Transacoes> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExtratoBancario).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
