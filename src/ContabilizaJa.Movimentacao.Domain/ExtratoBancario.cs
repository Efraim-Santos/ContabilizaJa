using ContabilizaJa.Movimentacao.Domain.Core;
using System;
using System.Collections.Generic;

namespace ContabilizaJa.Movimentacao.Domain
{
    public class ExtratoBancario : Entity
    {
        public IEnumerable<Transacoes> Transacoes { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public DateTime DataRegistro { get; private set; }

        public ExtratoBancario(DateTime dataInicio, DateTime dataFim, DateTime dataRegistro)
        {
            //Transacoes = transacoes;
            DataInicio = dataInicio;
            DataFim = dataFim;
            DataRegistro = dataRegistro;
        }

        public ExtratoBancario() { }

        //public void SetDataInicio(DateTime data)
        //{
        //    if (data != null && data != new DateTime(2001, 01, 01))
        //        this.DataInicio = data;
        //}
    }
}
