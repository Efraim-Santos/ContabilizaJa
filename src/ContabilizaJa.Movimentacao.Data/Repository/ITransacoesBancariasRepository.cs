using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public interface ITransacoesBancariasRepository
    {
        Task RemoverTransacoesDoExtrato(int idExtrato);
    }
}