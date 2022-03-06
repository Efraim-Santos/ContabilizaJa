using ContabilizaJa.Movimentacao.Application;
using ContabilizaJa.Movimentacao.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Processamento.ApplicationCore.Commands
{
    class AdicionarExtratoBancarioCommand : IRequest<bool>
    {
        public ICollection<Transacoes> Transacoes { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
