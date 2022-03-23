using ContabilizaJa.Movimentacao.Data.Repository;
using ContabilizaJa.Movimentacao.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data
{
    public interface IExtratoBancarioRepository : IRepository<ExtratoBancario>
    {
        Task<ExtratoBancario> ObterExtratoTransacoes(int id); 
    }
}