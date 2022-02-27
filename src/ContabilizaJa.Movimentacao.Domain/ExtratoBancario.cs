using ContabilizaJa.Movimentacao.Domain.Core;
using System;
using System.Collections.Generic;

namespace ContabilizaJa.Movimentacao.Domain
{
    public class ExtratoBancario : Entity
    {
        public ICollection<Transacoes> Transaction { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public DateTime DataRegistro { get; private set; }

        public ExtratoBancario(ICollection<Transacoes> transaction, DateTime dataInicio, DateTime dataFim)
        {
            Transaction = transaction;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataRegistro = DateTime.Now;
        }
    }
}
