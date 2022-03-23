using ContabilizaJa.Movimentacao.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Queries
{
    public interface IExtratoBancarioQueries
    {
        Task<IEnumerable<ExtratoBancarioViewModels>> ObterListaDeExtratos();
        Task<ExtratoBancarioViewModels> ConsultarExtrato(int id);
    }
}