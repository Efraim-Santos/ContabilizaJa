using ContabilizaJa.Movimentacao.Application;
using MediatR;

namespace ContabilizaJa.Processamento.ApplicationCore.Commands
{
    public class AdicionarExtratoBancarioCommand : IRequest<bool>
    {
        public ExtratoBancarioViewModels ExtratoBancario { get; set; }
    }
}
