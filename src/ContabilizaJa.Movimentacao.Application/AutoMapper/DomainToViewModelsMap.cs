using AutoMapper;
using ContabilizaJa.Movimentacao.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Application.AutoMapper
{
    public class DomainToViewModelsMap : Profile
    {
        public DomainToViewModelsMap()
        {
            CreateMap<ExtratoBancario, ExtratoBancarioViewModels>()
                .ForMember(e => e.Periodo,
                                map => map.MapFrom(ebd => $"Relatório de saldo da conta para o período de {ebd.DataInicio} a {ebd.DataFim}"));

            CreateMap<Transacoes, TransacoesViewModel>();
        }
    }
}
