using ContabilizaJa.Movimentacao.Domain.Core;
using System;
using System.Collections.Generic;

namespace ContabilizaJa.Movimentacao.Domain
{
    public class ExtratoBancario : Entity
    {
        public ICollection<Transacoes> Transacoes { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public DateTime DataRegistro { get; private set; }

        public ExtratoBancario(ICollection<Transacoes> transacoes, DateTime dataInicio, DateTime dataFim)
        {
            Transacoes = transacoes;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataRegistro = DateTime.Now;
        }

        protected ExtratoBancario(){}
    }
}
