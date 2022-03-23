using System;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly MovimentacaoContext _context;
        private IExtratoBancarioRepository extratoBancarioRepository;
        private ITransacoesBancariasRepository transacoesBancariasRepository;

        public UnitOfWork(MovimentacaoContext context)
        {
            _context = context;
        }

        public IExtratoBancarioRepository ExtratoBancarioRepository
        {
            get
            {
                return extratoBancarioRepository = extratoBancarioRepository ?? new ExtratoBancarioRepository(_context);
            }
        }

        public ITransacoesBancariasRepository TransacoesBancariasRepository
        {
            get
            {
                return transacoesBancariasRepository = transacoesBancariasRepository ?? new TransacoesBancariasRepository(_context);
            }
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
