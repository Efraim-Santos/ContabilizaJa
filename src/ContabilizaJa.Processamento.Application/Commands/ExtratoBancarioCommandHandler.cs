using AutoMapper;
using ContabilizaJa.Movimentacao.Data;
using ContabilizaJa.Movimentacao.Data.Repository;
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
        private readonly IUnitOfWork UnitOfWork;

        public ExtratoBancarioCommandHandler(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AdicionarExtratoBancarioCommand request, CancellationToken cancellationToken)
        {
            var extrato = new ExtratoBancario(request.Transacoes, request.DataInicio, request.DataFim);

            var validator = new ExtratoBancarioValidator().Validate(extrato);

            if (validator.IsValid)
            {
                await UnitOfWork.ExtratoBancarioRepository.Adicionar(extrato);
                await UnitOfWork.Commit();
                await _mediator.Publish(new DomainNotification("AdicionarExtratoBancario", "Extrato foi salvo com sucesso!!"));
            }
            else
            {
                await _mediator.Publish(new DomainNotification("AdicionarExtratoBancario", validator.Errors.ToString()));
                return false;
            }
            return true;
        }

        public async Task<bool> Handle(RemoverExtratoBancarioCommand request, CancellationToken cancellationToken)
        {
            var extrato = await UnitOfWork.ExtratoBancarioRepository.ObterPorId(request.IdExtrato);

            if(extrato == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Extrato bancario não encontrado!!"));
                return false;
            }

            UnitOfWork.ExtratoBancarioRepository.Remover(extrato);
            await UnitOfWork.Commit();
            await _mediator.Publish(new DomainNotification(request.GetType().Name, "Extrato foi removido com sucesso!!"));
            return true;
        }
    }
}
