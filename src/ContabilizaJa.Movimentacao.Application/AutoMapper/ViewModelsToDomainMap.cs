using AutoMapper;
using ContabilizaJa.Movimentacao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Application.AutoMapper
{
    public class ViewModelsToDomainMap : Profile
    {
        public ViewModelsToDomainMap()
        {
            CreateMap<TransacoesViewModel, Transacoes>();

            CreateMap<ExtratoBancarioViewModels, ExtratoBancario>()
                .ForSourceMember(evm => evm.Periodo, opt => opt.DoNotValidate());
        }
    }
}
