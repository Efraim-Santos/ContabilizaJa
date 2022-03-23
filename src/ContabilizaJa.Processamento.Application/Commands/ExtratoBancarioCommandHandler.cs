using AutoMapper;
using ContabilizaJa.Movimentacao.Application;
using ContabilizaJa.Movimentacao.Data;
using ContabilizaJa.Movimentacao.Data.Repository;
using ContabilizaJa.Movimentacao.Domain;
using ContabilizaJa.Movimentacao.Service.Validators;
using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            var extrato = _mapper.Map<ExtratoBancarioViewModels, ExtratoBancario>(request.ExtratoBancario);

            var validator = new ExtratoBancarioValidator().Validate(extrato);

            if (validator.IsValid)
            {
                await UnitOfWork.ExtratoBancarioRepository.Adicionar(extrato);
                await UnitOfWork.Commit();
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Extrato foi salvo com sucesso!!"));
            }
            else
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, validator.Errors.ToString()));
                return false;
            }
            return true;
        }

        public async Task<bool> Handle(RemoverExtratoBancarioCommand request, CancellationToken cancellationToken)
        {
            var extrato = await UnitOfWork.ExtratoBancarioRepository.ObterPorId(request.IdExtrato);

            if (extrato == null)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, "Extrato bancario não encontrado!!"));
                return false;
            }

            try
            {
                await UnitOfWork.TransacoesBancariasRepository.RemoverTransacoesDoExtrato(extrato.Id);

                UnitOfWork.ExtratoBancarioRepository.Remover(extrato);

                await UnitOfWork.Commit();
            }
            catch (Exception e)
            {
                await _mediator.Publish(new DomainNotification(request.GetType().Name, e.Message));
               return false;
            }
            await _mediator.Publish(new DomainNotification(request.GetType().Name, "Extrato foi removido com sucesso!!"));
            
            return true;
        }
    }
}
