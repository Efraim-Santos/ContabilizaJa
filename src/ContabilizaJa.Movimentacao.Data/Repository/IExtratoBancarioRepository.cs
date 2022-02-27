using ContabilizaJa.Movimentacao.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data
{
    public interface IExtratoBancarioRepository
    {
        Task Adicionar(ExtratoBancario extrato);
        Task<ExtratoBancario> ObterPorId(int id);
        Task<List<ExtratoBancario>> ObterTodos();
    }
}