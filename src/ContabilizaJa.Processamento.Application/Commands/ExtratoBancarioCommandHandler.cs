using AutoMapper;
using ContabilizaJa.Movimentacao.Data;
using ContabilizaJa.Movimentacao.Domain;
using ContabilizaJa.Movimentacao.Service.Validators;
using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContabilizaJa.Processamento.ApplicationCore.Commands
{
    public class ExtratoBancarioCommandHandler 
        : IRequestHandler<AdicionarExtratoBancarioCommand, bool>,
          IRequestHandler<RemoverExtratoBancarioCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IExtratoBancarioRepository _extratroRepositorio;

        public ExtratoBancarioCommandHandler(IMediator mediator, IMapper mapper, IExtratoBancarioRepository extratroRepositorio)
        {
            _mediator = mediator;
            _mapper = mapper;
            _extratroRepositorio = extratroRepositorio;
        }

        public async Task<bool> Handle(AdicionarExtratoBancarioCommand request, CancellationToken cancellationToken)
        {
            var extrato = new ExtratoBancario(request.Transacoes, request.DataInicio, request.DataFim);

            var validator = new ExtratoBancarioValidator().Validate(extrato);

            if (validator.IsValid)
            {
                await _extratroRepositorio.Adicionar(extrato);
                await _mediator.Publish(new DomainNotification("AdicionarExtratoBancario", "Extrato foi salvo com sucesso!!"));
            }
            else
            {
                await _mediator.Publish(new DomainNotification("AdicionarExtratoBancario", validator.Errors.ToString()));
                return false;
            }
            return true;
        }

        public Task<bool> Handle(RemoverExtratoBancarioCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
