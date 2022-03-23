using ContabilizaJa.Movimentacao.Domain;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public interface IUnitOfWork
    {
        IExtratoBancarioRepository ExtratoBancarioRepository { get; }

        ITransacoesBancariasRepository TransacoesBancariasRepository { get; }

        Task<bool> Commit();
    }
}