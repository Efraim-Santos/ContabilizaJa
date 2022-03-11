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

        public async Task Adicionar(ExtratoBancario extrato)
        {
            await _context.ExtratoBancario.AddAsync(extrato);
        }

        public void Remover(ExtratoBancario extrato)
        {
            _context.ExtratoBancario.Remove(extrato);
        }

        public async Task<List<ExtratoBancario>> ObterTodos()
        {
            return await _context.ExtratoBancario.AsNoTracking().ToListAsync();
        }

        public async Task<ExtratoBancario> ObterPorId(int id)
        {
            return await _context.ExtratoBancario.FindAsync(id);
        }
    }
}