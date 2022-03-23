using AutoMapper;
using ContabilizaJa.Movimentacao.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContabilizaJa.Movimentacao.Application.AutoMapper
{
    public class ViewModelsToDomainMap : Profile
    {
        public ViewModelsToDomainMap()
        {
            CreateMap<TransacoesViewModel, Transacoes>();

            CreateMap<ExtratoBancarioViewModels, ExtratoBancario>()
                .ForMember(dest => dest.DataInicio, (map => map.MapFrom(t => t.Transacoes.OrderBy(tr => tr.Data).FirstOrDefault().Data.Date)))
                .ForMember(dest => dest.DataFim, (map => map.MapFrom(t => t.Transacoes.OrderByDescending(tr => tr.Data).FirstOrDefault().Data.Date)))
                .ConstructUsing((context) => new ExtratoBancario(context.DataInicio, context.DataFim, context.DataRegistro));
        }
    }
}