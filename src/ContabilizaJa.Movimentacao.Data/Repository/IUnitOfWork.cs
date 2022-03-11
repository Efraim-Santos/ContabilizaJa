using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public interface IUnitOfWork
    {
        IExtratoBancarioRepository ExtratoBancarioRepository { get; }

        Task<bool> Commit();
    }
}