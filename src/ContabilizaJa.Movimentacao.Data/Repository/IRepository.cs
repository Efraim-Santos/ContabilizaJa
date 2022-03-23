using ContabilizaJa.Movimentacao.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task Adicionar(TEntity entidade);
        Task<TEntity> ObterPorId(int id);
        Task<List<TEntity>> ObterTodos();
        void Remover(TEntity entidade);
    }
}