using ContabilizaJa.Movimentacao.Domain;
using ContabilizaJa.Movimentacao.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data
{
    public class ExtratoBancarioRepository : IExtratoBancarioRepository
    {
        protected readonly MovimentacaoContext _context;

        public ExtratoBancarioRepository(MovimentacaoContext db)
        {
            _context = db;
        }
        public virtual async Task Adicionar(ExtratoBancario extrato)
        {
            _context.Add(extrato);

            await _context.SaveChangesAsync();
        }
        public virtual async Task<List<ExtratoBancario>> ObterTodos()
        {
            return await _context.ExtratoBancario.AsNoTracking().ToListAsync();
        }
        public virtual async Task<ExtratoBancario> ObterPorId(int id)
        {
            return await _context.ExtratoBancario.FindAsync(id);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
