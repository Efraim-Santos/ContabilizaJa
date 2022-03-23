using AutoMapper;
using ContabilizaJa.Movimentacao.Application;
using ContabilizaJa.Movimentacao.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContabilizaJa.Movimentacao.Data.Queries
{
    public class ExtratoBancarioQueries : IExtratoBancarioQueries
    {
        private readonly IExtratoBancarioRepository ExtratoBancarioRepository;
        private readonly IMapper _mapper;

        public ExtratoBancarioQueries(IExtratoBancarioRepository extratoBancarioRepository,
                                      IMapper mapper)
        {
            ExtratoBancarioRepository = extratoBancarioRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExtratoBancarioViewModels>> ObterListaDeExtratos()
        {
            var extratosSalvos = await ExtratoBancarioRepository.ObterTodos();

            var listaDeExtratos = new List<ExtratoBancarioViewModels>();

            foreach (var extrato in extratosSalvos)
            {
                listaDeExtratos.Add(_mapper.Map<ExtratoBancarioViewModels>(extrato));
            }

            return listaDeExtratos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExtratoBancarioViewModels> ConsultarExtrato(int id)
        {
            var extrato = await ExtratoBancarioRepository.ObterExtratoTransacoes(id);

            return _mapper.Map<ExtratoBancarioViewModels>(extrato) ?? null;
        } 
    }
}
