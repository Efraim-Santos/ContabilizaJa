using ContabilizaJa.Movimentacao.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbSet<TEntity> dbSet;

        public Repository(MovimentacaoContext context)
        {
            this.dbSet = context.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            var entityDataRegistro = entity.GetType().GetProperty("DataRegistro");

            if (entityDataRegistro != null)
                entityDataRegistro.SetValue(entity, Convert.ChangeType(DateTime.Now, entityDataRegistro.PropertyType));

            await dbSet.AddAsync(entity);
        }
        public void Remover(TEntity entidade)
        {
            dbSet.Remove(entidade);
        }
        public async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}
