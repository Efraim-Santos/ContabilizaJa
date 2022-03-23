using ContabilizaJa.Movimentacao.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public class TransacoesBancariasRepository : Repository<Transacoes>, ITransacoesBancariasRepository
    {
        public TransacoesBancariasRepository(MovimentacaoContext context) : base(context){}

        public async Task RemoverTransacoesDoExtrato(int idExtrato)
        {
            var transacoes = await dbSet.Where(t => t.Extrato.Id == idExtrato).ToListAsync();

            dbSet.RemoveRange(transacoes);
        }
    }
}
