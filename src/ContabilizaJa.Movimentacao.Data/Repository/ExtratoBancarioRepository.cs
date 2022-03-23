using ContabilizaJa.Movimentacao.Data.Repository;
using ContabilizaJa.Movimentacao.Domain;
using ContabilizaJa.Movimentacao.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data
{
    public class ExtratoBancarioRepository : Repository<ExtratoBancario>, IExtratoBancarioRepository
    {
        public ExtratoBancarioRepository(MovimentacaoContext context) : base(context) { }

        public async Task<ExtratoBancario> ObterExtratoTransacoes(int id)
        {
           return await dbSet
                            .Include(e => e.Transacoes)
                            .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}